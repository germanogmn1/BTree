using System;

namespace BTree
{
    /// <summary>
    /// 
    /// </summary>
    public class ParalellSelector : Composite
    {
        protected override Status Update()
        {
            foreach (var child in this) {
                switch (child.Tick()) {
                    case Status.Success:
                    case Status.Running:
                        return status;
                    case Status.Invalid:
                        throw new InvalidOperationException();
                }
            }

            // All failed
            return Status.Failure;
        }
    }
}
