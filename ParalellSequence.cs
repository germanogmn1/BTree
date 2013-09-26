using System;

namespace BTree
{
    /// <summary>
    /// Try to run all children behaviours in pararell.
    /// AND-like behaviour: Succeed when all are successful or running, fails and stops when one fails.
    /// </summary>
    public class ParalellSequence : Composite
    {
        protected override Status Update()
        {
            foreach (var child in this) {
                Status status = child.Tick();

                if (status == Status.Failure) {
                    return Status.Failure;
                }
                else if (status == Status.Invalid) {
                    throw new InvalidOperationException();
                }
            }

            // All suceeded
            return Status.Success;
        }
    }
}
