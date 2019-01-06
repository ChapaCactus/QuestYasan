using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class CharacterModel
    {
        public int CurrentFloorIndex { get; set; } = 0;
        // TODO: 進捗度はFloorモデルに持たせる？
        // フロアの進捗度
        public float FloorProgress { get; set; } = 0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CharacterModel()
        {
        }
    }

}