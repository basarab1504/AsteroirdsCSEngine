using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameObject : EngineObject
    {
        private Dictionary<Type, Component> components = new Dictionary<Type, Component>();

        public IEnumerable<Component> Components => components.Values;
        public Transform Transform => GetComponent<Transform>();

        public sealed override void SetActive(bool value)
        {
            foreach (var c in Components)
                c.SetActive(value);
            base.SetActive(value);
        }

        public sealed override void DestroyObject()
        {
            foreach (var component in components)
            {
                component.Value.DestroyObject();
                component.Value.Parent = null;
            }
            components.Clear();
            base.DestroyObject();
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public void Rotate(float angle)
        {
            Transform.Direction = Transform.Direction.Rotate(angle);
        }

        public void Move(Vector2 direction)
        {
            Transform.Position += direction;
        }

        public T GetComponent<T>() where T : Component
        {
            if (components.ContainsKey(typeof(T)))
                return (T)components[typeof(T)];
            return null;
        }

        public T AddComponent<T>() where T : Component
        {
            var created = Game.Create<T>();
            components.Add(typeof(T), created);
            // created.Destroy += RemoveComponent<T>;
            created.Parent = this;
            return created;
        }

        public void RemoveComponent<T>() where T : Component
        {
            if (components.ContainsKey(typeof(T)))
            {
                var component = components[typeof(T)];
                component.Parent = null;
                components.Remove(typeof(T));
                component.DestroyObject();
            }
        }
    }
}