﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class MainCanvas : SingletonMonoBehaviour<MainCanvas>
    {
        [SerializeField] private Transform _uiParent;
        [SerializeField] private Transform _screenButtonParent;

        public Transform UIParent => _uiParent;
        public Transform ScreenButtonParent => _screenButtonParent;
    }
}