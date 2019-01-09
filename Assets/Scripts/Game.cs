using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public static class Game
    {
        public static StageManager Stage { get; private set; } = new StageManager();
        public static UniqueIdManager UniqueIdManager { get; private set; } = new UniqueIdManager();

        public static void Initialize()
        {
            Stage.Initialize();
            UniqueIdManager.Initialize();
        }
    }
}