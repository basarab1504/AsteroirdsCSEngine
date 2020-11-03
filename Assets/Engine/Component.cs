using System;
using System.Collections.Generic;

namespace Asteroids
{
    public abstract class Component
    {
        public event Action<bool> OnActiveStateChange;

        private Dictionary<Type, Component> components = new Dictionary<Type, Component>();
        private Component parent;
        private bool active;

        public Component Parent => parent;

        public bool Active => active;
        public void SetActive(bool value)
        {
            active = value;
            foreach (var c in components.Values)
                c.SetActive(value);
            OnActiveStateChange(active);
        }

        //для инициализаций начальных чтобы к иниц можно было обращаться (создание - здесь)
        public virtual void Awake()
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
            return (T)components[typeof(T)];
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

        public void Destroy()
        {
            foreach (var component in components)
            {
                component.Value.parent = null;
                Game.Destroy(component.Value);
                components.Remove(component.Key);
            }
            Game.Destroy(this);
        }
    }
}