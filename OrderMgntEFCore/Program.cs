using OrdermgntEF.Data;
using OrdermgntEF.Data.Entities;


public class program
{
    public static void Main()
    {
        CRUDCustomer cusobj = new CRUDCustomer();
        //Console.WriteLine("Update Customer");
        //cusobj.Update()
        var id = Convert.ToInt32(Console.ReadLine());
        var fname = Console.ReadLine();
        var lname = Console.ReadLine();
        var phone = Convert.ToInt64(Console.ReadLine());
        var mail = Console.ReadLine();
        cusobj.Insert(new Customer { Id = id, FirstName = fname, LastName = lname, Phone_No = phone, Email = mail });
        PrintAllCustomers();

    }

    private static void PrintAllCustomers()
    {
        CRUDCustomer obj = new CRUDCustomer();
        foreach(Customer customer in obj.GetAllCustomers())
        {
            Console.WriteLine(customer.Id +"\t" +customer.FirstName + "\t" +customer.LastName + "\t" +customer.Phone_No + "\t" +customer.Email);
        }
    }
}