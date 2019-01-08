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
            _model = new CharacterModel()
            {
                Health = new IntReactiveProperty(10),
                Attack = new IntReactiveProperty(1),
            };
        }

        public void ForwardBattleTimer(float forward)
        {
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
            // 0以下になっていればリセット
            if (_model.AttackTimer.Value <= 0)
            {
                CharacterPresenter player = GameManager.BattleManager.Character;
                player.Damage(_model.Attack.Value);
                // TODO: リセット値を正しいものにする
                _model.AttackTimer.Value = 1;
                Debug.Log("Enemy Attack!");
            }
        }
    }
}