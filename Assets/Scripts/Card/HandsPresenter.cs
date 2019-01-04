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

        public List<CardView> Cards { get; private set; } = new List<CardView>();

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
                CardView cardView = CardView.Create(parent);
                Vector3 cardPos = _view.CardPositions[loop];
                cardView.transform.localPosition = cardPos;

                // カードタップ時のイベント登録
                cardView.OnSingleTap
                    .Subscribe(_ => OnTapCard(loop))
                    .AddTo(this);

                Cards.Add(cardView);
            }
        }

        private void OnTapCard(int index)
        {

        }
    }

}