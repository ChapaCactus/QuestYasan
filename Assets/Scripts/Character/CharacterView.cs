using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;

        public void SetHealthBarValue(int max, int value)
        {
            _healthBar.maxValue = max;
            _healthBar.value = value;
        }
    }
}