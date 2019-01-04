using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class HandModel
    {
        private const int DefaultHandSize = 4;

        public List<CardModel> Cards { get; private set; }

        /// <summary>
        /// 初期手札枚数までカードを引く
        /// </summary>
        public void DrawForDefaultSize()
        {
            if(Cards.Count >= DefaultHandSize)
            {
                return;
            }
        }
    }
}