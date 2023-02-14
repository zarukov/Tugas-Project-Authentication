using System;
using System.Collections;

namespace Authentication;

public class Program
{
    public static void Main()
    {
        MenuUtama();
    }

    public static void MenuUtama()
    {
        int id;
        string FirstName, LastName, Password, Username;
        MenuUtama[] users = new MenuUtama[100];
        increment increment = new increment(0);
        bool check = true;
        Console.Clear();
        do
        {
            string[] TampilanUtama = { "Create", "Show", "Login" };
            Console.WriteLine("==BASIC AUTHENTICATION==");
            for (int i = 0; i < TampilanUtama.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {TampilanUtama[i]} User");
            }
            Console.WriteLine("4. Exit");

            Console.WriteLine("Input Opsi :");
            int opsi = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (opsi)
            {
                case 1://create acc
                    id = increment.index + 1;
                    Console.Write("First Name : ");
                    FirstName = Console.ReadLine();
                    Console.Write("Last Name : ");
                    LastName = Console.ReadLine();
                    Username = FirstName[0..2] + LastName[0..2];
                    do
                    {
                        Console.Write("Password : ");
                        Password = Console.ReadLine();
                        
                        if (Password.Length >= 8)
                        {
                            if (Password.Any(char.IsUpper))
                            {
                                if (Password.Any(char.IsLower))
                                {
                                    if (Password.Any(char.IsNumber))
                                    {
                                        Password = Password;
                                        check = false;
                                        break;
                                    }
                                }
                            }
                        }
                            Console.WriteLine("\nPassword must have at least 8 characters\r\n with at least one Capital letter, at least one lower case letter and at least one number.\n");
                        
                    } while (check);
                    MenuUtama user1 = new MenuUtama(id, FirstName, LastName, Password, Username);
                    users[increment.index] = user1;
                    user1.index(increment);
                    check = true;
                    Console.Write("\nData Berhasil Dibuat.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2://show acc
                    do
                    {
                        ShowInfo.DisplayUser(users);
                        Console.WriteLine("Menu");
                        string[] tampilanCase2 = { "Edit User", "Delete User", "Back" };
                        for (int i = 0; i < tampilanCase2.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tampilanCase2[i]}");
                        }
                        Console.WriteLine("Input : ");
                        int opsi_case2 = Convert.ToInt32(Console.ReadLine());
                        switch (opsi_case2)
                        {
                            case 1://edit
                                Console.WriteLine("Pilih ID Yang Ingin Diubah : ");
                                int ubahId = Convert.ToInt32(Console.ReadLine());
                                var check1 = Array.Exists(users, element => element.Id == ubahId);
                                if (check1 == true)
                                {
                                    users[ubahId - 1].Id = ubahId;
                                   
                                    Console.Write("First Name = ");
                                    string ubahFirst = Console.ReadLine();
                                    users[ubahId - 1].FirstName = ubahFirst;

                                    Console.WriteLine("Last Name = ");
                                    string ubahLast = Console.ReadLine();
                                    users[ubahId - 1].LastName = ubahLast;
                                    do
                                    {
                                        Console.WriteLine("Password = ");
                                        string ubahPass = Console.ReadLine();
                                        users[ubahId - 1].Password = ubahPass;

                                        if (ubahPass.Length >= 8)
                                        {
                                            if (ubahPass.Any(char.IsUpper))
                                            {
                                                if (ubahPass.Any(char.IsLower))
                                                {
                                                    if (ubahPass.Any(char.IsNumber))
                                                    {
                                                        ubahPass = ubahPass;
                                                        check = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        Console.WriteLine("\nPassword must have at least 8 characters\r\nwith at least one Capital letter, at least one lower case letter and at least one number.\n");
                                    } while (check);

                                    users[ubahId - 1].Username = (users[ubahId - 1].FirstName[0..2] + users[ubahId - 1].LastName[0..2]);
                                }
                                check = true;
                                Console.Write("\nData Berhasil Diubah.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 2://delete
                                Console.Write("\nID yang ingin dihapus: ");
                                int hapusId = Convert.ToInt32(Console.ReadLine());
                                var delete = Array.Exists(users, element => element.Id == hapusId);//
                                if(delete == true)
                                {
                                    /* ArrayList xx = new ArrayList(users);
                                      xx.RemoveAt(xx.IndexOf(hapusId-1));*/
                                    /*int index = Array.IndexOf(users, hapusId - 1);*/
                                    /*ArrayList x = new ArrayList(users);
                                    x.RemoveAt(x.IndexOf(hapusId));
                                    users = x.ToArray(users);*/
                                    users = users.Where((val, idx) => idx != hapusId - 1).ToArray();//linq
                                    Console.WriteLine("Data Telah Terhapus.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    
                                    break;
                                }
                                break;
                            default://back
                                check = true;
                                Console.Clear();
                                break;
                        }
                    } while (false);
                    check = true;
                    break;
                case 3://login
                    do
                    {
                        Console.WriteLine("Username : ");
                        string user_name = Convert.ToString(Console.ReadLine());
                        var u_name = users.Where(x => x.Username == user_name).FirstOrDefault();
                        if (u_name.Username == user_name)
                        {
                            Console.WriteLine("Password : ");
                            string pass_word = Convert.ToString(Console.ReadLine());
                            var p_word = users.Where(x => x.Password == pass_word).FirstOrDefault();
                            if (p_word.Password == pass_word)
                            {
                                Console.WriteLine("Login Berhasil.");
                                break;
                            }
                            Console.WriteLine("Login Gagal.");
                        }
                    } while (check);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4://exit
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opsi Tidak Ada, Silahkan Pilih Kembali.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        } while (check);
    }
}