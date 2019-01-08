using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace CCG
{
    public class FloorModel
    {
        public FloatReactiveProperty Progress { get; private set; }

        /// <summary>
        /// 踏破済か
        /// </summary>
        public bool IsOver => Progress.Value >= 1;

        public CardModel CardModel { get; private set; }

        public string FloorName => CardModel.Name;

        public FloorModel(CardModel card)
        {
            Progress = new FloatReactiveProperty(0);
            CardModel = card;
        }
    }

}