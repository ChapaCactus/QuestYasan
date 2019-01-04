using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class BattleManager
    {
        public UserModel UserModel { get; private set; }

        public HandsPresenter Hands { get; private set; }
        public CardDescriptionPresenter CardDescription { get; private set; }

        public void Initialize()
        {
            UserModel = new UserModel();

            Hands = HandsPresenter.Create(MainCanvas.I.UIParent);
            Hands.Setup(UserModel.Hand);

            CardDescription = CardDescriptionPresenter.Create(MainCanvas.I.UIParent);
            CardDescription.gameObject.SetActive(false);
        }

        public void OnSelectCard(int select)
        {
            // 選択したカードのみ選択状態にする
            UserModel.Hand.Cards
                .ForEach(card => {
                    bool isMatch = card.UniqueId == select;
                    card.IsSelect.Value = isMatch;
                });

            // 説明文更新
            CardModel selectCard = UserModel.Hand.Cards
                .First(card => card.IsSelect.Value);
            CardDescription.SetText(selectCard.Description);
            CardDescription.gameObject.SetActive(true);
        }
    }
}