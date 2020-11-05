using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Component
    {
        public event Action<bool> ActiveStateChange;
        public event Action Destroy;

        private Dictionary<Type, Component> components = new Dictionary<Type, Component>();
        public IEnumerable<Component> Components => components.Values;
        private Component parent;
        private bool active;

        public Component Parent => parent;

        public bool Active => active;
        public void SetActive(bool value)
        {
            active = value;

            foreach (var c in components.Values)
                c.SetActive(value);

            if (ActiveStateChange != null)
                ActiveStateChange(active);
        }

        //для инициализаций начальных чтобы к иниц можно было обращаться (создание - здесь)
        public virtual void OnCreate()
        {
            // SetActive(true);
        }

        public virtual void OnDestroy()
        {

        }

        //для инициализации созданных (создание компонентов - не здесь)
        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public T GetComponent<T>() where T : Component
        {
            if (components.ContainsKey(typeof(T)))
                return (T)components[typeof(T)];
            return null;
        }

        public T AddComponent<T>() where T : Component, new()
        {
            var created = Game.Create<T>();
            components.Add(typeof(T), created);
            created.parent = this;
            return created;
        }

        public void RemoveComponent<T>() where T : Component
        {
            var component = components[typeof(T)];
            component.parent = null;
            components.Remove(typeof(T));
            Game.Destroy(component);
        }

        public void DestroyComponent()
        {
            OnDestroy();
            foreach (var component in components)
            {
                component.Value.parent = null;
                component.Value.DestroyComponent();
            }
            components.Clear();
            if (Destroy != null)
                Destroy();
            Game.Destroy(this);
        }
    }
}