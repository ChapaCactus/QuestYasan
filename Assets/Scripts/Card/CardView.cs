using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace CCG
{
    public class CardView : MonoBehaviour
    {
        private const string PrefabPath = "";

        [SerializeField] private Image _cardImage;
        [SerializeField] private Image _background;

        public static CardView Create(Transform parent)
        {
            var prefab = Resources.Load<CardView>(PrefabPath);
            return Instantiate(prefab, parent);
        }
    }
}