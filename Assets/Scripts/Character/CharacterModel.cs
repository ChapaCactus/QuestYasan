using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class CharacterModel
    {
        public int CurrentFloorIndex { get; private set; } = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterModel()
        {
        }
    }
}