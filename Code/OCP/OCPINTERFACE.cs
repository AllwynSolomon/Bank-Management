using System;
class PD
{
    public static List<string> name = new List<string>();
    public static List<string> address = new List<string>();
    public static List<string> email = new List<string>();
    public static List<string> gender = new List<string>();
    public static List<string> marriage = new List<string>();
    public static List<string> username = new List<string>();
    public static List<string> password = new List<string>();
    public static List<int> age = new List<int>();
    public static List<int> Mpin = new List<int>();
    public static List<Int64> phone = new List<Int64>();
    public static List<Int64> accnum = new List<Int64>();
    public static List<Int64> money = new List<Int64>();
    public static Int64 ACCID, balance;
    public static int tran, check = 2;


    public PD()
    {

        name.AddRange(new List<string>() { "Alen", "Abel", "Manan", "Allwyn", "Mark" });
        address.AddRange(new List<string>() { "Chrsit", "christ", "USA", "canada", "india" });
        email.AddRange(new List<string>() { "alen@", "Abel@", "Manan@", "Allwyn@", "Mark@" });
        gender.AddRange(new List<string>() { "M", "M", "M", "M", "M" });
        marriage.AddRange(new List<string>() { "Y", "N", "Y", "N", "Y" });
        username.AddRange(new List<string>() { "Alen", "Abel", "Manan", "Allwyn", "Mark" });
        password.AddRange(new List<string>() { "1234", "2345", "3456", "4567", "5678" });
        age.AddRange(new List<int>() { 20, 21, 20, 19, 24 });
        Mpin.AddRange(new List<int>() { 0987, 9876, 8765, 7654, 6543 });
        phone.AddRange(new List<Int64>() { 12345, 23456, 34567, 45678, 56789 });
        accnum.AddRange(new List<Int64>() { 2060316, 2060468, 2060256, 2060318, 2060344 });
        money.AddRange(new List<Int64>() { 1000, 10000, 2000, 20000, 9999 });
    }
}


interface iLogin
{
    public void Admin();
    public void User();
}

class admin_login : iLogin
{
    public void Admin()
    {
        PD.check = 2;
        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine("\n\t Admin Login\n");
            Console.Write("\t User Name: ");
            var username = Console.ReadLine();
            Console.Write("\t Password : ");
            var password = Console.ReadLine();
            if (username == "admin" && password == "admin")
            {
                Console.WriteLine("Admin Login Sucessful");
                PD.check = 1;
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                PD.check = 0;
                Console.ReadKey();
                continue;
            }
        }
    }
    public void User() { }
}

class User_login : Security, iLogin
{
    public void Admin() { }
    public void User()
    {
        PD.check = 2;
        Console.Write("\n\t Account Number: ");
        PD.ACCID = Convert.ToInt64(Console.ReadLine());
        if (PD.accnum.Contains(PD.ACCID))
        {
            for (int i = 0; i < PD.accnum.Count; i++)
            {
                if (PD.ACCID == PD.accnum[i])
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\t Account Number: " + PD.accnum[i]);
                        Console.Write("\t User Name     : ");
                        var loginID = Console.ReadLine();
                        Console.Write("\t Password      : ");
                        var loginPass = Console.ReadLine();

                        if (loginID == PD.username[i] && loginPass == PD.password[i])
                        {
                            otp();
                            Console.WriteLine("\n\t User Login Sucessful");
                            PD.check = 1;
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n\t User Login Failed: Try Again");
                            PD.check = 0;
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Try Again");
        }
    }
}



interface iACCOUNTS {}

interface IUDETAIL: iACCOUNTS
{
    public void User_detail();
}
interface IURegister : iACCOUNTS
{
    public void User_register();
}
interface IUUpdate : iACCOUNTS
{
    public void User_Update();
}

public sealed class User_account : iACCOUNTS
{
    public void User_detail()
    {
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                Console.WriteLine("\n\t Details\n");
                Console.WriteLine("\n\t Account Number  : " + PD.accnum[i]);
                Console.WriteLine("\n\t Account Balance : " + PD.money[i]);
                Console.WriteLine("\n\t Name            : " + PD.name[i]);
                Console.WriteLine("\n\t Age             : " + PD.age[i]);
                Console.WriteLine("\n\t Address         : " + PD.address[i]);
                Console.WriteLine("\n\t Phone Number    : " + PD.phone[i]);
                Console.WriteLine("\n\t Email           : " + PD.email[i]);
                Console.WriteLine("\n\t Gender          : " + PD.gender[i]);
                Console.WriteLine("\n\t Martial Status  : " + PD.marriage[i]);

            }
        }
    }
    public void User_register() { }
    public void User_Update() { }
}

