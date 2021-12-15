using System;
using System.Collections.Generic;
using System.Text;

namespace McLaughlinUniversity
{
    class Transaction
    {
        private double transactionAmount;
        private DateTime transactionDate;
        private int transactionDonorID;
        private int transactionProgramID;
        private int transactionCommitteeID;

        public Transaction(double amount, DateTime date, int donorID, int programID, int committeeID)
        {
            this.transactionAmount = amount;
            this.transactionDate = date;
            this.transactionDonorID = donorID;
            this.transactionProgramID = programID;
            this.transactionCommitteeID = committeeID;

            DataAccess.InsertNewTransaction(this);
        }

        public Transaction()
        {

        }

        public double Amount
        {
            get
            {
                return transactionAmount;
            }
            set
            {
                transactionAmount = value;

                if (transactionAmount.ToString() == "")
                {
                    throw new ArgumentException("Please enter transaction amount", "Transaction Amount Error");
                }
                else if (transactionAmount < 0)
                {
                    throw new ArgumentException("Transaction amount cannot be less than 0", "Transaction Amount Error");
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return transactionDate;
            }
            set
            {
                transactionDate = value;
            }
        }

        public int DonorID
        {
            get
            {
                return transactionDonorID;
            }
            set
            {
                transactionDonorID= value;
            }
        }

        public int ProgramID
        {
            get
            {
                return transactionProgramID;
            }
            set
            {
                transactionProgramID = value;
            }
        }

        public int CommitteeID
        {
            get
            {
                return transactionCommitteeID;
            }
            set
            {
                transactionCommitteeID = value;
            }
        }

        public string ShowMessage()
        {
            string message = "New Transaction has been added successfully!\n\n\n" +
                "Transaction Amount: " + this.transactionAmount + "\n" +
                "Transaction Date: " + this.transactionDate + "\n" +
                "Donor ID: " + this.transactionDonorID + "\n" +
                "Program ID: " + this.transactionProgramID + "\n" +
                "Commitee ID: " + this.transactionCommitteeID + "\n";
            return message;
        }
    }
}
