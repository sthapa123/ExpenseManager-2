﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.View
{
    /// <summary>
    /// The main menu of the program
    /// </summary>
    public class ExpenseManagerUI
    {
        /// <summary>
        /// The method where we will choose the correct option to go
        /// </summary>
        public void Show()
        {
            int option;
            const int EXIT = 0, EXPENSE = 1, EXPENSE_TYPE = 2, PAYMENT_METHOD = 3, INCOME_TYPE = 4, INCOME = 5, BALANCE = 6;
            do
            {
                Menu();
                Console.WriteLine("Choose an option.");
                
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case EXPENSE:
                            ExpenseUI expUI = new ExpenseUI();
                            expUI.Show();
                            break;
                        case EXPENSE_TYPE:
                            ExpenseTypeUI retUI = new ExpenseTypeUI();
                            retUI.Show();
                            break;
                        case PAYMENT_METHOD:
                            PaymentMethodUI metUI = new PaymentMethodUI();
                            metUI.Show();
                            break;
                        case INCOME_TYPE:
                            IncomeTypeUI incTUI = new IncomeTypeUI();
                            incTUI.Show();
                            break;
                        case INCOME:
                            IncomeUI incUI = new IncomeUI();
                            incUI.Show();
                            break;
                        case BALANCE:
                            BalanceUI balUI = new BalanceUI();
                            balUI.Show();
                            break;
                        case EXIT:
                            Console.WriteLine("Bye! Bye!");
                            break;
                        default:
                            Console.WriteLine("Unknown option\nPlease try again!");
                            break;
                    }
                }
                else
                {
                    option = 999;
                }
            } while (option != 0);
        }
        /// <summary>
        /// Shows the main menu
        /// </summary>
        private void Menu()
        {
            Console.WriteLine(" === Main Menu ===");
            Console.WriteLine("1. Expense");
            Console.WriteLine("2. Expense Type");
            Console.WriteLine("3. Payment Method");
            Console.WriteLine("4. Income Type");
            Console.WriteLine("5. Income");
            Console.WriteLine("6. Balance");

            Console.WriteLine("0. Exit\n");
        }
    }
}
