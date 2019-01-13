using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;

        [SerializeField] private Image _charaImage;

        public void SetHealthBarValue(int max, int value)
        {
            _healthBar.maxValue = max;
            _healthBar.value = value;
        }

        public void SetFlip(bool isRight)
        {
            var scaleX = isRight ? -1 : 1;
            _charaImage.transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }
}