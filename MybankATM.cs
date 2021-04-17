using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_project
{
    public class MybankATM : IBalance
    {
        BankAccount zaydacc = new BankAccount() { FullName = "Zayd", AccountNumber = 333111, CardNumber = 123, PinCode = 11111, Balance = 200.00m, isLocked = false };
        private static int tries;
        private const int maxTries = 3;
        private static BankAccount inputAccount;
        private static List<BankAccount> _accountList;
        private static BankAccount selectedAccount;
        public void Execute()
        {
            
            ATMScreen.ShowMenu1();
            while (true)
            {
                int inp;
                int.TryParse(Console.ReadLine(), out inp);
                switch ( inp)
                {
                    case 1:
                        // CheckCardNoPassword();
                       
                        Console.WriteLine("Type pin code");
                       int pin= Convert.ToInt32(Console.ReadLine());
                        if (pin != zaydacc.PinCode)
                        {
                            Console.WriteLine("Invalid input");
                            System.Environment.Exit(1);


                        }




                        while (true)
                        {
                            ATMScreen.ShowMenu2();

                            switch (Utility.GetValidIntInputAmt("your option"))
                            {
                                case (int)SecureMenu.CheckBalance:
                                    CheckBalance(zaydacc);
                                    break;
                                case (int)SecureMenu.PlaceDeposit:

                                    break;
                                case (int)SecureMenu.MakeWithdrawal:

                                    break;
                                case (int)SecureMenu.ThirdPartyTransfer:

                                    break;
                                case (int)SecureMenu.ViewTransaction:

                                    break;

                                case (int)SecureMenu.Logout:
                                    Utility.PrintMessage("You have succesfully logout. Please collect your ATM card..", true);

                                    Execute();
                                    break;
                                default:
                                    Utility.PrintMessage("Invalid Option Entered.", false);

                                    break;
                            }
                        }
                    case 2:
                        Console.Write("\nThank you for using Zaydbank. Exiting program now .");
                        //Utility.printDotAnimation(15);

                        System.Environment.Exit(1);
                        break;
                    default:
                        Utility.PrintMessage("Invalid Option Entered.", false);
                        break;
                }
            }

        }


        private static void LockAccount()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked.", true);
            Console.WriteLine("Please go to the nearest branch to unlocked your account.");
            Console.WriteLine("Thank you for using Meybank. ");
            Console.ReadKey();
            System.Environment.Exit(1);
        }
        public void CheckCardNoPassword()
        {
            bool pass = false;

            while (!pass)
            {
                inputAccount = new BankAccount();

                Console.WriteLine("\nNote: Actual ATM system will accept user's ATM card to validate");
                Console.Write("and read card number, bank account number and bank account status. \n\n");
               
                inputAccount.CardNumber = (int)Utility.GetValidIntInputAmt("ATM Card Number");

                Console.Write("Enter 6 Digit PIN: ");
                inputAccount.PinCode = Convert.ToInt32(Utility.GetHiddenConsoleInput());
        


                System.Console.Write("\nChecking card number and password.");
                Utility.printDotAnimation();

                foreach (BankAccount account in _accountList)
                {
                    if (inputAccount.CardNumber.Equals(account.CardNumber))
                    {
                        selectedAccount = account;

                        if (inputAccount.PinCode.Equals(account.PinCode))
                        {
                            if (selectedAccount.isLocked)
                                LockAccount();
                            else
                                pass = true;


                        }
                        else
                        {

                            pass = false;
                            tries++;

                            if (tries >= maxTries)
                            {
                                selectedAccount.isLocked = true;

                                LockAccount();
                            }

                        }
                    }
                }

                if (!pass)
                    Utility.PrintMessage("Invalid Card number or PIN.", false);

                Console.Clear();
            }
        }












        public void CheckBalance(BankAccount bankAccount)
        {
            // dont't forget to implement utility format amount
            Utility.PrintMessage($"Your bank account balance amount is: {(bankAccount.Balance)}", true);
        }

    }
}


        
