using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class CardDescriptionPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/CardDescription";

        public static CardDescriptionPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<CardDescriptionPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }
    }
}