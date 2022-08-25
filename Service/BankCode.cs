using System.ComponentModel.DataAnnotations;

namespace BankCode
{
    public class Eingabe
    {
        public bool einzahlung {get; set; } 
        
        [Required] 
        [Range(0.01, 1000000,
            ErrorMessage= "Betrag zwischen 0,01 Euro und 1 Mio. Euro!")]  
        public decimal Betrag {get; set; } 
        
        [Required]
        public string Notiz {get; set; } 

    } 



    public class Transaction
    {
        // Properties
        public decimal Amount { get; }
        
        public DateTime Date { get; }
        
        public string Notes { get; }

        // Constructor
        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }


    public class BankAccount
    {
        // Properties
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get

            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }


        }
        private static int accountNumberSeed = 1234567890;
        public List<Transaction> allTransactions = new List<Transaction>();

        // Constructor
        public BankAccount(string name, decimal initialBalance)
        {

            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance"); //(#4)

        }

        // Functions
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            //(#2)
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            //(#1)
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            //(#3)
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

    }
}
