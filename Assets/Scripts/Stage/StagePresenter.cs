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

        [SerializeField] private Transform _floorsParent;

        private StageModel _model;
        private StageView _view;

        public List<FloorPresenter> Floors { get; private set; } = new List<FloorPresenter>();

        public static StagePresenter Create(Transform parent)
        {
            var prefab = Resources.Load<StagePresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup()
        {
            _model = new StageModel();
            _view = GetComponent<StageView>();

            Floors = new List<FloorPresenter>();

            BindModelEvents();
            BindViewEvents();

            // 初期フロア追加
            foreach (var loop in Enumerable.Range(0, 8))
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

        private void BindModelEvents()
        {
            // フロア追加時
            _model.Floors.ObserveAdd()
                .Subscribe(model =>
                {
                    // Presenterを作成
                    FloorPresenter presenter = FloorPresenter.Create(_floorsParent);
                    presenter.transform.SetAsFirstSibling();
                    presenter.Setup(model.Value);
                    Floors.Add(presenter);
                })
                .AddTo(this);
        }

        private void BindViewEvents()
        {
        }
    }

}