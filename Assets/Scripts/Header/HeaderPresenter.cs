using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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

            BindModelEvents();
            BindViewEvents();

            // 表示初期化
            _view.SetGoldText(_model.UserModel.Gold.Value);

            _isInitialized = true;
        }

        protected override void BindModelEvents()
        {
            _model.UserModel.Gold.AsObservable()
                .Subscribe(_view.SetGoldText)
                .AddTo(this);
        }

        protected override void BindViewEvents()
        {
        }
    }

}