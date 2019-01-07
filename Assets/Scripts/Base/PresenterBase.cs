using UnityEngine;

namespace CCG
{
    public abstract class PresenterBase : MonoBehaviour
    {
        protected bool _isInitialized = false;

        public virtual void Initialize()
        {
            _isInitialized = true;
        }

        public virtual void Initialize(IParameter param)
        {
            Initialize();
        }

        protected abstract void BindModelEvents();
        protected abstract void BindViewEvents();
    }

}