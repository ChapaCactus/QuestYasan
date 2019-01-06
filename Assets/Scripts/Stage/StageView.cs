using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class StageView : MonoBehaviour
    {
        [SerializeField] private Transform _floorsParent;

        public List<FloorPresenter> Floors { get; private set; }

        public void Setup()
        {
            Floors = new List<FloorPresenter>();
        }

        public void AddFloor(FloorModel floor)
        {
            FloorPresenter floorPresenter = FloorPresenter.Create(_floorsParent);
            floorPresenter.Setup(floor);
        }
    }
}