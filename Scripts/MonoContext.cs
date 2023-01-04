using System.Collections.Generic;
using UnityEngine;

namespace MonoOptimization
{
    [AddComponentMenu("MonoOptimization/MonoContext")]
    public class MonoContext : MonoBehaviour
    {
        private readonly List<IAwakeListener> awakeListeners = new();

        private readonly List<IEnableListener> enableListeners = new();

        private readonly List<IStartListener> startListeners = new();

        private readonly List<IFixedUpdateListener> fixedUpdateListeners = new();

        private readonly List<IUpdateListener> updateListeners = new();

        private readonly List<ILateUpdateListener> lateUpdateListeners = new();

        private readonly List<IDisableListener> disableListeners = new();

        private readonly List<IDestroyListener> destroyListeners = new();

        private readonly List<IValidateListener> validateListeners = new();

        public void RegisterObjects(params object[] values)
        {
            for (int i = 0, count = values.Length; i < count; i++)
            {
                var value = values[i];
                this.RegisterObject(value);
            }
        }
        
        public void RegisterObjects(IEnumerable<object> values)
        {
            foreach (var value in values)
            {
                this.RegisterObject(value);
            }
        }
        
        public void RegisterObject(object value)
        {
            if (value is IAwakeListener awakeListener)
            {
                this.awakeListeners.Add(awakeListener);
            }

            if (value is IEnableListener enableListener)
            {
                this.enableListeners.Add(enableListener);
            }

            if (value is IStartListener startListener)
            {
                this.startListeners.Add(startListener);
            }

            if (value is IFixedUpdateListener fixedUpdateListener)
            {
                this.fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (value is IUpdateListener updateListener)
            {
                this.updateListeners.Add(updateListener);
            }

            if (value is ILateUpdateListener lateUpdateListener)
            {
                this.lateUpdateListeners.Add(lateUpdateListener);
            }

            if (value is IDisableListener disableListener)
            {
                this.disableListeners.Add(disableListener);
            }
        }

        public void UnregisterObjects(IEnumerable<object> values)
        {
            foreach (var value in values)
            {
                this.UnregisterObject(value);
            }
        }

        public void UnregisterObject(object value)
        {
            if (value is IAwakeListener awakeListener)
            {
                this.awakeListeners.Remove(awakeListener);
            }

            if (value is IEnableListener enableListener)
            {
                this.enableListeners.Remove(enableListener);
            }

            if (value is IStartListener startListener)
            {
                this.startListeners.Remove(startListener);
            }

            if (value is IFixedUpdateListener fixedUpdateListener)
            {
                this.fixedUpdateListeners.Remove(fixedUpdateListener);
            }

            if (value is IUpdateListener updateListener)
            {
                this.updateListeners.Remove(updateListener);
            }

            if (value is ILateUpdateListener lateUpdateListener)
            {
                this.lateUpdateListeners.Remove(lateUpdateListener);
            }

            if (value is IDisableListener disableListener)
            {
                this.disableListeners.Remove(disableListener);
            }
        }

        public void Clear()
        {
            this.awakeListeners.Clear();
            this.enableListeners.Clear();
            this.startListeners.Clear();
            this.fixedUpdateListeners.Clear();
            this.updateListeners.Clear();
            this.lateUpdateListeners.Clear();
            this.disableListeners.Clear();
        }

        protected virtual void Awake()
        {
            for (int i = 0, count = this.awakeListeners.Count; i < count; i++)
            {
                var listener = this.awakeListeners[i];
                listener.OnAwaked();
            }
        }

        protected virtual void OnEnable()
        {
            for (int i = 0, count = this.enableListeners.Count; i < count; i++)
            {
                var listener = this.enableListeners[i];
                listener.OnEnabled();
            }
        }

        protected virtual void Start()
        {
            for (int i = 0, count = this.startListeners.Count; i < count; i++)
            {
                var listener = this.startListeners[i];
                listener.OnStarted();
            }
        }

        protected virtual void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            for (int i = 0, count = this.fixedUpdateListeners.Count; i < count; i++)
            {
                var listener = this.fixedUpdateListeners[i];
                listener.OnFixedUpdated(deltaTime);
            }
        }


        protected virtual void Update()
        {
            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.updateListeners.Count; i < count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdated(deltaTime);
            }
        }

        protected virtual void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.lateUpdateListeners.Count; i < count; i++)
            {
                var listener = this.lateUpdateListeners[i];
                listener.OnLateUpdated(deltaTime);
            }
        }

        protected virtual void OnDisable()
        {
            for (int i = 0, count = this.disableListeners.Count; i < count; i++)
            {
                var listener = this.disableListeners[i];
                listener.OnDisabled();
            }
        }

        private void OnDestroy()
        {
            for (int i = 0, count = this.destroyListeners.Count; i < count; i++)
            {
                var listener = this.destroyListeners[i];
                listener.OnDestroyed();
            }
        }

        [ContextMenu("Validate")]
        private void Validate()
        {
            for (int i = 0, count = this.validateListeners.Count; i < count; i++)
            {
                var listener = this.validateListeners[i];
                listener.OnValidated();
            }
        }
    }
}