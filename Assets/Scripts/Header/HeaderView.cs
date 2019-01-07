using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CCG
{
    public class HeaderView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;

        public void SetGoldText(int gold)
        {
            _goldText.text = $"Gold:{gold.ToString("D8")}";
        }
    }
}