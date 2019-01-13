using System;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using DG.Tweening;

namespace CCG
{
    public class DamageText : MonoBehaviour
    {
        private const string PrefabPath = "Prefabs/DamageText";

        public static DamageText Create(Transform parent)
        {
            var prefab = Resources.Load<DamageText>(PrefabPath);
            return Instantiate(prefab, parent);
        }

        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(string text)
        {
            _text.text = text;

            var seq = DOTween.Sequence();

            seq.Append(_text.DOFade(0, 0.5f)
                .SetDelay(0.5f));
            seq.Join(_text.transform.DOLocalMoveY(10, 0.4f)
                .SetRelative());
            seq.OnComplete(() => Destroy(gameObject));
        }
    }
}