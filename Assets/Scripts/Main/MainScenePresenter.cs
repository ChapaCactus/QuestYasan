using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class MainScenePresenter : MonoBehaviour
    {
        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            Game.Initialize();
        }
    }
}