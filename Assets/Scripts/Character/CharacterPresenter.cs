using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;

namespace CCG
{
    [RequireComponent(typeof(CharacterView))]
    public class CharacterPresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Character";

        private CharacterModel _model;
        private CharacterView _view;

        private FloorPresenter _currentFloor = null;

        private void Update()
        {
            Next();
        }

        public static CharacterPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<CharacterPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public override void Initialize()
        {
            base.Initialize();

            _model = new CharacterModel();
            _view = GetComponent<CharacterView>();

            // 現在の階数の変更時
            _model.CurrentFloorIndex.AsObservable()
                .Subscribe(index => {
                    // 親を変更後のフロアに設定
                    _currentFloor = GameManager.BattleManager.Stage.Floors[index];
                    transform.SetParent(_currentFloor.transform);
                })
                .AddTo(this);

            _model.CurrentFloorIndex.Value = 0;

            _isInitialized = true;
        }

        /// <summary>
        /// 行動を進める
        /// </summary>
        private void Next()
        {
            if(_currentFloor.IsOver)
            {
                FloorUp();
                return;
            }

            // 進捗度を進める
            _currentFloor.Progress += _model.MoveSpeed;
            // 現在位置更新
            transform.localPosition = _currentFloor.GetPositionLerp();
        }

        private void FloorUp()
        {
            _currentFloor.Progress = 0;
            _model.CurrentFloorIndex.Value++;
        }
    }

}