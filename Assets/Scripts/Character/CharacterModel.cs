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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterModel()
        {
            State.Value = CharacterState.Waiting;
        }
    }

}