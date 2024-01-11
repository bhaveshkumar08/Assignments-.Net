using System;

namespace bank
{

    class SBAccount{
        public int AccountNo{set; get;}
        public string? CustomerName{set; get;}
        public string? CustomerAddress{set; get;}
        public decimal CurrentBalance{set; get;}

        public SBAccount(){

        }
        public SBAccount(int acc, string? n, string? add, decimal bal){
            AccountNo = acc;
            CustomerName = n;
            CustomerAddress = add;
            CurrentBalance = bal;
        }
    }
    class SBTransaction{
        public List<int> TransactionId { get; set; } = new List<int>();
        public List<DateTime> TransactionDate { get; set; } = new List<DateTime>();
        public int AccountNo { get; set; }
        public List<decimal> Amount { get; set; } = new List<decimal>();
        public List<string> TransactionType { get; set; } = new List<string>();

        public SBTransaction(){}

        public SBTransaction(int acc){
            AccountNo = acc;
        }
    }

    class BankRepository : IBankRepository
    {

        // collection of SBAccount class:
        public List<SBAccount> Sbacc = new List<SBAccount>();

        // collection of SBTransaction class:
        public List<SBTransaction> Sbtra = new List<SBTransaction>();

        public void DepositeAmount(int accno, decimal amt)
        {
            foreach(var item in Sbacc){
                if(item.AccountNo == accno){
                    item.CurrentBalance += amt;
                    break;
                }
            }
            foreach(var item in Sbtra){
                if(item.AccountNo == accno){ //updation the transaction list details with repect to the account no.
                    Console.WriteLine("Please Give Transaction ID: ");
                    int tid = Convert.ToInt32(Console.ReadLine());
                    item.TransactionId.Add(tid);
                    item.TransactionDate.Add(DateTime.Now);
                    item.Amount.Add(amt);
                    item.TransactionType.Add("credit");
                    break;
                }
            }

        }

        public SBAccount GetAccountDetails(int accno)
        {
            // SBAccount temp;
            // foreach(var item in Sbacc){
            //     if(item.AccountNo == accno){
            //         temp = item;
            //         break;
            //     }
            // }
            // return temp;

            int foundIndex = -1;

            for(int i = 0; i < Sbacc.Count(); i++){
                if(Sbacc[i].AccountNo == accno){
                    foundIndex = i;
                }
            }

            if(foundIndex == -1){ //if the account no. give by user is not present
                Console.WriteLine("Not found");
                return null;
            }

            return Sbacc[foundIndex];
        }

        public List<SBAccount> GetAllAccount()
        {
            return Sbacc;
        }

        public SBTransaction GetTransactions(int accno)
        {
            int foundIndex = -1;
            for(int i = 0; i < Sbtra.Count(); i++){
                if(Sbtra[i].AccountNo == accno){
                    foundIndex = i;
                }
            }
            if(Sbtra[foundIndex].TransactionId.Count() == 0){
                Console.WriteLine("No Transaction yet");
                return null;
            }
            return Sbtra[foundIndex];
        }

        public void NewAccount(SBAccount acc)
        {
            for(int i = 0; i < Sbacc.Count(); i++){ //check if account no. already exits.
                if(Sbtra[i].AccountNo == acc.AccountNo){
                    Console.WriteLine(" ACCOUNT NUMBER ALREADY EXITS - enter different Account No. ");
                    return;
                }
            }

            Sbacc.Add(acc);

            Sbtra.Add(new SBTransaction(acc.AccountNo)); //adding new instance of SBTransaction class correponding to this account no.
        }

        public void WithDrawAmound(int accno, decimal amt)
        {
            foreach(var item in Sbacc){
                if(item.AccountNo == accno){
                    if(item.CurrentBalance > amt){
                        item.CurrentBalance -= amt;
                        break;
                    }
                    else{
                        Console.WriteLine("'Current Balance is low'");
                        return;
                    }
                }
            }
            foreach(var item in Sbtra){
                if(item.AccountNo == accno){ //updation the transaction list details with repect to the account no.
                    Console.WriteLine("Please Give Transaction ID: ");
                    int tid = Convert.ToInt32(Console.ReadLine());
                    item.TransactionId.Add(tid);
                    item.TransactionDate.Add(DateTime.Now);
                    item.Amount.Add(amt);
                    item.TransactionType.Add("debit");
                    break;
                }
            }
        }
    }
}
