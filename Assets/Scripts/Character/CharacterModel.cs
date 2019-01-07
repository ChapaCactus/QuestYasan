using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class CharacterModel
    {
        private const float BaseMoveSpeed = 0.01f;

        public int CurrentFloorIndex { get; set; } = 0;

        public float MoveSpeed => BaseMoveSpeed;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterModel()
        {
        }
    }

}