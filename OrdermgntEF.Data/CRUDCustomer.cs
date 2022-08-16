using Microsoft.EntityFrameworkCore;
using OrdermgntEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdermgntEF.Data
{
    public class CRUDCustomer
    {
        private DbContextFile DbConobj;
        public CRUDCustomer()
        {
            DbConobj = new DbContextFile();
        }

        public Customer GetCustomerById(int CusId)
        {
            
            var customer = DbConobj.Customors.Where(x => x.Id == CusId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (customer == null)
            {
                throw new Exception($"Customer with ID:{CusId} Not Found");
            }

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            var Customer = DbConobj.Customors.ToList();
            return Customer;
        }

        public void Insert(Customer customer)
        {
            DbConobj.Customors.Add(customer);
            DbConobj.SaveChanges();
        }

        public void Update(int CusId, Customer modifiedCustomer)
        {
            var customer = DbConobj.Customors.Where(x => x.Id == CusId).FirstOrDefault();
            if (customer == null)
            {
                throw new Exception($"Customer with ID:{CusId} Not Found");
            }

            customer.FirstName = modifiedCustomer.FirstName;
            customer.LastName = modifiedCustomer.LastName;
            customer.Email = modifiedCustomer.Email;
            customer.Phone_No = modifiedCustomer.Phone_No;

            // Entity state : Modified
            DbConobj.Customors.Update(customer);

            // This issues insert statement
            DbConobj.SaveChanges();
        }

        public void Delete(int CusId)
        {
            var customer = DbConobj.Customors.Where(x => x.Id == CusId).FirstOrDefault();
            if (customer == null)
            {
                throw new Exception($"Employee with ID:{CusId} Not Found");
            }

            // Entity state : Deleted
            DbConobj.Customors.Remove(customer);

            // This issues insert statement
            DbConobj.SaveChanges();
        }
        private void CusOption()
        {
            Console.WriteLine();
            Console.WriteLine("   Press 1: Add Customer        ");
            Console.WriteLine("  Press 2: Delete Customer      ");
            Console.WriteLine("  Press 1: Update Customer      ");
            Console.WriteLine("  Press 1: ShowAll Customer     ");
            Console.WriteLine("      Press 1: Exit             ");

        }
    }
}
