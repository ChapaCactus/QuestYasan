using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class HeaderModel
    {
        public int Gold { get; private set; }

        public HeaderModel(HeaderParam param)
        {
            Gold = param.gold;
        }
    }
}