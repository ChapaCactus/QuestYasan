using System;
using System.Collections.Generic;
using UnityEngine;
using Google2u;

namespace CCG
{
    public class BattleEventPoint : EventPointBase
    {
        private const string PrefabPath = "Prefabs/BattleEventPoint";

        public float ProgressThreshold { get; private set; }

        public EnemyMaster.rowIds EnemyId { get; private set; }
        public EnemyMasterRow EnemyMasterRow { get; private set; }

        public static BattleEventPoint Create(Transform parent)
        {
            var prefab = Resources.Load<BattleEventPoint>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        public void Setup(EnemyMaster.rowIds enemyId, float progressThreshold)
        {
            EnemyId = enemyId;
            EnemyMasterRow = EnemyMaster.Instance.GetRow(EnemyId);
            ProgressThreshold = progressThreshold;
        }

        public override void OnHit()
        {
            // 敵を生成、バトルマネージャにセット
            EnemyPresenter enemy = EnemyPresenter.Create(transform.parent);
            var param = new EnemyParam
            {
                EnemyId = EnemyId,
                EnemyMasterRow = EnemyMasterRow,

            };
            enemy.Initialize(param);
            GameManager.BattleManager.SetEnemy(enemy);

            gameObject.SetActive(false);
        }
    }
}