using System;

namespace SqlAliaser
{
    /// <summary>
    /// Provides recursion protection for operations that raise events so that
    /// events don't get "runaway".
    /// </summary>
    /// <remarks></remarks>
    public class Latch
    {
        private int _count;

        /// <summary>
        /// Gets the state of the <see cref="Latch" />.
        /// </summary>
        /// <returns><see langword="true" /> if the latch count is 0, <see langword="false" /> otherwise.</returns>
        public bool IsLatched
        {
            get { return (this._count > 0); }
        }

        /// <summary>
        /// Increments the latch count. 
        /// </summary>
        /// <remarks> A latch won't run latch-protected operations while the latch count is 
        /// greater than zero.</remarks>
        public void Increment()
        {
            this._count += 1;
        }

        /// <summary>
        /// Decrements the latch count.
        /// </summary>
        /// <remarks> A latch won't run latch-protected operations while the latch count is 
        /// greater than zero.</remarks>
        public void Decrement()
        {
            this._count -= 1;
        }

        /// <summary>
        /// Runs the given <paramref name="operation" /> inside the latch.
        /// </summary>
        /// <param name="externalLatch">A client-supplied latch.</param>
        /// <param name="operation">The operation to run inside the latch.</param>
        /// <remarks></remarks>
        public void RunInsideLatch(bool externalLatch, Action operation)
        {
            if ((externalLatch))
            {
                return;
            }

            RunInsideLatch(operation);
        }

        /// <summary>
        /// Runs the given <paramref name="operation" /> inside the latch.
        /// </summary>
        /// <param name="operation">The operation to run inside the latch.</param>
        /// <remarks></remarks>
        public void RunInsideLatch(Action operation)
        {
            RunInsideLatch<bool>(() => ExecuteActionAndReturnTrue(operation));
        }

        /// <summary>
        /// Runs the given <paramref name="operation" /> inside the latch.
        /// </summary>
        /// <param name="operation">The operation to run inside the latch.</param>
        /// <remarks></remarks>
        public void RunInsideLatch<T>(Func<T> operation)
        {
            if ((this.IsLatched))
            {
                return;
            }

            Increment();
            try
            {
                operation();
            }
            finally
            {
                Decrement();
            }
        }

        /// <summary>
        /// Runs the given <paramref name="operation" /> if this <see cref="Latch" />
        /// isn't currently latched.
        /// </summary>
        /// <param name="operation">The operation to run.</param>
        /// <remarks></remarks>
        public void RunIfNotLatched(Action operation)
        {
            if ((this.IsLatched))
            {
                return;
            }

            operation();
        }

        public IDisposable Bind()
        {
            if ((this.IsLatched))
            {
                throw new InvalidOperationException("Latch is latched.  Canot Bind");
            }

            return new DisposableLatchOperation(this);
        }

        private bool ExecuteActionAndReturnTrue(Action operation)
        {
            operation();
            return true;
        }

        private class DisposableLatchOperation : IDisposable
        {
            private readonly Latch _latch;

            // To detect redundant calls
            private bool _isDisposed = false;

            public DisposableLatchOperation(Latch latch)
            {
                this._latch = latch;
                this._latch.Increment();
            }
            #region " IDisposable Support "

            protected virtual void Dispose(bool disposing)
            {
                if (!this._isDisposed)
                {
                    if (disposing)
                    {
                        // TODO: free other state (managed objects).
                        this._latch.Decrement();
                    }

                    // TODO: free your own state (unmanaged objects).
                    // TODO: set large fields to null.
                }
                this._isDisposed = true;
            }

            // This code added by Visual Basic to correctly implement the disposable pattern.
            void IDisposable.Dispose()
            {
                // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion

        }
    }
}