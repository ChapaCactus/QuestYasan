using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace CCG
{
    public class ScreenButtonPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/ScreenButton";

        [SerializeField] private Button _button;

        public static ScreenButtonPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<ScreenButtonPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup()
        {
            _button.OnClickAsObservable()
                .Subscribe(_ => Game.Stage.OnScreenButton())
                .AddTo(this);
        }
    }
}