public class Register : Security, iACCOUNTS
{
    public void User_register()
    {
        Random rand = new Random();

        PD.ACCID = rand.Next(10000, 100000);
        PD.accnum.Add(PD.ACCID);

        Console.WriteLine("\n\t\tEnter your Details");
        Console.Write("\t Name          : ");
        PD.name.Add(Console.ReadLine());

        Console.Write("\t Age           : ");
        PD.age.Add(Convert.ToInt32(Console.ReadLine()));

        Console.Write("\t Address       : ");
        PD.address.Add(Console.ReadLine());

        Console.Write("\t Email         : ");
        PD.email.Add(Console.ReadLine());

        Console.Write("\t Phone Number  : ");
        PD.phone.Add(Convert.ToInt64(Console.ReadLine()));

        Console.Write("\t Gender        : ");
        PD.gender.Add(Console.ReadLine());

        Console.Write("\t Married(Y/N)  :");
        PD.marriage.Add(Console.ReadLine());

        Console.Write("\t User Name     : ");
        PD.username.Add(Console.ReadLine());

        Console.Write("\t Password      : ");
        PD.password.Add(Console.ReadLine());

        Console.Write("\t MPIN          : ");
        PD.Mpin.Add(Convert.ToInt32(Console.ReadLine()));
        PD.money.Add(0);

        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n\t Enter OTP sent ");
        otp();
    }
    public void User_detail() { }
    public void User_Update() { }

}

public class User_update : Security, iACCOUNTS
{
    public void User_Update()
    {
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                PD.name.RemoveAt(i);
                PD.age.RemoveAt(i);
                PD.address.RemoveAt(i);
                PD.email.RemoveAt(i);
                PD.phone.RemoveAt(i);
                PD.gender.RemoveAt(i);
                PD.marriage.RemoveAt(i);
                PD.username.RemoveAt(i);
                PD.password.RemoveAt(i);
                PD.Mpin.RemoveAt(i);

                Console.WriteLine("\n\t\tEnter your New Details");
                Console.Write("\t Name          : ");
                PD.name.Insert(i, Console.ReadLine());

                Console.Write("\t Age           : ");
                PD.age.Insert(i, Convert.ToInt32(Console.ReadLine()));

                Console.Write("\t Address       : ");
                PD.address.Insert(i, Console.ReadLine());

                Console.Write("\t Email         : ");
                PD.email.Insert(i, Console.ReadLine());

                Console.Write("\t Phone Number  : ");
                PD.phone.Insert(i, Convert.ToInt64(Console.ReadLine()));

                Console.Write("\t Gender        : ");
                PD.gender.Insert(i, Console.ReadLine());

                Console.Write("\t Married(Y/N)  :");
                PD.marriage.Insert(i, Console.ReadLine());

                Console.Write("\t User Name     : ");
                PD.username.Insert(i, Console.ReadLine());

                Console.Write("\t Password      : ");
                PD.password.Insert(i, Console.ReadLine());

                Console.Write("\t MPIN          : ");
                PD.Mpin.Insert(i, Convert.ToInt32(Console.ReadLine()));
                otp();
            }
        }
    }
    public void User_detail() { }
    public void User_register() { }
}



interface  iTransaction{}

interface iOnline: iTransaction
{
    public void withdraw();
    public void deposit();
}

interface imode: iTransaction
{
    public void atm();
}

