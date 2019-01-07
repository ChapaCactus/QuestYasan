using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;

namespace CCG
{
    public class HeaderView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;
        [SerializeField] private Button _pauseButton;

        public IObservable<Unit> OnPauseButton => _pauseButton.OnClickAsObservable();

        public void SetGoldText(int gold)
        {
            _goldText.text = $"Gold:{gold.ToString("D8")}";
        }
    }
}