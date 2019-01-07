using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class FloorModel
    {
        private float _progress = 0;

        public float Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                _progress = Mathf.Clamp01(value);
            }
        }

        /// <summary>
        /// 踏破済か
        /// </summary>
        public bool IsOver => Progress >= 1;

        public CardModel CardModel { get; private set; }

        public string FloorName => CardModel.Name;

        public FloorModel(CardModel card)
        {
            _progress = 0;
            CardModel = card;
        }
    }

}