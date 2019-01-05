using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace CCG
{
    public class StageModel
    {
        public ReactiveCollection<FloorModel> Floors { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StageModel()
        {
            Floors = new ReactiveCollection<FloorModel>();
        }
    }
}