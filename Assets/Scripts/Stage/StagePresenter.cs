using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Google2u;

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

            // 初期フロア追加
            foreach (var loop in Enumerable.Range(0, 3))
            {
                // ランダムなカードIDを取得
                CardMaster.rowIds masterId = Enum.GetValues(typeof(CardMaster.rowIds))
                    .Cast<CardMaster.rowIds>()
                    .OrderBy(x => Guid.NewGuid())
                    .FirstOrDefault();

                int uniqueId = GameManager.UniqueIdManager.GetNewId();
                CardModel cardModel = new CardModel(masterId, uniqueId);
                FloorModel floorModel = new FloorModel(cardModel);

                AddFloor(floorModel);
            }
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