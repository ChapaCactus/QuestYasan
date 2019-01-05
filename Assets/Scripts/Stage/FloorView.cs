using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CCG
{
    public class FloorView : MonoBehaviour
    {
        private const float Height = 200;

        [SerializeField] private TextMeshProUGUI _floorNameText;

        public void SetFloorNameText(string text)
        {
            _floorNameText.text = text;
        }
    }
}