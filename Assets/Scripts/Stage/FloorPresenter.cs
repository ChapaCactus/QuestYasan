using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    [RequireComponent(typeof(FloorView))]
    public class FloorPresenter : MonoBehaviour
    {
        private FloorModel _model;
        private FloorView _view;

        public void Setup(FloorModel model)
        {
            _model = model;
            _view = GetComponent<FloorView>();

            // 表示初期化
            _view.SetFloorNameText(_model.FloorName);
        }
    }
}