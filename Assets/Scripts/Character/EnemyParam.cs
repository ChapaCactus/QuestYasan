using System;
using System.Collections.Generic;
using UnityEngine;
using Google2u;

namespace CCG
{
    public class EnemyParam : IParameter
    {
        public EnemyMaster.rowIds EnemyId { get; set; }
        public EnemyMasterRow EnemyMasterRow { get; set; }
    }
}