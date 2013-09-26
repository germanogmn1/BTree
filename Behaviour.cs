namespace BTree
{
    public enum Status
    {
        Invalid, // null status
        Success,
        Failure,
        Running,
    }

    public abstract class Behaviour
    {
        protected Status status = Status.Invalid;

        protected virtual void Start() { }
        protected virtual void Terminate() { }

        protected abstract Status Update();

        public Status Tick()
        {
            if (status == Status.Invalid) {
                Start();
            }

            status = Update();

            if (status != Status.Running) {
                Terminate();
            }

            return status;
        }
    }
}
