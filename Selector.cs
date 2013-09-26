using System;
using System.Collections.Generic;

namespace BTree
{
    /// <summary>
    /// OR-like behaviour: Succeeds if one child succeed or fails when all failed.
    /// Run one child to finish after the other.
    /// </summary>
    public class Selector : Composite
    {
        private int currentIndex = 0;

        protected override Status Update()
        {
            while (currentIndex < Count) {
                switch (this[currentIndex].Tick()) {
                    case Status.Success:
                        currentIndex = 0;
                        return Status.Success;
                    case Status.Running:
                        return Status.Running;
                    case Status.Failure:
                        currentIndex++;
                        return Status.Running;
                    case Status.Invalid:
                        throw new InvalidOperationException();
                }
            }

            // All failed
            currentIndex = 0;
            return Status.Failure;
        }
    }
}
