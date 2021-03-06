﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseManager.Model;
using ExpenseManager.ViewModel;
using ExpenseManager.Persistence;

namespace Test.Function
{
    /// <summary>
    /// The test class for the expense function
    /// </summary>
    [TestClass]
    public class ExpenseTest
    {
        /// <summary>
        /// The test method for the register expense
        /// </summary>
        [TestMethod]
        public void TestRegisterExpense()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = new DateTime(2012, 12, 21, 15, 30, 00);
            ec.RegisterExpense(type, pay1, date, "AAA");
        
            List<Expense> list = PersistenceFactory.GetFactory().GetRepository().GetExpenseRepository().All();

            Assert.AreEqual("Expense:\nDescription: AAA\nType: AAA - aaa\nPayment: Payment: Money\nCurrency: EUR\nAmount: 15\nDate: 21/12/2012 15:30:00", list[0].ToString());
        }

        /// <summary>
        /// The test method for the list of the last week expenses
        /// </summary>
        [TestMethod]
        public void TestGetExpensesLastWeek()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = new DateTime(2012, 12, 21, 15, 30, 00);
            ec.RegisterExpense(type, pay1, date, "AAA");

            DateTime date1 = DateTime.Now;
            ec.RegisterExpense(type, pay1, date1, "BBB");

            List<Expense> list = ec.GetExpensesFromLastWeek();
            Assert.AreEqual(String.Format("Expense:\nDescription: BBB\nType: AAA - aaa\nPayment: Payment: Money\nCurrency: EUR\nAmount: 15\nDate: {0}", date1), list[0].ToString());
        }

        /// <summary>
        /// The test method for the list of the last two week expenses
        /// </summary>
        [TestMethod]
        public void TestGetExpensesLastTwoWeeks()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = new DateTime(2012, 12, 21, 15, 30, 00);
            ec.RegisterExpense(type, pay1, date, "AAA");

            DateTime date1 = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0));
            ec.RegisterExpense(type, pay1, date1, "BBB");

            List<Expense> list = ec.GetExpensesFromLastTwoWeeks();
            Assert.AreEqual(String.Format("Expense:\nDescription: BBB\nType: AAA - aaa\nPayment: Payment: Money\nCurrency: EUR\nAmount: 15\nDate: {0}", date1), list[0].ToString());
        }
        
        /// <summary>
        /// The test method for the list of the last month expenses
        /// </summary>
        [TestMethod]
        public void TestGetExpensesLastMonth()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = new DateTime(2012, 12, 21, 15, 30, 00);
            ec.RegisterExpense(type, pay1, date, "AAA");

            DateTime date1 = DateTime.Now;
            ec.RegisterExpense(type, pay1, date1, "BBB");

            List<Expense> list = ec.GetExpensesFromLastMonth();
            Assert.AreEqual(String.Format("Expense:\nDescription: BBB\nType: AAA - aaa\nPayment: Payment: Money\nCurrency: EUR\nAmount: 15\nDate: {0}", date1), list[0].ToString());
        }

        /// <summary>
        /// The test method for the list of the last two month expenses
        /// </summary>
        [TestMethod]
        public void TestGetExpensesLastTwoMonths()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = new DateTime(2012, 12, 21, 15, 30, 00);
            ec.RegisterExpense(type, pay1, date, "AAA");

            DateTime date1 = DateTime.Now.Subtract(new TimeSpan(35, 0, 0, 0));
            ec.RegisterExpense(type, pay1, date1, "BBB");

            List<Expense> list = ec.GetExpensesFromLastTwoMonths();
            Assert.AreEqual(String.Format("Expense:\nDescription: BBB\nType: AAA - aaa\nPayment: Payment: Money\nCurrency: EUR\nAmount: 15\nDate: {0}", date1), list[0].ToString());
        }

        /// <summary>
        /// The test method for the list of expenses by the given month and type
        /// </summary>
        [TestMethod]
        public void TestGetExpensesByMonthAndType()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = new DateTime(2012, 12, 21, 15, 30, 00);
            ec.RegisterExpense(type, pay1, date, "AAA");

            DateTime date1 = DateTime.Now;
            ec.RegisterExpense(type, pay1, date1, "BBB");

            List<Expense> list = ec.GetExpensesByTypeAndMonth(type, date1.Month, date1.Year);
            Assert.AreEqual(String.Format("Expense:\nDescription: BBB\nType: AAA - aaa\nPayment: Payment: Money\nCurrency: EUR\nAmount: 15\nDate: {0}", date1), list[0].ToString());
        }

        /// <summary>
        /// The test method to get the month stats
        /// </summary>
        [TestMethod]
        public void TestGetMonthStats()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = DateTime.Now;
            date.Subtract(new TimeSpan(15, 0, 0, 0));
            ec.RegisterExpense(type, pay1, date, "AAA");

            double amount1 = ec.GetMonthStats();
            Assert.AreEqual(-15, amount1);

            Payment pay2 = new Payment(money1, 20);
            DateTime date2 = DateTime.Now.Subtract(new TimeSpan(35, 0, 0, 0));
            ec.RegisterExpense(type, pay2, date2, "BBB");

            double amount2 = ec.GetMonthStats();
            Assert.AreEqual(5, amount2);
        }

        /// <summary>
        /// The test method to get the week stats
        /// </summary>
        [TestMethod]
        public void TestGetWeekStats()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = DateTime.Now;
            date.Subtract(new TimeSpan(5, 0, 0, 0));
            ec.RegisterExpense(type, pay1, date, "AAA");

            double amount1 = ec.GetWeekStats();
            Assert.AreEqual(-15, amount1);

            Payment pay2 = new Payment(money1, 20);
            DateTime date2 = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0));
            ec.RegisterExpense(type, pay2, date2, "BBB");

            double amount2 = ec.GetWeekStats();
            Assert.AreEqual(5, amount2);
        }

        /// <summary>
        /// The test method to get the sum of a list of expenses
        /// </summary>
        [TestMethod]
        public void TestSumExpenses()
        {
            ExpenseController ec = new ExpenseController();
            ExpenseType type = new ExpenseType("AAA", "aaa");
            Money money1 = new Money("EUR");
            Payment pay1 = new Payment(money1, 15);
            DateTime date = DateTime.Now;
            date.Subtract(new TimeSpan(5, 0, 0, 0));
            ec.RegisterExpense(type, pay1, date, "AAA");

            Payment pay2 = new Payment(money1, 20);
            DateTime date2 = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0));
            ec.RegisterExpense(type, pay2, date2, "BBB");

            List<Expense> allExpenses = ec.GetAllExpenses();
            double sum = ec.SumExpenses(allExpenses);

            Assert.AreEqual(35, sum);
        }
    }
}