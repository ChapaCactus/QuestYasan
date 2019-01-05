using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CCG
{
    public class FloorView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _floorNameText;

        public void SetFloorNameText(string text)
        {
            _floorNameText.text = text;
        }
    }
}