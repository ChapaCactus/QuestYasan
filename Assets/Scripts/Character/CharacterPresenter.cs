using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    [RequireComponent(typeof(CharacterView))]
    public class CharacterPresenter : MonoBehaviour
    {
        private CharacterModel _model;
        private CharacterView _view;
    }
}