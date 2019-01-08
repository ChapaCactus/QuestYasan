using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class EnemyPresenter : PresenterBase
    {
        private const string PrefabPath = "Prefabs/Enemy";

        public static EnemyPresenter Create(Transform parent)
        {
            var prefab = Resources.Load<EnemyPresenter>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public override void Initialize(IParameter param)
        {
        }

        protected override void BindModelEvents()
        {
        }

        protected override void BindViewEvents()
        {
        }
    }
}