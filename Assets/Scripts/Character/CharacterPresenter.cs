using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

            _currentFloor = GetCurrentFloor();
        }

        /// <summary>
        /// 行動を進める
        /// </summary>
        private void Next()
        {
            if(_currentFloor.Progress >= 1)
            {
                return;
            }

            // TODO: 進捗度を定数化、もしくはModelから計算、もしもしくはGlobalゲーム速度から取得
            // 進捗度を進める
            _currentFloor.Progress += 0.01f;

            // 現在位置更新
            transform.localPosition = _currentFloor.GetPositionLerp();

            if(_currentFloor.Progress >= 1)
            {
                FloorUp();
            }
        }

        private void FloorUp()
        {
            _currentFloor.Progress = 0;
            _model.CurrentFloorIndex++;
            // TODO: CurrentIndex変更時に購読する
            // 親を変更
            transform.SetParent(GetCurrentFloor().transform);
        }

        private FloorPresenter GetCurrentFloor()
        {
            int current = _model.CurrentFloorIndex;
            return GameManager.BattleManager.Stage.Floors[current];
        }
    }

}