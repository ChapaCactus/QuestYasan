using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

namespace CCG
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _cardImage;
        [SerializeField] private Image _background;

        [SerializeField] private Button _button;

        private Vector3 DefaultPosition { get; set; } = Vector3.zero;

        public IObservable<Unit> OnSingleTap => _button.OnClickAsObservable();

        public void Setup(Vector3 position)
        {
            transform.localPosition = position;
            // 初期位置を記憶しておく
            DefaultPosition = position;
        }

        public void SetCardSprite(Sprite sprite)
        {
            _cardImage.sprite = sprite;
        }

        public void OnSelect(bool isSelect)
        {
            float yPos = isSelect ? 40 : 0;
            transform.localPosition = DefaultPosition;

            transform.DOLocalMoveY(yPos, 0.1f)
                .SetEase(Ease.Linear)
                .SetRelative(true);
        }
    }
}