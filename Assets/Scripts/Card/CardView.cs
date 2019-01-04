using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UniRx;

namespace CCG
{
    public class CardView : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Card";

        [SerializeField] private Image _cardImage;
        [SerializeField] private Image _background;

        [SerializeField] private Button _button;

        public IObservable<Unit> OnSingleTap => _button.OnClickAsObservable();

        public static CardView Create(Transform parent)
        {
            var prefab = Resources.Load<CardView>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup(CardModel model)
        {
            var spritePath = $"Sprites/Card/{model.SpriteName}";
            Sprite sprite = Resources.Load<Sprite>(spritePath);
            _cardImage.sprite = sprite;
        }
    }
}