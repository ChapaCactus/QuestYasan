using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class MainCanvas : SingletonMonoBehaviour<MainCanvas>
    {
        [SerializeField] private Transform _uiParent;

        public Transform UIParent => _uiParent;
    }
}