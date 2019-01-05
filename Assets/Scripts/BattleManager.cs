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
        public ScreenButtonPresenter ScreenButton { get; private set; }

        public void Initialize()
        {
            UserModel = new UserModel();

            Hands = HandsPresenter.Create(MainCanvas.I.UIParent);
            Hands.Setup(UserModel.Hand);

            CardDescription = CardDescriptionPresenter.Create(MainCanvas.I.UIParent);
            CardDescription.gameObject.SetActive(false);

            ScreenButton = ScreenButtonPresenter.Create(MainCanvas.I.ScreenButtonParent);
            ScreenButton.Setup();
        }

        /// <summary>
        /// カードが選択された
        /// </summary>
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

        /// <summary>
        /// 画面ボタンを押した時
        /// </summary>
        public void OnScreenButton()
        {
            // 説明文非表示
            CardDescription.gameObject.SetActive(false);

            // カード選択解除
            UserModel.Hand.Cards
                .ForEach(card => card.IsSelect.Value = false);
        }
    }
}