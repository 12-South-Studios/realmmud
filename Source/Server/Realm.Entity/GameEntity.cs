using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Data.Interfaces;
using Realm.Entity.Contexts;
using Realm.Entity.Interfaces;
using Realm.Event;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Data;
using Realm.Library.Common.Extensions;
using Realm.Library.Common.Logging;
using Realm.Library.Common.Objects;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public abstract class GameEntity : Library.Common.Objects.Entity, IGameEntity, IExaminable, IWizardExaminable
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"> </param>
        protected GameEntity(long id, string name, Definition def)
            : base(id, name)
        {
            Contexts = new List<IContext>();
            Definition = def;
        }

        /// <summary>
        ///
        /// </summary>
        public Definition Definition { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IList<IContext> Contexts { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string LongName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string PluralName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual IGameEntity Location { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected DictionaryAtom InitializationAtom { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual void OnInit(DictionaryAtom initAtom)
        {
            InitializationAtom = initAtom;
            EventManager = initAtom.GetObject("EventManager").CastAs<EventManager>();
            StaticDataManager = initAtom.GetObject("StaticDataManager").CastAs<StaticDataManager>();
            EntityManager = initAtom.GetObject("EntityManager").CastAs<EntityManager>();
            Logger = initAtom.GetObject("Logger").CastAs<LogWrapper>();

            Contexts.Add(new FlagContext(this));
            Contexts.Add(new TagContext(this));
            Contexts.Add(new BitContext(this));
            Contexts.Add(new PropertyContext(this));
        }

        protected IEventManager EventManager { get; private set; }

        protected IStaticDataManager StaticDataManager { get; private set; }

        protected IEntityManager EntityManager { get; private set; }

        protected LogWrapper Logger { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public IContext GetContext(string typeName)
        {
            return Contexts.FirstOrDefault(context => context.GetType().Name
                                                          .Equals(typeName, StringComparison.OrdinalIgnoreCase));
        }

        #region IExaminable

        public virtual string Examine()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("  Flags: {0}{1}", this.GetFlagContext().Flags, Environment.NewLine);
            sb.AppendFormat("  Type: {0}{1}", GetType(), Environment.NewLine);
            sb.AppendFormat("  Bits: {0}{1}", this.GetBitContext().GetBits, Environment.NewLine);

            var properties = this.GetPropertyContext();
            if (properties.Count > 0)
            {
                properties.PropertyKeys.Where(properties.IsVisible)
                          .ToList()
                          .ForEach(key => sb.AppendFormat("  {0}: {1}{2}",
                                                          key.CapitalizeFirst(),
                                                          properties.GetProperty<string>(key),
                                                          Environment.NewLine));
            }

            return sb.ToString();
        }

        #endregion IExaminable

        #region IWizardExaminable

        public virtual string WizExamine()
        {
            var sb = new StringBuilder();
            var properties = this.GetPropertyContext();

            if (properties.Count > 0)
            {
                properties.PropertyKeys.ToList().ForEach(key => sb.AppendFormat("   {0}[{1}]: {2}{3}",
                                                                                key.CapitalizeFirst(),
                                                                                properties.GetPropertyBits(key),
                                                                                properties.GetProperty<string>(key),
                                                                                Environment.NewLine));
            }
            return sb.ToString();
        }

        #endregion IWizardExaminable
    }
}