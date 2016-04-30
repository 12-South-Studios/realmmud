// ----------------------------------------------------------------------
// <copyright file="HelpManager.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
// </copyright>
// <summary>
//
// </summary>
// ------------------------------------------------------------------------

using Ninject;
using Realm.Data.Interfaces;
using Realm.Event;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Events;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Help
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class HelpManager : GameSingleton, IHelpManager
    {
        private DictionaryAtom _initAtom;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helpRepository"></param>
        /// <param name="helpLoader"></param>
        public HelpManager(IHelpRepository helpRepository, IHelpLoader helpLoader)
        {
            HelpRepository = helpRepository;
            HelpLoader = helpLoader;
        }

        /// <summary>
        /// 
        /// </summary>
        [Inject]
        public IEventManager EventManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Inject]
        public ILogWrapper Log { get; set; }

        [Inject]
        public IStaticDataManager StaticDataManager { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IHelpRepository HelpRepository { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IHelpLoader HelpLoader { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initAtom"></param>
        public void OnInit(DictionaryAtom initAtom)
        {
            Validation.IsNotNull(initAtom, "initAtom");

            EventManager.RegisterListener(this, typeof(OnGameInitialize), Instance_OnGameInitialize);
            _initAtom = initAtom;
        }

        /// <summary>
        /// Handles game initialization actions
        /// </summary>
        public override void Instance_OnGameInitialize(RealmEventArgs args)
        {
            Log.DebugFormat("{0} received Event OnGameInitialize", GetType());

            HelpLoader.Load(StaticDataManager, HelpRepository);

            base.Instance_OnGameInitialize(args);
        }
    }
}
