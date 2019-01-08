using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class BattleEventPoint : EventPointBase
    {
        public string EnemyId { get; private set; }

        public void Setup(string enemyId)
        {
            EnemyId = enemyId;
        }

        public override void OnHit()
        {
            // 敵を生成、バトルマネージャにセット
            EnemyPresenter enemy = EnemyPresenter.Create(transform.parent);
            GameManager.BattleManager.SetEnemy(enemy);

            gameObject.SetActive(false);
        }
    }
}