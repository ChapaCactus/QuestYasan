using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
    [RequireComponent(typeof(FloorView))]
    public class FloorPresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Floor";
        private const string EventPointPrefabPath = "Prefabs/EventPoint";

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

            // TODO: バトル以外のEventを配置
            BattleEventPoint eventPoint = BattleEventPoint.Create(transform);
            eventPoint.transform.localPosition = GetPositionLerp(_model.CardModel.EventPoint);
        }

        /// <summary>
        /// このフロアの現在位置を取得する
        /// </summary>
        /// <returns>現在位置</returns>
        /// <param name="progress">進捗度</param>
        public Vector2 GetPositionLerp()
        {
            return GetPositionLerp(Progress);
        }

        public Vector2 GetPositionLerp(float value)
        {
            return Vector2.Lerp(_startPos.localPosition, _endPos.localPosition, value);
        }
    }

}