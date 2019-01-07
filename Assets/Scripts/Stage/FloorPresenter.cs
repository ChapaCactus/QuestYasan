using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    [RequireComponent(typeof(FloorView))]
    public class FloorPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Floor";

        // 開始地点, 終了地点
        [SerializeField] private Transform _startPos;
        [SerializeField] private Transform _endPos;

        private FloorModel _model;
        private FloorView _view;

        public float Progress
        {
            get
            {
                return _model.Progress;
            }
            set
            {
                _model.Progress = value;
            }
        }

        public bool IsOver => _model.IsOver;

        public static FloorPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<FloorPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup(FloorModel model)
        {
            _model = model;
            _view = GetComponent<FloorView>();

            // 表示初期化
            _view.SetFloorNameText(_model.FloorName);
        }

        /// <summary>
        /// このフロアの現在位置を取得する
        /// </summary>
        /// <returns>現在位置</returns>
        /// <param name="progress">進捗度</param>
        public Vector2 GetPositionLerp()
        {
            return Vector2.Lerp(_startPos.localPosition, _endPos.localPosition, Progress);
        }
    }

}