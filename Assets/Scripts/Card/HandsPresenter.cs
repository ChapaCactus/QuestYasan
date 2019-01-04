using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace CCG
{
    [RequireComponent(typeof(HandsView))]
    public class HandsPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Hands";

        private HandModel _model;
        private HandsView _view;

        public List<CardPresenter> Cards { get; private set; } = new List<CardPresenter>();

        public static HandsPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<HandsPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup(HandModel model)
        {
            _model = model;

            var viewParent = MainCanvas.I.UIParent;
            _view = GetComponent<HandsView>();

            CreateCardViews(_view.CardsParent);
        }

        private void CreateCardViews(Transform parent)
        {
            foreach (var loop in Enumerable.Range(0, HandModel.MaxHandSize))
            {
                // カード生成
                CardPresenter cardPresenter = CardPresenter.Create(parent);
                CardModel cardModel = _model.Cards[loop];
                // カード位置
                Vector3 cardPos = _view.CardPositions[loop];
                cardPresenter.transform.localPosition = cardPos;
                // カード設定
                cardPresenter.Setup(cardModel, cardPos);

                Cards.Add(cardPresenter);
            }
        }
    }

}