// ----------------------------------------------------------------------
// <copyright file="SaleItem.cs" company="12-South Studios">
//     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
//     subject to the Microsoft Public License.  All other rights reserved.
//     subject to the Microsoft Public License.  All other rights reserved.
// <summary>
//
// </summary>
// ------------------------------------------------------------------------
namespace Realm.Server.NPC
{
    public class SaleItem
    {
        public SaleItem(long id, int qty)
        {
            SaleItemId = id;
            ReplenishQuantity = qty;
            QuantityInStock = qty;
        }

        public long SaleItemId { get; private set; }
        public int ReplenishQuantity { get; private set; }
        public int QuantityInStock { get; set; }
    }
}
