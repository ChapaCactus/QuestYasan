using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Google2u;
using CCG.Enums;

namespace CCG
{
    public class CardModel
    {
        private CardMasterRow _row;
        private CardCategory _category;

        public string Name => _row._Name;
        public CardCategory Category => _category;
        public int Cost => _row._Cost;

        public string SpriteName => _row._Sprite;

        public static CardModel Create(CardMaster.rowIds id)
        {
            var cardMasterRow = CardMaster.Instance.GetRow(id);
            return new CardModel(cardMasterRow);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CardModel(CardMasterRow cardMasterRow)
        {
            _row = cardMasterRow;
            _category = (CardCategory)Enum.Parse(typeof(CardCategory), cardMasterRow._Category);
        }
    }
}