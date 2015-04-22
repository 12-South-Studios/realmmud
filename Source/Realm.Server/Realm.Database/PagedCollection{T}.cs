using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Realm.Database
{
    /// <summary>
    /// Represents a read-only collection of paged items.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type">item</see> of item returned by the result.</typeparam>
    public class PagedCollection<T> : ReadOnlyObservableCollection<T>
    {
        private long _totalCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedCollection{T}"/> class.
        /// </summary>
        /// <param name="sequence">The <see cref="IEnumerable{T}"/> containing the current data page of items.</param>
        [SuppressMessage( "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Validated by a code contract." )]
        protected PagedCollection( IEnumerable<T> sequence )
            : this( new ObservableCollection<T>( sequence ) )
        {
            Contract.Requires( sequence != null );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedCollection{T}"/> class.
        /// </summary>
        /// <param name="collection">The <see cref="ObservableCollection{T}"/> containing the current data page of items.</param>
        [SuppressMessage( "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Validated by a code contract." )]
        protected PagedCollection( ObservableCollection<T> collection )
            : this( collection, collection.Count )
        {
            Contract.Requires( collection != null );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedCollection{T}"/> class.
        /// </summary>
        /// <param name="sequence">The <see cref="IEnumerable{T}"/> containing the current data page of items.</param>
        /// <param name="totalCount">The total number of items.</param>
        public PagedCollection( IEnumerable<T> sequence, long totalCount )
            : this( new ObservableCollection<T>( sequence ), totalCount )
        {
            Contract.Requires( sequence != null );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedCollection{T}"/> class.
        /// </summary>
        /// <param name="collection">The <see cref="ObservableCollection{T}"/> containing the current data page of items.</param>
        /// <param name="totalCount">The total number of items.</param>
        [SuppressMessage( "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "Validated by a code contract." )]
        public PagedCollection( ObservableCollection<T> collection, long totalCount )
            : base( collection )
        {
            Contract.Requires( collection != null );
            Contract.Requires( totalCount >= collection.Count );
            this._totalCount = totalCount;
        }

        /// <summary>
        /// Gets or sets the total count of all items.
        /// </summary>
        /// <value>The total count of all items.</value>
        public long TotalCount
        {
            get
            {
                Contract.Ensures( Contract.Result<long>() >= 0L );
                return this._totalCount;
            }
            protected set
            {
                Contract.Requires( value >= 0 );
                this._totalCount = value;
            }
        }
    }
}