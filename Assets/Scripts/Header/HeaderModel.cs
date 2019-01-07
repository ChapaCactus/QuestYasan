using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class HeaderModel
    {
        public UserModel UserModel { get; private set; }

        public HeaderModel(HeaderParam param)
        {
            UserModel = param.UserModel;
        }
    }
}