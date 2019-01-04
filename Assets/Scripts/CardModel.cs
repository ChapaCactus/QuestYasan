﻿using System;
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
        private readonly int _uniqueId;

        public CardMaster.rowIds MasterId { get; private set; }
        public int UniqueId => _uniqueId;

        public string Name => _row._Name;
        public CardCategory Category => _category;
        public int Cost => _row._Cost;
        // 画像ファイル名
        public string SpriteName => _row._Sprite;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CardModel(CardMaster.rowIds masterId, int uniqueId)
        {
            MasterId = masterId;
            _uniqueId = uniqueId;

            var cardMasterRow = CardMaster.Instance.GetRow(masterId);
            _row = cardMasterRow;
            _category = (CardCategory)Enum.Parse(typeof(CardCategory), cardMasterRow._Category);
        }
    }
}