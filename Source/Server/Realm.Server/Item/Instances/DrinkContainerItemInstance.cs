//// ----------------------------------------------------------------------
//// <copyright file="DrinkContainerItemInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
////     subject to the Microsoft Public License.  All other rights reserved.
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using System;
//using System.Text;
//using Realm.Library.Common;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.Item
//// ReSharper restore CheckNamespace
//{
//    public class DrinkContainerItemInstance : ItemInstance
//    {
//        public DrinkContainerItemInstance(long id, DrinkContainerItemTemplate parent)
//            : base(id, parent)
//        {
//        }

//       // public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag) DataManager.Get("Flags", "drink container");
//            if (flag.IsNull()) return;
//            Flags.SetFlag(flag.Abbrev);

//            var parent = Parent as DrinkContainerItemTemplate;
//            if (parent.IsNull()) return;
//            FilledWith = parent.FilledWith;
//            CurrentCharges = parent.MaxCharges;
//        }
//        public bool IsCloseable
//        {
//            get
//            {
//                var parent = Parent as DrinkContainerItemTemplate;
//                return parent.IsNotNull() && parent.IsCloseable;
//            }
//        }

//        public int MaxCharges
//        {
//            get
//            {
//                var parent = Parent as DrinkContainerItemTemplate;
//                return parent.IsNotNull() ? parent.MaxCharges : 0;
//            }
//        }

//        public Liquid FilledWith
//        {
//            get
//            {
//                var liquidName = GetStringProperty("filled_with");
//                if (liquidName.Equals("empty", StringComparison.OrdinalIgnoreCase)) return null;
//                return (Liquid)DataManager.Get("Liquids", liquidName);
//            }
//            set { Properties.SetProperty("filled_with", null == value ? "empty" : value.Name); }
//        }

//        public int CurrentCharges
//        {
//            get
//            {
//                object prop = GetProperty("current_charges");
//                return prop.IsNull() ? 0 : Convert.ToInt32(prop);
//            }
//            set
//            {
//                var charges = CurrentCharges - value;
//                Properties.SetProperty("current_charges", charges <= 0 ? 0 : charges);
//            }
//        }

//        public bool IsFull
//        {
//            get { return CurrentCharges >= MaxCharges; }
//        }

//        public bool IsEmpty
//        {
//            get { return CurrentCharges <= 0; }
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

//            if (MaxCharges == -1)
//            {
//                sb.Append("#drink_con_infinite#");
//                sb.Append(Environment.NewLine);
//                sb = CommandManager.ParseString(sb, CommandManager.ToReportData(null, null, FilledWith.Description));
//                return sb.ToString();
//            }

//            if (IsEmpty)
//            {
//                sb.Append("#drink_con_0#");
//                sb.Append(Environment.NewLine);
//                sb = CommandManager.ParseString(sb);
//                return sb.ToString();
//            }

//            //// full, mostly full, half-full, barely full
//            float percentFull = CurrentCharges / (float)MaxCharges;
//            if (percentFull >= 1.0f)
//                sb.Append("#drink_con_100#");
//            else if (percentFull >= 0.75f)
//                sb.Append("#drink_con_75#");
//            else if (percentFull >= 0.5f)
//                sb.Append("#drink_con_50#");
//            else if (percentFull >= 0.25f)
//                sb.Append("#drink_con_25#");
//            else
//                sb.Append("#drink_con_lt_25#");

//            sb.Append(Environment.NewLine);
//            sb = CommandManager.ParseString(sb, CommandManager.ToReportData(null, null, FilledWith.Description));
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

//            if (null != FilledWith)
//            {
//                sb.AppendFormat("\n        item.this:SetProperty(\"filled_with\", \"{0}\");  --{1}", FilledWith.Name.ToLower(), FilledWith.Name);
//                sb.AppendFormat("\n        item.this:SetProperty(\"current_charges\", {0});", CurrentCharges);
//            }
//            else
//            {
//                sb.Append("\n        item.this:SetProperty(\"filled_with\", \"empty\");  --");
//                sb.Append("\n        item.this:SetProperty(\"current_charges\", 0);");
//            }
//            sb.Append("\n    end");
//            sb.Append("\nend");

//            return sb.ToString();
//        }
//    }
//}
