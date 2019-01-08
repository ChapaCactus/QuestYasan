using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace CCG
{
    [RequireComponent(typeof(FloorView))]
    public class FloorPresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Floor";
        private const string EventPointPrefabPath = "Prefabs/EventPoint";

        // 開始地点, 終了地点
        [SerializeField] private Transform _startPos;
        [SerializeField] private Transform _endPos;

        private FloorModel _model;
        private FloorView _view;

        private BattleEventPoint _eventPoint;

        public float Progress
        {
            get
            {
                return _model.Progress.Value;
            }
            set
            {
                _model.Progress.Value = value;
            }
        }

        public bool IsOver => _model.IsOver;

        public static FloorPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<FloorPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        // TODO: Initializeに統合
        public void Setup(FloorModel model)
        {
            _model = model;
            _view = GetComponent<FloorView>();

            // 表示初期化
            _view.SetFloorNameText(_model.FloorName);

            // TODO: バトル以外のEventを配置
            _eventPoint = BattleEventPoint.Create(transform);
            _eventPoint.transform.localPosition = GetPositionLerp(_model.CardModel.EventPoint);
            // TODO: ゴブリン以外の敵への対応
            _eventPoint.Setup(Google2u.EnemyMaster.rowIds.Goblin, _model.CardModel.EventPoint);
        }

        public override void Initialize()
        {
            BindModelEvents();
            BindViewEvents();
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

        protected override void BindModelEvents()
        {
            _model.Progress.AsObservable()
                .Subscribe(OnProgressValueChanged)
                .AddTo(this);
        }

        protected override void BindViewEvents()
        {
        }

        private void OnProgressValueChanged(float progress)
        {
            // 既に接触したEventPointなら何もしない
            if(_eventPoint.IsUsed)
            {
                return;
            }

            if (progress >= _eventPoint.ProgressThreshold)
            {
                _eventPoint.OnHit();
            }
        }
    }

}