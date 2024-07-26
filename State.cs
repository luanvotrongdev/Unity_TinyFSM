using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lulu.SimpleFSM
{
    public abstract class State : MonoBehaviour
    {
        protected virtual void Start()
        {
            OnEnter();
        }

        protected virtual void Update()
        {
            OnUpdate();
        }

        protected virtual void OnDestroy()
        {
            OnExit();
        }

        public abstract void OnEnter();

        public abstract void OnUpdate();

        public abstract void OnExit();

        public StateManager manager;
    }
}
