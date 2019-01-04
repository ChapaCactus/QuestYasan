using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class HandsView : MonoBehaviour
    {
        [SerializeField] private Transform _cardsParent;
        [SerializeField] private List<Transform> _cardPositions;

        public Transform CardsParent => _cardsParent;

        // カード配置位置
        public List<Vector3> CardPositions => _cardPositions
            .Select(pos => pos.localPosition)
            .ToList();
    }
}