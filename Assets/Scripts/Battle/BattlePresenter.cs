using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace CCG
{
    public class BattlePresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Battle";

        public ReactiveProperty<EnemyPresenter> Enemy { get; private set; }

        public static BattlePresenter Create(Transform parent)
        {
            var prefab = Resources.Load<BattlePresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public override void Initialize()
        {
            Enemy = new ReactiveProperty<EnemyPresenter>();

            BindModelEvents();
            BindViewEvents();
        }

        public void SetEnemy(EnemyPresenter enemy)
        {
            Enemy.Value = enemy;
        }

        protected override void BindModelEvents()
        {
            Enemy.AsObservable()
                .Subscribe(OnEnemyValueChanged)
                .AddTo(this);
        }

        protected override void BindViewEvents()
        {
        }

        private void OnEnemyValueChanged(EnemyPresenter enemy)
        {
            if(enemy == null)
            {
                return;
            }

            StartBattle();
        }

        private void StartBattle()
        {
            GameManager.BattleManager.Character.SetState(Enums.CharacterState.Battle);
        }
    }
}