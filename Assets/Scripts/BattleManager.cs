using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class BattleManager
    {
        public UserModel UserModel { get; private set; }
        public HandsPresenter HandPresenter { get; private set; }

        public void Initialize()
        {
            UserModel = new UserModel();

            HandPresenter = HandsPresenter.Create(MainCanvas.I.UIParent);
            HandPresenter.Setup(UserModel.Hand);
        }
    }
}