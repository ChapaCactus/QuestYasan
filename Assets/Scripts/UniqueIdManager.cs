using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class UniqueIdManager
    {
        // TODO: 乱数取得にする
        private int _number;

        public void Initialize()
        {
            _number = 0;
        }

        public int GetNewId()
        {
            return _number++;
        }
    }
}