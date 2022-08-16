using Microsoft.EntityFrameworkCore;
using OrdermgntEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdermgntEF.Data
{
    public class CRUDItem
    {
        private DbContextFile Dbobj;
        public CRUDItem()
        {
            Dbobj = new DbContextFile();
        }

        public ItemMaster GetItemById(int ItemId)
        {

            var item = Dbobj.ItemMasters.Where(x => x.Id == ItemId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (item == null)
            {
                throw new Exception($"Customer with ID:{ItemId} Not Found");
            }

            return item;
        }

        public List<ItemMaster> GetAllItems()
        {
            var item = Dbobj.ItemMasters.ToList();
            return item;
        }

        public void Insert(ItemMaster item)
        {
            Dbobj.ItemMasters.Add(item);
            Dbobj.SaveChanges();
        }

        public void Update(int ItemId, ItemMaster modifiedItem)
        {
            var item = Dbobj.ItemMasters.Where(x => x.Id == ItemId).FirstOrDefault();
            if (item == null)
            {
                throw new Exception($"Item with ID:{ItemId} Not Found");
            }

            item.Name = modifiedItem.Name;
            item.Price = modifiedItem.Price;
            item.Quantity = modifiedItem.Quantity;
            

            // Entity state : Modified
            Dbobj.ItemMasters.Update(item);

            // This issues insert statement
            Dbobj.SaveChanges();
        }

        public void Delete(int ItemId)
        {
            var item = Dbobj.ItemMasters.Where(x => x.Id == ItemId).FirstOrDefault();
            if (item == null)
            {
                throw new Exception($"Item with ID:{ItemId} Not Found");
            }

            // Entity state : Deleted
            Dbobj.ItemMasters.Remove(item);

            // This issues insert statement
            Dbobj.SaveChanges();
        }
    }
}