sealed class ATM: imode
{
    public void atm()
    {
        PD.check = 2;

        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                    Console.Write("\n\t Please Visit The nearest ATM to Withdraw or Deposit ");
                    break;
                }
            }
        }
    }
}
sealed class ONLINE : Security, iOnline
{
    public void withdraw()
    {
        PD.check = 2;
        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                    Console.Write("\n\t Enter the Amount to Withdraw: ");
                    var WITHDEP = Convert.ToInt32(Console.ReadLine());
                    Security.MPIN();
                    if (PD.check == 1)
                    {
                        PD.money[i] = PD.money[i] - WITHDEP;
                        PD.balance = PD.money[i];
                        PD.tran = i;
                        Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Wrong Mpin: Try Again");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
    public void deposit()
    {
        PD.check = 2;

        for (int i = 0; i < PD.accnum.Count; i++)
        {
            if (PD.ACCID == PD.accnum[i])
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                    Console.Write("\n\t Enter the Amount to Deposit: ");
                    var WITHDEP = Convert.ToInt32(Console.ReadLine());
                    Security.MPIN();
                    if (PD.check == 1)
                    {
                        PD.money[i] = PD.money[i] + WITHDEP;
                        PD.balance = PD.money[i];
                        Console.WriteLine("\n\t Account Balance: " + PD.money[i]);
                        break;
                    }
                    else
                    {

                        Console.WriteLine("Wrong Mpin: Try Again");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}





interface iAdminControl
{
    public void Admin_delete();
    public void Admin_detail();
    public void Admin_table_detail();
}

sealed class Admin_account : iAdminControl
{

    public void Admin_detail()
    {
        Console.Write("\tAccount Number: ");
        var acc = Convert.ToInt64(Console.ReadLine());
        if (PD.accnum.Contains(acc))
        {
            for (int i = 0; i < PD.accnum.Count; i++)
            {
                if (PD.accnum[i] == acc)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t Details\n");
                    //Console.WriteLine("\t Money         : " + money[i]);
                    Console.WriteLine("\t Name          : " + PD.name[i]);
                    Console.WriteLine("\t Age           : " + PD.age[i]);
                    Console.WriteLine("\t Address       : " + PD.address[i]);
                    Console.WriteLine("\t Phone Number  : " + PD.phone[i]);
                    Console.WriteLine("\t Email         : " + PD.email[i]);
                    Console.WriteLine("\t Gender        : " + PD.gender[i]);
                    Console.WriteLine("\t Martial Status: " + PD.marriage[i]);
                }
            }
        }
        else
            Console.WriteLine("\n\t Wrong User Account Number");
    }

    public void Admin_table_detail()
    {
        Console.WriteLine("AccountID\t Name\t\t Age\t Address\t\t Phone Number\t Email\t\t Gender\t Married");

        for (int i = 0; i < PD.accnum.Count; i++)
        {

            Console.WriteLine(PD.accnum[i] + " \t " + PD.name[i] + "\t\t " + PD.age[i]
                + " \t  " + PD.address[i] + " \t\t  " + PD.phone[i] + " \t " + PD.email[i]
                + " \t\t " + PD.gender[i] + "  \t " + PD.marriage[i]);

        }
    }

    public void Admin_delete() { }
}

sealed class delete : iAdminControl
{

    public void Admin_detail() { }
    public void Admin_table_detail() { }
    public void Admin_delete()
    {
        Console.Write(" Enter your Account Number: ");
        var acc = Convert.ToInt64(Console.ReadLine());
        if (PD.accnum.Contains(acc))
        {
            for (int i = 0; i < PD.accnum.Count; i++)
            {
                if (acc == PD.accnum[i])
                {
                    PD.accnum.RemoveAt(i);
                    PD.name.RemoveAt(i);
                    PD.money.RemoveAt(i);
                    PD.age.RemoveAt(i);
                    PD.address.RemoveAt(i);
                    PD.email.RemoveAt(i);
                    PD.phone.RemoveAt(i);
                    PD.gender.RemoveAt(i);
                    PD.marriage.RemoveAt(i);
                    PD.username.RemoveAt(i);
                    PD.password.RemoveAt(i);
                    PD.Mpin.RemoveAt(i);

                    Console.WriteLine("\n\t Account " + acc + " Deleted");
                }
            }
        }
        else
            Console.WriteLine("\n\t Wrong User Account Number");
    }
}




public class Security
{
    public static void otp()
    {
        for (int i = 0; i < 5; i++)
        {
            Random rand = new Random();
            int otp = rand.Next(1000, 9999);
            Console.WriteLine("OTP     : " + otp);
            Console.Write("Type the OTP: ");
            if (otp == Convert.ToInt32(Console.ReadLine()))
            {
                Console.WriteLine("Success");
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                continue;
            }
        }
    }

    public static void MPIN()
    {
        for (int i = 0; i < 5; i++)
        {

            Console.Write("Enter the MPIN: ");
            var pin = Convert.ToInt32(Console.ReadLine());
            if (PD.Mpin.Contains(pin))
            {
                Console.WriteLine("Success");
                PD.check = 1;
                break;
            }
            else
            {
                Console.WriteLine("Try Again");
                Console.ReadKey();
                PD.check = 0;
                continue;
            }
        }
    }
}
// Customer Support Class
public sealed class cust_support
{
    public void contact()
    {
        Console.WriteLine("\n\t Welcome to Customer Support");
        Console.WriteLine("\t ❤ Chat with us ❤ ");

    }
}
// Main Program Class
class Program
{
    static void Main(string[] args)
    {
        int M1;
        int admin_choice, user_choice, trans_choice, login_choice, choice;

        PD pD = new PD();
        admin_login Admin_login = new admin_login();
        User_login User_login = new User_login();

        ATM atm = new ATM();
        ONLINE online = new ONLINE();

        User_account user_account = new User_account();
        Admin_account admin_account = new Admin_account();

        Register register = new Register();
        User_update user_Update = new User_update();
        delete delete = new delete();

        Security security = new Security();
        cust_support support = new cust_support();

        // Funtion to go to Main Menu  
        goto MainMenu;


    // goto Function for Admin Menu
    AdminControl:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.User Detail\n");
                Console.WriteLine("\t 2.Table Detail\n");
                Console.WriteLine("\t 3.Delete\n");
                Console.WriteLine("\t 4.Back to Main Menu\n");
                Console.Write("\n\t Enter your Choice: ");
                admin_choice = Convert.ToInt32(Console.ReadLine());

                switch (admin_choice)
                {
                    case 1:
                        admin_account.Admin_detail();
                        Console.ReadKey();
                        break;
                    case 2:
                        admin_account.Admin_table_detail();
                        Console.ReadKey();
                        break;
                    case 3:
                        delete.Admin_delete();
                        Console.ReadKey();
                        break;
                    case 4:
                        goto MainMenu;
                }
            } while (admin_choice < 4);
        }


    // goto Funtion for User Menu
    UserControl:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.User Detail\n");
                Console.WriteLine("\t 2.Update Detail\n");
                Console.WriteLine("\t 3.Transaction\n");
                Console.WriteLine("\t 4.Customer Support\n");
                Console.WriteLine("\t 5.Back to Main Menu\n");
                Console.Write("\n\t Enter your Choice: ");
                user_choice = Convert.ToInt32(Console.ReadLine());

                switch (user_choice)
                {
                    case 1:
                        user_account.User_detail();
                        Console.ReadKey();
                        break;
                    case 2:
                        user_Update.User_Update();
                        user_account.User_detail();
                        Console.ReadKey();
                        break;
                    case 3:
                        goto TransactionControl;
                    case 4:
                        support.contact();
                        Console.ReadKey();
                        break;
                    case 5:
                        goto MainMenu;

                }
            } while (user_choice < 5);
        }


    // goto Function for Transaction Menu
    TransactionControl:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.Deposit\n");
                Console.WriteLine("\t 2.Withdraw\n");
                Console.WriteLine("\t 3.ATM\n");
                Console.WriteLine("\t 4.Back to Menu\n");
                Console.Write("\n\t Enter your Choice: ");
                trans_choice = Convert.ToInt32(Console.ReadLine());

                switch (trans_choice)
                {
                    case 1:
                        online.deposit();
                        Console.ReadKey();
                        break;
                    case 2:
                        online.withdraw();
                        Console.ReadKey();
                        break;
                    case 3:
                        atm.atm();
                        Console.ReadKey();
                        break;
                    case 4:
                        goto UserControl;
                }
            } while (trans_choice < 4);
        }


    // goto Function for Login
    LOGIN:
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\tMenu\n");
                Console.WriteLine("\t 1.Admin\n");
                Console.WriteLine("\t 2.User\n");
                Console.WriteLine("\t 3. Back to menu");
                Console.Write("\n\t Enter your Choice: ");
                login_choice = Convert.ToInt32(Console.ReadLine());

                switch (login_choice)
                {
                    case 1:
                        Admin_login.Admin();
                        if (PD.check == 1)
                            goto AdminControl;
                        else
                        {
                            Console.WriteLine("Admin Login Failed");
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        User_login.User();
                        if (PD.check == 1)
                            goto UserControl;
                        else
                        {
                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        goto MainMenu;
                }

            } while (login_choice < 3);
        }


    // goto Function for Main Menu
    MainMenu:
        {
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("\t Welcone to Manan Bank");
                Console.WriteLine("\n\t\t Menu");
                Console.WriteLine("\n\t 1.Login");
                Console.WriteLine("\n\t 2.Create Account");
                Console.WriteLine("\n\t 3.Contact");
                Console.WriteLine("\n\t 4.Exit");
                Console.Write("\n\t Enter your Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        goto LOGIN;

                    case 2:
                        Console.Clear();
                        register.User_register();
                        user_account.User_detail();
                        Console.ReadKey();
                        break;
                    case 3:
                        support.contact();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n\t ❤ Thank for choosing Manan Bank ❤");
                        Console.ReadKey();
                        break;
                }
            } while (choice < 4);
        }
    }
}