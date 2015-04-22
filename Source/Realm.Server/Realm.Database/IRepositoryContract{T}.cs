// ---------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryContract{T}.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <license>
//   This code has been authored by a Microsoft employee, and is therefore owned entirely by Microsoft.
//   You may use it the same way as any code you authored yourself (e.g., you may modify it), but only
//   as part of test and development tools – you may not incorporate the original code or your modifications
//   into products that you are working on. If you would like to incorporate the code into a product you
//   are working on, please do your own implementation after reviewing the code and understanding the concepts
//   behind it, or contact the project owner to understand why he or she didn’t intend for the code to be put
//   into products. The code is Microsoft confidential information, and therefore shouldn’t be made available
//   to anyone other than Microsoft FTEs or contractors that are performing work for Microsoft. If you would
//   like to distribute this code (or any of your modifications) outside of Microsoft, talk to your LCA contacts.
// </license>
// ---------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Realm.Database
{
    [ContractClassFor( typeof( IRepository<> ) )]
    internal abstract class IRepositoryContract<T> : IRepository<T> where T : class
    {
        #region IReadOnlyRepository<T> Members

        Task<IEnumerable<T>> IReadOnlyRepository<T>.GetAsync( Func<IQueryable<T>, IQueryable<T>> queryShaper, CancellationToken cancellationToken )
        {
            return null;
        }

        Task<TResult> IReadOnlyRepository<T>.GetAsync<TResult>( Func<IQueryable<T>, TResult> queryShaper, CancellationToken cancellationToken )
        {
            return null;
        }

        #endregion

        #region IRepository<T> Members

        bool IRepository<T>.HasPendingChanges
        {
            get
            {
                return default( bool );
            }
        }

        void IRepository<T>.Add( T item )
        {
            Contract.Requires<ArgumentNullException>( item != null, "item" );
        }

        void IRepository<T>.Remove( T item )
        {
            Contract.Requires<ArgumentNullException>( item != null, "item" );
        }

        void IRepository<T>.Update( T item )
        {
            Contract.Requires<ArgumentNullException>( item != null, "item" );
        }

        void IRepository<T>.DiscardChanges()
        {
        }

        Task IRepository<T>.SaveChangesAsync( CancellationToken cancellationToken )
        {
            Contract.Ensures( Contract.Result<Task>() != null );
            return null;
        }

        #endregion

        #region INotifyPropertyChanged Members

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        #endregion
    }
}
