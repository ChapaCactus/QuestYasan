using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Google2u;

namespace CCG
{
    [RequireComponent(typeof(StageView))]
    public class StagePresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Stage";

        [SerializeField] private Transform _floorsParent;

        private StageModel _model;
        private StageView _view;

        private List<FloorPresenter> _floors { get; set; } = new List<FloorPresenter>();

        public static StagePresenter Create(Transform parent)
        {
            var prefab = Resources.Load<StagePresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public override void Initialize()
        {
            _model = new StageModel();
            _view = GetComponent<StageView>();

            _floors = new List<FloorPresenter>();

            BindModelEvents();
            BindViewEvents();

            // 初期フロア追加
            foreach (int loop in Enumerable.Range(0, 2))
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

            _isInitialized = true;
        }

        public void AddFloor(FloorModel floor)
        {
            _model.Floors.Add(floor);
        }

        public FloorPresenter GetFloor(int index)
        {
            return (index < _floors.Count) ? _floors[index] : null;
        }

        protected override void BindModelEvents()
        {
            // フロア追加時
            _model.Floors.ObserveAdd()
                .Subscribe(model =>
                {
                    // Presenterを作成
                    FloorPresenter presenter = FloorPresenter.Create(_floorsParent);
                    presenter.transform.SetAsFirstSibling();
                    presenter.Setup(model.Value);
                    presenter.Initialize();
                    _floors.Add(presenter);
                })
                .AddTo(this);
        }

        protected override void BindViewEvents()
        {
        }
    }

}