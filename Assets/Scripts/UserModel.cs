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
        /// 手札
        /// </summary>
        public HandModel Hand { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UserModel()
        {
        }

        /// <summary>
        /// このユーザーターン開始時
        /// </summary>
        public void OnStartUserTurn()
        {

        }
    }
}