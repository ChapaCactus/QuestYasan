using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace CCG
{
    [RequireComponent(typeof(StageView))]
    public class StagePresenter : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/Stage";

        private StageModel _model;
        private StageView _view;

        public static StagePresenter Create(Transform parent)
        {
            var prefab = Resources.Load<StagePresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup()
        {
            _model = new StageModel();
            _view = GetComponent<StageView>();

            BindViewEvents();
        }

        public void AddFloor(FloorModel floor)
        {
            _model.Floors.Add(floor);
        }

        private void BindViewEvents()
        {
            // フロア追加時
            _model.Floors.ObserveAdd()
                .Subscribe(floor => _view.AddFloor(floor.Value))
                .AddTo(this);
        }
    }

}