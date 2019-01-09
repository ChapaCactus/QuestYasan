using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace CCG
{
    public class EnemyPresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Enemy";

        private CharacterModel _model;

        public static EnemyPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<EnemyPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public override void Initialize(IParameter param)
        {
            EnemyParam enemyParam = param as EnemyParam;
            _model = new CharacterModel()
            {
                Name = enemyParam.EnemyMasterRow._Name,
                Health = new IntReactiveProperty(10),
                Attack = new IntReactiveProperty(1),
            };

            BindModelEvents();
            BindViewEvents();
        }

        public void ForwardBattleTimer(float forward)
        {
            if(_model.IsDead)
            {
                return;
            }

            _model.AttackTimer.Value -= forward;
        }

        public void SetState(Enums.CharacterState state)
        {
            _model.State.Value = state;
        }

        public void Damage(int damage)
        {
            _model.Damage(damage);
        }

        protected override void BindModelEvents()
        {
            // AttackTimer更新時
            _model.AttackTimer.AsObservable()
                .Subscribe(OnAttackTimerValueChanged)
                .AddTo(this);
        }

        protected override void BindViewEvents()
        {
        }

        private void OnAttackTimerValueChanged(float timer)
        {
            // 0以下になっていれば行動してリセット
            if (_model.AttackTimer.Value <= 0)
            {
                CharacterPresenter player = Game.Stage.Character;
                player.Damage(_model.Attack.Value);
                // TODO: リセット値を正しいものにする
                _model.AttackTimer.Value = 1;
                Debug.Log($"{_model.Name}の攻撃！");
            }
        }
    }
}