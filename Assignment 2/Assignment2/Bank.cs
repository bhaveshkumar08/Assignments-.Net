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
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int AccountNo { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }

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

                    SBTransaction temp = new SBTransaction();
                    temp.AccountNo = accno;

                    item.CurrentBalance += amt;

                    Console.WriteLine("Please Give Transaction ID: ");
                    temp.TransactionId = Convert.ToInt32(Console.ReadLine());
                    temp.TransactionDate = DateTime.Now;
                    temp.Amount = amt;
                    temp.TransactionType = "credit";
                    Sbtra.Add(temp);
                    break;
                }
            }
        }

        public SBAccount GetAccountDetails(int accno)
        {
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

        public List<SBTransaction> GetTransactions(int accno)
        {
            int foundIndex = -1;
            List<SBTransaction> temp = new List<SBTransaction>();
            for(int i = 0; i < Sbtra.Count(); i++){
                if(Sbtra[i].AccountNo == accno){
                    temp.Add(Sbtra[i]);
                    Console.WriteLine(i);
                    foundIndex = i;
                }
            }

            if(foundIndex == -1){
                Console.WriteLine("No Transaction yet");
            }

            return temp;
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
        }

        public void WithDrawAmound(int accno, decimal amt)
        {
            foreach(var item in Sbacc){
                if(item.AccountNo == accno){
                    if(item.CurrentBalance > amt){
                        
                        SBTransaction temp = new SBTransaction();
                        temp.AccountNo = accno;

                        item.CurrentBalance -= amt;

                        Console.WriteLine("Please Give Transaction ID: ");
                        temp.TransactionId = Convert.ToInt32(Console.ReadLine());
                        temp.TransactionDate = DateTime.Now;
                        temp.Amount = amt;
                        temp.TransactionType = "debit";
                        Sbtra.Add(temp);
                        break;
                    }
                    else{
                        Console.WriteLine("'Current Balance is low'");
                        return;
                    }
                }
            }
        }
    }
}
