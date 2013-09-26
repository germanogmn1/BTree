using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace BTree
{
    /// <summary>
    /// Base class for behaviours that are composed by many children behaviours.
    /// </summary>
    public abstract class Composite : Behaviour, IEnumerable<Behaviour>
    {
        private List<Behaviour> children = new List<Behaviour>();

        #region Collection Interface

        /// <summary>
        /// Exposed only in order to allow collection initialization syntax.
        /// Should not be used after this behaviour is started.
        /// </summary>
        public void Add(Behaviour item)
        {
            if (status != Status.Invalid) {
                throw new InvalidOperationException();
            }

            children.Add(item);
        }

        IEnumerator<Behaviour> IEnumerable<Behaviour>.GetEnumerator()
        {
            return children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<Behaviour>).GetEnumerator();
        }

        protected Behaviour this[int index] {
            get { return children[index]; }
        }

        protected int Count {
            get { return children.Count; }
        }

        #endregion
    }
}
