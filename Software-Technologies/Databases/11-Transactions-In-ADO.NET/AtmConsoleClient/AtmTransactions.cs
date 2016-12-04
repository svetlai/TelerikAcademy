namespace AtmConsoleClient
{
    using AtmModel;
    using System;
    using System.Linq;
    using System.Transactions;

    public class AtmTransactions
    {
        public static void Main()
        {
            var db = new ATMEntities();

            var account = new CardAccount
            {
                CardNumber = "0000000001",
                CardPin = "0001",
                CardCash = 1000
            };

            db.CardAccounts.Add(account);
            db.SaveChanges();
            Console.WriteLine("New Account created.");

            decimal withdrawn = WithdrawMoney("0000000001", "0001", 200);
            SaveTransactionsHistory("0000000001", withdrawn);
        }

        /// <summary>
        /// 2. Using transactions write a method which retrieves some money (for example $200) from certain account. 
        /// The retrieval is successful when the following sequence of sub-operations is completed successfully:
        ///A query checks if the given CardPIN and CardNumber are valid.
        ///The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum 
        ///(more than $200).
        ///The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount 
        ///(CardCash = CardCash - 200).
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="cardPin"></param>
        /// <param name="moneyAmount"></param>
        public static decimal WithdrawMoney(string cardNumber, string cardPin, decimal moneyAmount)
        {
            var db = new ATMEntities();
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var account = db.CardAccounts
                    .FirstOrDefault(a => a.CardNumber == cardNumber && a.CardPin == cardPin);

                if (account == null)
                {
                    tran.Dispose();
                    throw new InvalidOperationException("Wrong CardNumber or PIN!");
                }

                if(moneyAmount > account.CardCash)
                {
                    tran.Dispose();
                    throw new InvalidOperationException("Not enough money in account.");
                }

                account.CardCash = account.CardCash - moneyAmount;
                db.SaveChanges();

                Console.WriteLine("Money withdrawed successfully. New balance: {0}", account.CardCash);
                tran.Complete();
            }

            return moneyAmount;
        }

        /// <summary>
        /// 3. Extend the project from the previous exercise and add a new table TransactionsHistory with fields 
        /// (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
        /// Modify the program logic so that it saves historical information (logs) in the new table after each 
        /// successful money withdrawal.
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="moneyAmmount"></param>
        public static void SaveTransactionsHistory(string cardNumber, decimal moneyAmmount)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var db = new ATMEntities();
                var acc = db.CardAccounts
                    .FirstOrDefault(c => c.CardNumber == cardNumber);

                var transactionLog = new TransactionsHistory
                {
                    CardNumber = cardNumber,
                    Ammount = moneyAmmount,
                    TransactionDate = DateTime.Now,
                    CardAccountId = acc.Id
                };

                db.TransactionsHistories.Add(transactionLog);
                db.SaveChanges();

                Console.WriteLine("Date: {0} | Account: {1} | Withdrawn ammount: {2}", transactionLog.TransactionDate, transactionLog.CardNumber, transactionLog.Ammount);
                tran.Complete();
            }
        }
    }
}
