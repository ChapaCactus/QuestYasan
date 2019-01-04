using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CCG
{
    public class HandPresenter
    {
        private HandModel _model;
        private HandsView _view;

        public List<CardView> Cards { get; private set; } = new List<CardView>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HandPresenter(HandModel model)
        {
            _model = model;
            _view = HandsView.Create(null);

            CreateCardViews(_view.CardsParent);
        }

        private void CreateCardViews(Transform parent)
        {
            foreach (var loop in Enumerable.Range(0, HandModel.MaxHandSize))
            {
                CardView cardView = CardView.Create(null);
                Cards.Add(cardView);
            }
        }
    }

}