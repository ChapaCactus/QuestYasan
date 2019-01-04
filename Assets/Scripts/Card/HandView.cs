using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class HandView : MonoBehaviour
    {
        [SerializeField] private Transform _cardsParent;

        public Transform CardsParent => _cardsParent;

        public static HandView Create(Transform parent)
        {
            var prefab = Resources.Load<HandView>("");
            return Instantiate(prefab, parent);
        }
    }
}