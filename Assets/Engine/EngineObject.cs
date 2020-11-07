using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class EngineObject
    {
        private bool active;

        public event Action Destroy;
        public event Action<bool> ActiveStateChange;

        public bool Active => active;

        public virtual void OnCreate()
        {
            // SetActive(true);
        }

        public virtual void OnDestroy()
        {
            
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void SetActive(bool value)
        {
            active = value;
            if (ActiveStateChange != null)
                ActiveStateChange(active);
        }

        public virtual void DestroyObject()
        {
            OnDestroy();
            if (Destroy != null)
                Destroy();
            Game.Destroy(this);
        }
    }
}