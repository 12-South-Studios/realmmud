using Realm.Data.Definitions;
using Realm.Library.Common;

namespace Realm.Entity.Entities
{
    /// <summary>
    ///
    /// </summary>
    public class Mobile : Biota, IMobile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public Mobile(long id, string name, Definition def)
            : base(id, name, def)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public MobileDef MobileDef { get { return Definition.CastAs<MobileDef>(); } }

        public override Globals.Globals.PositionTypes Position
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override Globals.Globals.GenderTypes Gender
        {
            get { return MobileDef.GenderType; }
        }

        public override RaceDef Race
        {
            get { return MobileDef.Race; }
        }

        public override Globals.Globals.MovementModeTypes Movement
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        /*

                #region GameEntity

                //public override void OnInit(DictionaryAtom definition)
                public override void OnInit()
                {
                //    base.OnInit();

                    var parent = Parent as MobTemplate;
                    if (parent.IsNull()) return;

                    Flags.FlagList = Parent.GetFlagList();

                    var flag = (Flag)DataManager.Get("Flags", "instance");
                    if (flag.IsNull())
                    {
                        Log.ErrorFormat(ErrorResources.ERR_FLAG_NOT_FOUND, "instance");
                        return;
                    }
                    Flags.SetFlag(flag.Abbrev);
                    Properties.SetProperty("current_hit_points", StatisticHandler.MaximumHealth);
                    Bits.SetBits(Parent.Bits.GetBits);

                    // generate new items and wear them
                    foreach (var item in parent.ItemsToEquip)
                        Inventory.EquipItem(item);

                    // generate new items and put them into inventory
                    foreach (var item in parent.ItemsInInventory)
                        Inventory.HoldItem(item);
                }

                new public string Name
                {
                    get { return Parent.IsNotNull() ? Parent.Name : string.Empty; }
                    set { }
                }
                new public string Description
                {
                    get { return Parent.IsNotNull() ? Parent.Description : string.Empty; }
                    set { }
                }
                new public string LongName
                {
                    get { return Parent.IsNotNull() ? Parent.LongName : string.Empty; }
                    set { }
                }
                new public Globals.Globals.SizeTypes Size
                {
                    get { return Parent.IsNotNull() ? Parent.Size : Globals.Globals.SizeTypes.Medium; }
                    set { }
                }

                #endregion GameEntity

                #region IBiota

                override public Globals.Globals.GenderTypes Gender
                {
                    get
                    {
                        var parent = Parent as MobTemplate;
                        return parent.IsNull()
                            ? Globals.Globals.GenderTypes.Neuter
                            : EnumerationExtensions.GetEnum<Globals.Globals.GenderTypes>(parent.Properties.GetProperty<string>("gender"));
                    }
                }

                #endregion IBiota

                #region IHandler

                /// <summary>
                /// Returns the property by the given name on the MobInstance,
                /// or if it doesn't exist it returns the property from the
                /// MobTemplate parent.
                /// </summary>
                new public object GetProperty(string aName)
                {
                    var prop = base.GetProperty(aName);
                    if (prop.IsNull()) return null;
                    return Parent.IsNotNull() ? Parent.Properties.GetProperty<object>(aName) : null;
                }

                new public string GetStringProperty(string aName)
                {
                    var prop = base.GetProperty(aName);
                    if (prop.IsNull()) return string.Empty;
                    return Parent.IsNotNull() ? Parent.Properties.GetProperty<string>(aName) : string.Empty;
                }

                new public int GetIntProperty(string aName)
                {
                    var prop = base.GetProperty(aName);
                    if (prop.IsNull()) return 0;
                    return Parent.IsNotNull() ? Parent.Properties.GetProperty<int>(aName) : 0;
                }

                new public long GetLongProperty(string name)
                {
                    var prop = base.GetProperty(name);
                    if (prop.IsNull()) return 0;
                    return Parent.IsNotNull() ? Parent.Properties.GetProperty<long>(name) : 0;
                }

                #endregion IHandler

                /*public void OnEntitySpaceEnter(MUDEventArgs e)
                {
                    GameEntityTemplate entity = e.Object as GameEntityTemplate;
                    Space Space = e.Sender as Space;

                    //// Not my current location, why am I receiving this?
                    if (Space != Location)
                    {
                        //// TODO: Remove me as a listener from both Space and entity
                        return;
                    }

                    //// Currently engaged in combat so I don't care
                    if (IsFighting)
                    {
                        return;
                    }

                    ////PushState(new AIFightState((Biota)msg._SourceObject, this));
                }*/

        /*public void OnEntitySpaceLeave(MUDEventArgs e)
        {
            GameEntityTemplate entity = e.Object as GameEntityTemplate;
            Space Space = e.Sender as Space;

            //// Not my current location, why am I receiving this?
            if (Space != Location)
            {
                //// TODO: Remove me as a listener from both Space and entity
                return;
            }

            Space r = Location as Space;
            if (r.UserCount > 0)
            {
                return;
            }

            //// My current state isn't a fight state so I don't care
            if (!CurrentState.Name.Equals("AIFightState", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            ////PopState();
        }*/

        /*public void OnCombatHit(MUDEventArgs e)
        {
            if (IsDead)
            {
                LogSystem("onCombatHit", "I'm dead!");
            }
        }*/
    }
}