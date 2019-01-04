using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public static class GameManager
    {
        public static BattleManager BattleManager { get; private set; } = new BattleManager();
        public static UniqueIdManager UniqueIdManager { get; private set; } = new UniqueIdManager();

        public static void Initialize()
        {
            BattleManager.Initialize();
            UniqueIdManager.Initialize();
        }
    }
}