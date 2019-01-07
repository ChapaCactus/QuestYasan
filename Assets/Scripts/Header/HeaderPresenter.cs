using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    [RequireComponent(typeof(HeaderView))]
    public class HeaderPresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Header";

        private HeaderModel _model;
        private HeaderView _view;

        public static HeaderPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<HeaderPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public override void Initialize(IParameter param)
        {
            base.Initialize();

            _model = new HeaderModel(param as HeaderParam);
            _view = GetComponent<HeaderView>();

            _view.SetGoldText(_model.Gold);

            _isInitialized = true;
        }

        protected override void BindModelEvents()
        {
        }

        protected override void BindViewEvents()
        {
        }
    }
}