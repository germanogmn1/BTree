using System;

namespace BTree
{
    /// <summary>
    /// AND-like behaviour: Succeed when all succeeded, fails when some fails.
    /// Run one child to finish after the other.
    /// Without finishing last child or failing, a sequence stores the last running child
    /// to immediately return to it on the next update.
    /// </summary>
    public class Sequence : Composite
    {
        private int currentIndex = 0;

        protected override Status Update()
        {
            while (currentIndex < Count) {
                switch (this[currentIndex].Tick()) {
                    case Status.Success:
                        currentIndex++;
                        return Status.Running;
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        currentIndex = 0;
                        return Status.Failure;
                    case Status.Invalid:
                        throw new InvalidOperationException();
                }
            }

            // All succeeded
            currentIndex = 0;
            return Status.Success;
        }
    }
}
