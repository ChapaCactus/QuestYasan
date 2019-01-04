using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class HandModel
    {
        private const int MaxHandSize = 4;

        public List<CardModel> Cards { get; private set; }

        public bool IsFull => Cards.Count >= MaxHandSize;

        public void SetCard(CardModel card)
        {
            if(IsFull)
            {
                return;
            }

            Cards.Add(card);
        }
    }
}