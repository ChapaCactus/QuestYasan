using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Google2u;

namespace CCG
{
    /// <summary>
    /// 山札 Model
    /// </summary>
    public class DeckModel
    {
        private const int MaxCardSize = 40;

        public List<CardModel> Cards { get; private set; } = new List<CardModel>();

        public bool IsEmpty => Cards.Any();
        public bool IsFull => Cards.Count.Equals(MaxCardSize);

        /// <summary>
        /// カードを引く
        /// </summary>
        public CardModel Draw()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);

            return card;
        }

        public void Add()
        {
            if(IsFull)
            {
                Debug.Log("Deck is full.");
                return;
            }

            // ランダムなカードIDを取得
            CardMaster.rowIds masterId = Enum.GetValues(typeof(CardMaster.rowIds))
                .Cast<CardMaster.rowIds>()
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            int uniqueId = Game.UniqueIdManager.GetNewId();

            CardModel model = new CardModel(masterId, uniqueId);
            Cards.Add(model);
        }
    }
}