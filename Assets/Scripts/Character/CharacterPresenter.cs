using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UniRx;
using CCG.Enums;

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

            BindModelEvents();
            BindViewEvents();

            _model.CurrentFloorIndex.Value = 0;
            _model.State.Value = CharacterState.Moving;

            _isInitialized = true;
        }

        /// <summary>
        /// 行動を進める
        /// </summary>
        private void Next()
        {
            // 待機中は何もしない
            if (_model.State.Value == CharacterState.Waiting)
            {
                return;
            }

            // 進捗度を進める
            _currentFloor.Progress += _model.MoveSpeed;
            // 現在位置更新
            transform.localPosition = _currentFloor.GetPositionLerp();

            if (_currentFloor.IsOver)
            {
                FloorUp();
            }
        }

        private void FloorUp()
        {
            _model.CurrentFloorIndex.Value++;
        }

        protected override void BindModelEvents()
        {
            // 現在の階数の変更時
            _model.CurrentFloorIndex.AsObservable()
                .Subscribe(OnCurrentFloorIndexChanged)
                .AddTo(this);

            // CharacterState変更時
            _model.State.AsObservable()
                .Subscribe(OnStateChanged)
                .AddTo(this);
        }

        protected override void BindViewEvents()
        {
        }

        /// <summary>
        /// ステート変更時
        /// </summary>
        private void OnStateChanged(CharacterState state)
        {
        }

        private void OnCurrentFloorIndexChanged(int index)
        {
            // 親を変更後のフロアに設定
            _currentFloor = GameManager.BattleManager.Stage.GetFloor(index);

            // フロアが存在しなければ停止
            if (_currentFloor == null)
            {
                _model.State.Value = CharacterState.Waiting;
                return;
            }

            _currentFloor.Progress = 0;
            transform.SetParent(_currentFloor.transform);
        }
    }

}