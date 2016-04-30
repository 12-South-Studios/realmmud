//// ----------------------------------------------------------------------
//// <copyright file="ContainerItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Linq;
//using System.Text;
//using Realm.Library.Common;
//using Realm.Library.Network;
//using Realm.Server.Factories;
//using Realm.Library.Network.Mxp;

//
//namespace Realm.Server.Item
//
//{
//    public class ContainerItemInstance : ItemInstance
//    {
//        public ContainerItemInstance(long id, ContainerItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "container");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);
//            Bits.SetBit(Globals.Globals.ItemBits.IsClosed);

//            var parent = Parent as ContainerItemTemplate;
//            if (parent.IsNull()) return;

//            foreach (var itemId in parent.Contents)
//            {
//                var template = EntityManager.LuaGetTemplate(itemId) as ItemTemplate;
//                var factory = new GameItemFactory();
//                var instance = factory.CreateInstance(string.Empty, template) as ItemInstance;
//                if (instance.IsNull())
//                {
//                    // TODO: : error, invalid item
//                    continue;
//                }

//                Game.SetManagerReferences(instance);
//                Contents.AddEntity(instance);
//                Log.InfoFormat("Added ItemInstance[{0}] to Container[{1}]", instance.ID, ID);
//            }
//        }

//        public bool IsCloseable
//        {
//            get
//            {
//                var parent = Parent as ContainerItemTemplate;
//                return parent.IsNotNull() && parent.IsCloseable;
//            }
//        }

//        public int VolumeLimit
//        {
//            get 
//            { 
//                var parent = Parent as ContainerItemTemplate;
//                return parent.IsNotNull() ? parent.VolumeLimit : 0;
//            }
//        }

//        public int WeightLimit
//        {
//            get
//            {
//                var parent = Parent as ContainerItemTemplate;
//                return parent.IsNotNull() ? parent.WeightLimit : 0;
//            }
//        }

//        public Globals.Globals.SizeTypes MouthSize
//        {
//            get
//            {
//                var parent = Parent as ContainerItemTemplate;
//                return parent.IsNotNull() ? parent.MouthSize : Globals.Globals.SizeTypes.Medium;
//            }
//        }

//        public bool IsClosed
//        {
//            get
//            {
//                return IsCloseable && Bits.HasBit(Globals.Globals.ItemBits.IsClosed);
//            }
//            set
//            {
//                if (!IsCloseable) return;
//                if (value)
//                    Bits.SetBit(Globals.Globals.ItemBits.IsClosed);
//                else
//                    Bits.UnsetBit(Globals.Globals.ItemBits.IsClosed);
//            }
//        }

//        public void Open()
//        {
//            IsClosed = false;
//        }

//        public void Close()
//        {
//            IsClosed = true;
//        }

//        public int CalculateVolume()
//        {
//            return Contents.Entities.OfType<ItemInstance>().Sum(item => item.Volume);
//        }

//        public int CalculateWeight()
//        {
//            return Contents.Entities.OfType<ItemInstance>().Sum(item => item.Weight);
//        }

//        public long AddItemToContents(long templateId, int quantity)
//        {
//            var template = EntityManager.LuaGetTemplate(templateId) as ItemTemplate;
//            if (null == template) return 0;

//            var factory = new GameItemFactory();
//            var item = factory.CreateInstance(string.Empty, template) as ItemInstance;
//            if (item.IsNull()) return 0;

//            Game.SetManagerReferences(item);
//            item.StackSize = quantity;
//            Contents.AddEntity(item);
//            return item.ID;
//        }

//        public override string Explore(IGameEntity entity)
//        {
//            var sb = new StringBuilder();
//            if (IsClosed)
//            {
//                sb.Append("#con_closed#");
//                sb.Append(Environment.NewLine);
//                sb = CommandManager.ParseString(sb);
//                return sb.ToString();
//            }

//            sb.Append("#con_contents#");
//            sb.Append(Environment.NewLine);
//            foreach (var obj in Contents.Entities)
//            {
//                if (entity.Flags.IsAdmin())
//                {
//                    sb.AppendFormat("  {0} (#{1}{2}{3}){4}", entity.Name, ("WizItem '" + entity.ID + "'").MxpTag(),
//                        entity.ID, entity.GetFlags(), "/WizItem".MxpTag());
//                }
//                else
//                    sb.AppendFormat("  {0}{1}", entity.Name, Environment.NewLine);
//            }
//            return sb.ToString();
//        }

//        public override string Save(bool toggle = false)
//        {
//            var sb = new StringBuilder();
//            sb.Append(base.Save(toggle));
//            sb.Append("\nif (id ~= nil) then");
//            sb.Append("\n    item.this = getEntityByID(id);");
//            sb.Append("\n    if (item ~= nil) then");

//            if (IsClosed)
//                sb.Append("\n        item.this:SetBit(ItemBits.IsClosed);");

//            foreach (var item in Contents.Entities.OfType<ItemInstance>())
//                sb.AppendFormat("\n        item.this:AddItemToContents({0}, {1}); --{2}", item.Parent.ID, item.StackSize, item.Name);

//            sb.Append("\n    end");
//            sb.Append("\nend");

//            return sb.ToString();
//        }
//    }
//}
