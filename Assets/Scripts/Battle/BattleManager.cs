using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UniRx;

namespace CCG
{
    public class BattleManager
    {
        public UserModel UserModel { get; private set; }

        public BattlePresenter Battle { get; private set; }

        public HeaderPresenter Header { get; private set; }
        public HandsPresenter Hands { get; private set; }
        public CardDescriptionPresenter CardDescription { get; private set; }
        public ScreenButtonPresenter ScreenButton { get; private set; }
        public StagePresenter Stage { get; private set; }
        public CharacterPresenter Character { get; private set; }

        public void Initialize()
        {
            UserModel = new UserModel();

            Battle = BattlePresenter.Create(MainCanvas.I.UIParent);
            Battle.Initialize();

            // ヘッダー
            Header = HeaderPresenter.Create(MainCanvas.I.UIParent);
            var headerParam = new HeaderParam()
            {
                UserModel = UserModel,
            };
            Header.Initialize(headerParam);

            // 手札の初期化
            Hands = HandsPresenter.Create(MainCanvas.I.UIParent);
            Hands.Setup(UserModel.Hand);

            // カード説明文初期化
            CardDescription = CardDescriptionPresenter.Create(MainCanvas.I.UIParent);
            CardDescription.gameObject.SetActive(false);

            // スクリーンボタンの初期化
            ScreenButton = ScreenButtonPresenter.Create(MainCanvas.I.ScreenButtonParent);
            ScreenButton.Setup();

            // ステージの初期化
            Stage = StagePresenter.Create(MainCanvas.I.UIParent);
            Stage.Initialize();

            // 戦闘開始
            StartBattle();
        }

        public void StartBattle()
        {
            // TODO: 現在のフロアで開始
            Character = CharacterPresenter.Create(Stage.GetFloor(0).transform);
            Character.Initialize();
        }

        public void SetEnemy(EnemyPresenter enemy)
        {
            Battle.SetEnemy(enemy);
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
                    card.SetIsSelect(isMatch);
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
                .ForEach(card => card.SetIsSelect(false));
        }
    }
}