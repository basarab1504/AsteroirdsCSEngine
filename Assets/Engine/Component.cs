using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Component : EngineObject
    {
        public IEnumerable<Component> Components => Parent.Components;
        public Transform Transform => Parent.Transform;
        public GameObject Parent { get; set; }

        public virtual T GetComponent<T>() where T : Component
        {
            return Parent.GetComponent<T>();
        }

        public virtual T AddComponent<T>() where T : Component, new()
        {
            return Parent.AddComponent<T>();
        }

        public virtual void RemoveComponent<T>() where T : Component
        {
            Parent.RemoveComponent<T>();
        }
    }
}