using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class UserModel
    {
        public DeckModel Deck { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserModel()
        {
        }
    }
}