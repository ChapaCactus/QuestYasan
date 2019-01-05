using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class FloorModel
    {
        public CardModel CardModel { get; private set; }

        public string FloorName => CardModel.Name;

        public FloorModel(CardModel card)
        {
            CardModel = card;
        }
    }
}