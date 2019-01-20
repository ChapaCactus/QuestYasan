using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public static class DamageTextManager
    {
        public static void CreateText(int damage, Vector2 position)
        {
            var parent = MainCanvas.I.UIParent;
            DamageText text = DamageText.Create(parent);
            text.transform.position = position;

            text.SetText(damage.ToString());
        }
    }
}