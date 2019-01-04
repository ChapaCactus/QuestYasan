using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class UserModel
    {
        public DeckModel Deck { get; private set; }

        /// <summary>
        /// 手札
        /// </summary>
        public HandModel Hand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserModel()
        {
            Deck = new DeckModel();
            Hand = new HandModel();

            FillDeck();
            // 初手
            FillHand();
        }

        /// <summary>
        /// このユーザーターン開始時
        /// </summary>
        public void OnStartUserTurn()
        {
        }

        /// <summary>
        /// デッキを満たす
        /// </summary>
        private void FillDeck()
        {
            // デッキ枚数上限までカード追加
            while (!Deck.IsFull)
            {
                Deck.Add();
            }
        }

        /// <summary>
        /// 一杯になるまでカードを引く
        /// </summary>
        private void FillHand()
        {
            // カードを引く
            while (!Hand.IsFull)
            {
                var draw = Deck.Draw();
                Hand.SetCard(draw);
            }
        }
    }
}