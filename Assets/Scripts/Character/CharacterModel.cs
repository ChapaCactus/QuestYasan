using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using CCG.Enums;

namespace CCG
{
    public class CharacterModel
    {
        private const float BaseMoveSpeed = 0.01f;

        public IntReactiveProperty CurrentFloorIndex { get; private set; } = new IntReactiveProperty(0);
        public ReactiveProperty<CharacterState> State { get; private set; } = new ReactiveProperty<CharacterState>();

        public float MoveSpeed => BaseMoveSpeed;

        public bool IsPlayer { get; set; }

        public string Name { get; set; }
        public IntReactiveProperty MaxHealth { get; set; }
        public IntReactiveProperty Health { get; set; }
        public IntReactiveProperty Attack { get; set; }
        public FloatReactiveProperty AttackTimer { get; private set; }

        public bool IsDead => Health.Value <= 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterModel()
        {
            State.Value = CharacterState.Waiting;

            float startTime = UnityEngine.Random.Range(1, 1.5f);
            AttackTimer = new FloatReactiveProperty(startTime);
        }

        public void Damage(int damage)
        {
            if(IsDead)
            {
                return;
            }

            Health.Value -= damage;
            Debug.Log($"{Name}は{damage}ダメージを受けた。 残りHealth:{Health.Value}");

            if (IsDead)
            {
                GameManager.BattleManager.OnDead(IsPlayer);
            }
        }
    }

}