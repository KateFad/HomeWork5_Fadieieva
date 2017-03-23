using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5_Fadieieva
{
    class Program
    {
        static void Main(String[] args)
        {
            //Task1();
            //Task2();
            Task3();
        }


        static void Task1()
        {
            Console.WriteLine("Hello! Please enter a dimension of array (positive integer number):");
            String d = Console.ReadLine();
            if (IsInt(d) && IsPositive(Int32.Parse(d)))
            {
                int[] array = new int[Int32.Parse(d)];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = i;
                }
                Console.Write("Array is: ");
                foreach (var element in array)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("\nPlease enter a positive integer number of values you wants to be displayed: ");
                String n = Console.ReadLine();
                if (IsInt(n) && IsPositive(Int32.Parse(n)))
                {
                    if (Int32.Parse(n) <= array.Length)
                    {
                        Console.Write("Result: ");
                        for (int e = 0; e <= array[Int32.Parse(n) - 1]; e++)
                        {
                            Console.Write(array[e] + " ");
                        }
                    }
                    else Console.WriteLine("Your value is bigger than array dimension.");
                }

            }
            Console.ReadLine();
        }

        static void Task2()
        {
            Console.WriteLine("Hello! Please enter a dimension of array (positive integer number):");
            String d = Console.ReadLine();
            if (IsInt(d) && IsPositive(Int32.Parse(d)))
            {
                int[] array = new int[Int32.Parse(d)];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = i;
                }
                Console.Write("Array is: ");
                foreach (var element in array)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("\nPlease enter a positive integer number of values from the end of array you wants to be displayed: ");
                String n = Console.ReadLine();
                if (IsInt(n) && IsPositive(Int32.Parse(n)))
                {
                    if (Int32.Parse(n) <= array.Length)
                    {
                        Console.Write("Result: ");
                        //Array.Reverse(array);
                        //for (int e = Int32.Parse(n)-1; e >= 0 ; e--)
                        for (int e = array.Length - Int32.Parse(n); e < array.Length; e++)
                        {
                            Console.Write(array[e] + " ");
                        }
                    }
                    else Console.WriteLine("Your value is bigger than array dimension.");
                }

            }
            Console.ReadLine();
        }

        static void Task3()
        {

            Dictionary<String, String> clients = new Dictionary<String, String>()
            {
                ["katya"] = ("123")
            };
            Dictionary<String, List<String>> pok = new Dictionary<String, List<String>>()
            {
                ["katya"] = { }
            };
            List<String> stuff = new List<String>() { "pen", "apple", "applepen" };
           // foreach (var el in stuff)
            //{
            //    Console.WriteLine((stuff.IndexOf(el) + 1) + "." + el);    удаление
            //}
         
            List<string> existing;
        startmenu:
            Console.WriteLine("Hello. This is super puper store!");
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1. Login to the store");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. Exit");
            String option = Console.ReadLine();
            if (IsInt(option))
            {
                switch (Int32.Parse(option))
                {
                    case 1:
                        Console.Write("Please enter a login: ");
                        String login = Console.ReadLine();
                        Console.Write("Please enter a password: ");
                        String pass = Console.ReadLine();
                        Console.Clear();
                        if (clients.ContainsKey(login) && clients.ContainsValue(pass))
                        {
                        loginmenu:
                            Console.WriteLine("Please select an option: ");
                            Console.WriteLine("1. Buy stuff");
                            Console.WriteLine("2. View already bought stuff");
                            Console.WriteLine("3. Logout");
                            String option2 = Console.ReadLine();
                            Console.Clear();
                            if (IsInt(option2))
                            {
                                switch (Int32.Parse(option2))
                                {
                                    case 1:
                                        int count = 1;
                                        Console.WriteLine("Available items:");
                                        foreach (var item in stuff)
                                        {
                                            Console.WriteLine(count + ". " + item);
                                            count++;
                                        }
                                        Console.WriteLine("Please select what you want to buy:");
                                        String buy = Console.ReadLine();
                                        if (IsInt(buy))
                                        {
                                            if (!pok.TryGetValue(login, out existing))
                                            {
                                                existing = new List<string>();
                                                pok[login] = existing;
                                            }
                                            existing.Add(stuff[Int32.Parse(buy) - 1]);
                                            Console.WriteLine("Item was successfully bought!");
                                        }
                                        Console.ReadLine();
                                        Console.Clear();
                                        goto loginmenu;
                                    case 2:
                                        if (!pok.TryGetValue(login, out existing) || existing.Capacity < 1)
                                        {
                                            Console.WriteLine("You haven't buy anything yet");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Bought stuff:");
                                            foreach (var item in pok[login])
                                            {
                                                Console.WriteLine(item);
                                            }

                                        }
                                        Console.ReadLine();
                                        Console.Clear();
                                        goto loginmenu;
                                    case 3:
                                        Console.Clear();
                                        goto startmenu;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have entered incorrect login or password");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        goto startmenu;
                    case 2:
                        Console.Write("Please enter a login: ");
                        String newLogin = Console.ReadLine();
                        if (clients.ContainsKey(newLogin))
                        {
                            Console.WriteLine("User with this login already exist");
                            Console.ReadLine();
                            Console.Clear();
                            goto startmenu;
                        }
                        Console.Write("Please enter a password: ");
                        String newPass = Console.ReadLine();
                        clients.Add(newLogin, newPass);
                        pok.Add(newLogin, new List<string>());
                        Console.WriteLine("Registration successfully complited! \nNow you can use your credentials to login!");
                        Console.ReadLine();
                        Console.Clear();
                        goto startmenu;
                    case 3:
                        break;

                }
            }
        }


        static bool IsInt(String s)
        {
            int res;
            bool isInt = Int32.TryParse(s, out res);
            if (isInt)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You have entered not integer number.");
                return false;
            }
        }

        static bool IsPositive(int i)
        {
            if (i > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("You have entered number <= 0");
                return false;
            }
        }

    }
}