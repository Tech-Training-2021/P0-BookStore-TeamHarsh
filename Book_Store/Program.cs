using System;
using System.Collections.Generic;
using Customer;
using Encryption_Decryption_Password;
namespace Book_Store
{
    class Program
    {
      public void register()
        {
            Registration registration = new Registration();
            registration.getUserDetails();
        }
        public void login()
        {
            Login login = new Login();
            var valid=login.login();
            if (valid == true)
            {
                Console.WriteLine("\n****Valid User****");
                options();
            }
            else
            {
                Console.WriteLine("\n****Invalid User****");
                Console.WriteLine("If you are not the memeber please REGISTER");
                displayOperation();
            }
        }
        public void options()
        {
            CustomerOpt:
            Console.WriteLine("Select the following option");
            Console.WriteLine("1.Edit Profile\n2.Display Categorys\n3.Cart\n4.History");
            switch (int.Parse(Console.ReadLine())){
                case 1:
                    EditProfile editProfile = new EditProfile();
                    editProfile.getEditOptions();
                    break;
                case 2: 
                    Console.WriteLine("Display");
                    break;
                case 3:
                    Console.WriteLine("Cart");
                    break;
                default:
                    Console.WriteLine("Invalid Option\n Please Enter Proper Operation");
                    goto CustomerOpt;
                    break;
            }
        }
        public void displayOperation() {
                Console.WriteLine("Please Select the following operation");
                Console.WriteLine("0. Exit\n1.Sign In\n2.Sign Up");
                Console.Write("Enter Your Choice : ");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        login();
                        break;
                    case 2:
                        register();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
        }
        public static void Main(string[] args)
        {
            Program p1 = new Program();
            Console.WriteLine("****Welcome to Book Store****");
            //p1.displayOperation();
            Admin admin = new Admin();
            admin.admin();
        }
    }
}
