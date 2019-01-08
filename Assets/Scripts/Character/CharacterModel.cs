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

            AttackTimer = new FloatReactiveProperty(1);
        }

        public void Damage(int damage)
        {
            if(IsDead)
            {
                return;
            }

            Debug.Log($"Damage! left: {damage}, amount: {Health.Value - damage}");
            Health.Value -= damage;

            if(IsDead)
            {
                GameManager.BattleManager.OnDead(IsPlayer);
            }
        }
    }

}