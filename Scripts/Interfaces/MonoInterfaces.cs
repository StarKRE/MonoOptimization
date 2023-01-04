namespace MonoOptimization
{
    public interface IAwakeListener
    {
        void OnAwaked();
    }

    public interface IEnableListener
    {
        void OnEnabled();
    }

    public interface IStartListener
    {
        void OnStarted();
    }
    
    public interface IFixedUpdateListener
    {
        void OnFixedUpdated(float deltaTime);
    }

    public interface IUpdateListener
    {
        void OnUpdated(float deltaTime);
    }
    
    public interface ILateUpdateListener
    {
        void OnLateUpdated(float deltaTime);
    }

    public interface IDisableListener
    {
        void OnDisabled();
    }

    public interface IDestroyListener
    {
        void OnDestroyed();
    }

    public interface IValidateListener
    {
        void OnValidated();
    }
}