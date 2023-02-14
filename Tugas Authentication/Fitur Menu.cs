using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication;

public class ShowInfo
{
    public static void DisplayUser(MenuUtama[] users)
    {
        foreach (var item in users)
        {
            if(item != null) 
            {
                Console.WriteLine("===========SHOW INFORMATION===========");
                Console.WriteLine("ID : " + item.Id);
                Console.WriteLine("Full Name: " +item.FirstName + " " +item.LastName);
                Console.WriteLine("Username : " + item.Username);
                Console.WriteLine("Password : " + item.Password);
                Console.WriteLine("======================================");
            }
        }
    }

}
public class EditInfo : ShowInfo
{
    public static void EditUser(MenuUtama[] users)
    {
        foreach (var itemEdit in users)
        {
            if (itemEdit != null)
            {
                Console.WriteLine("===========SHOW INFORMATION===========");
                Console.WriteLine("ID : " + itemEdit.Id);
                Console.WriteLine("Full Name: " + itemEdit.FirstName + " " + itemEdit.LastName);
                Console.WriteLine("Username : " + itemEdit.Username);
                Console.WriteLine("Password : " + itemEdit.Password);
                Console.WriteLine("======================================");
            }
        }
    }

}
public class MenuUtama //nanya
{

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }

    public MenuUtama(int id, string firstName, string lastName, string password, string username)
    {

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Username = username;
    }
    public increment index(increment increment)//nanya
    {
        increment.index = increment.index + 1;
        return increment;
    }
}
public class increment //nanya
{
    public int index { get; set; }
    public increment(int index)
    {
        this.index = index;
    }
}