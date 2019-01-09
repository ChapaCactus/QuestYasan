using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace CCG
{
    [RequireComponent(typeof(CardView))]
    public class CardPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Card";

        private CardModel _model;
        private CardView _view;

        public static CardPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<CardPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup(CardModel model, Vector3 position)
        {
            _model = model;
            _view = GetComponent<CardView>();

            _view.Setup(position);

            // カード絵セット
            var spritePath = $"Sprites/Card/{model.SpriteName}";
            Sprite sprite = Resources.Load<Sprite>(spritePath);
            _view.SetCardSprite(sprite);

            BindViewEvents();
            BindModelEvents();
        }

        private void BindModelEvents()
        {
            // 選択状態イベントの購読
            _model.IsSelect
                .Subscribe(_view.OnSelect)
                .AddTo(this);

            // カード選択がオンになった時のみ
            _model.IsSelect
                .Where(isSelect => isSelect)
                .Subscribe(isSelect => Game.Stage.OnSelectCard(_model.UniqueId))
                .AddTo(this);
        }

        private void BindViewEvents()
        {
            // カードタップ時のイベント登録
            _view.OnSingleTap
                .Subscribe(_ => _model.SetIsSelect(true))
                .AddTo(this);
        }
    }
}