using System;

namespace bank
{
    // Excepton Handiling:
    class AccountNotFoundException:ApplicationException{
        public AccountNotFoundException(string message):base(message){}
    }
    class NegativeAmountException:ApplicationException{
        public NegativeAmountException(string message):base(message){}
    }
    class LowBalanceException:ApplicationException{
        public LowBalanceException(string message):base(message){}
    }

    class SBAccount{
        public int AccountNo{set; get;}
        public string? CustomerName{set; get;}
        public string? CustomerAddress{set; get;}
        public decimal CurrentBalance{set; get;}

        public SBAccount(){}
        public SBAccount(int acc, string? n, string? add, decimal bal){
            AccountNo = acc; 
            CustomerName = n;
            CustomerAddress = add;
            CurrentBalance = bal;
        }
    }
    class SBTransaction{
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNo { get; set; }
        public decimal Amount { get; set; }
        public string? TransactionType { get; set; }

        public SBTransaction(){}
        public SBTransaction(int tid, DateTime tdate, int acc, decimal amt, string ttype){
            TransactionId = tid;
            TransactionDate = tdate;
            AccountNo = acc;
            Amount = amt;
            TransactionType = ttype;
        }
    }

    class BankRepository : IBankRepository
    {
        public int TransactionId = 1000;

        // collection of SBAccount class:
        public List<SBAccount> Sbacc = new List<SBAccount>();

        // collection of SBTransaction class:
        public List<SBTransaction> Sbtra = new List<SBTransaction>();

        public void DepositeAmount(int accno, decimal amt)
        {
            if(amt <= 0){ //deposite amount is smaller than zero.
                throw new NegativeAmountException("Invalid Amount!!!");
            }
            bool accValid = false;
            foreach(var item in Sbacc){
                if(item.AccountNo == accno){
                    item.CurrentBalance += amt;
                    SBTransaction temp = new SBTransaction(++TransactionId, DateTime.Now, accno, amt, "Credit");
                    Sbtra.Add(temp);
                    accValid = true;
                    break;
                }
            }
            if(accValid == false){
                throw new AccountNotFoundException("Account Not Found!!!");
            }
        }

        public SBAccount GetAccountDetails(int accno)
        {
            bool accValid = false;
            SBAccount temp = new SBAccount();

            for(int i = 0; i < Sbacc.Count(); i++){
                if(Sbacc[i].AccountNo == accno){
                    temp = Sbacc[i];
                    accValid = true;
                    break;
                }
            }

            if(accValid == false){ //if the account is not present
                throw new AccountNotFoundException("Account Not Found!!!");
            }

            return temp;
        }

        public List<SBAccount> GetAllAccount()
        {
            return Sbacc;
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            List<SBTransaction> temp = new List<SBTransaction>();
            foreach(var i in Sbtra){
                if(i.AccountNo == accno){
                    temp.Add(i);
                }
            }

            if(temp.Count() == 0){
                throw new AccountNotFoundException("No Transactions!!!");
            }

            return temp;
        }

        public void NewAccount(SBAccount acc)
        {
            foreach(var i in Sbacc){ //check if account no. already exits.
                if(i.AccountNo == acc.AccountNo){
                    Console.WriteLine(" ACCOUNT NUMBER ALREADY EXITS - enter different Account No. ");
                    return;
                }
            }

            Sbacc.Add(acc);
        }

        public void WithDrawAmound(int accno, decimal amt)
        {
            if(amt <= 0){ //withdrawing amount is smaller than zero.
                throw new NegativeAmountException("Invalid Amount!!!");
            }
            bool accValid = false;
            foreach(var item in Sbacc){
                if(item.AccountNo == accno){
                    if(item.CurrentBalance > amt){
                        item.CurrentBalance -= amt;
                        SBTransaction temp = new SBTransaction(++TransactionId, DateTime.Now, accno, amt, "Debit");
                        Sbtra.Add(temp);
                        accValid = true;
                        break;
                    }
                    else{
                        throw new LowBalanceException("Sorry, Your Balance is Low !!!");
                    }
                }
            }
            if(accValid == false){
                throw new AccountNotFoundException("Account Not Found!!!");
            }
        }
    }
}
