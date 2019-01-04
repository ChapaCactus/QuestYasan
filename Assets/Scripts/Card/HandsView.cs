using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class HandsView : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Hands";

        [SerializeField] private Transform _cardsParent;

        public Transform CardsParent => _cardsParent;

        public static HandsView Create(Transform parent)
        {
            var prefab = Resources.Load<HandsView>(PrefabPath);
            return Instantiate(prefab, parent);
        }
    }
}