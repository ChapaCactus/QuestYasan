using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Google2u;
using CCG.Enums;
using UniRx;

namespace CCG
{
    public class CardModel
    {
        private CardMasterRow _row;
        private CardCategory _category;
        private readonly int _uniqueId;

        public CardMaster.rowIds MasterId { get; private set; }
        public int UniqueId => _uniqueId;

        public BoolReactiveProperty IsSelect { get; private set; }

        public string Name => _row._Name;
        public string Description => _row._Description;
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

            IsSelect = new BoolReactiveProperty(false);
        }

        public void SetIsSelect(bool isSelect)
        {
            IsSelect.Value = isSelect;
        }
    }
}