﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class HandModel
    {
        public const int MaxHandSize = 4;

        public List<CardModel> Cards { get; private set; }

        public bool IsFull => Cards.Count >= MaxHandSize;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HandModel()
        {
            Cards = new List<CardModel>();
        }

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