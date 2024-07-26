using Sirenix.OdinInspector;
using UnityEngine;
using System;

namespace Lulu.SimpleFSM
{
    public class StateManager : MonoBehaviour
    {
        [ReadOnly][SerializeField] Type nextStateType;
        [ReadOnly][SerializeField] Type currentStateType;
        State currentStateObject;

        public void SetState<T>() where T : State
        {
            Type newType = typeof(T);
            if(nextStateType == newType)
                return;
            nextStateType = newType;
        }

        private void _SetState()
        {
            if(nextStateType == currentStateType)
                return;
            if(currentStateObject != null)
                Destroy(currentStateObject);

            currentStateObject = (State)gameObject.AddComponent(nextStateType);
            currentStateObject.manager = this;
            nextStateType = null;
        }

        void FixedUpdate()
        {
            if(nextStateType == null)
                return;
            _SetState();
        }
    }
}
