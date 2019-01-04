using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CCG
{
    public class CardDescriptionPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/CardDescription";

        [SerializeField] private TextMeshProUGUI _description;

        public static CardDescriptionPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<CardDescriptionPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void SetText(string text)
        {
            _description.text = text;
        }
    }
}