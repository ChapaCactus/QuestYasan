using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class BattleManager
    {
        public UserModel Player { get; private set; }

        public void Initialize()
        {
            Player = new UserModel();
        }
    }
}