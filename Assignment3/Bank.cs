using Assignment_3.Models;

namespace bank{
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

    class bankRepo : IBankRepository
    {
        public static Ace52024Context db = new Ace52024Context();

    
        public void NewAccount(BhaveshSbaccount acc)
        {
            db.BhaveshSbaccounts.Add(acc);
            db.SaveChanges();
        }
        public void DepositeAmount(int accno, decimal amt)
        {
            if(amt <= 0){ //deposite amount is smaller than zero.
                throw new NegativeAmountException("Invalid Amount!!!");
            }


            BhaveshSbaccount newAcc = db.BhaveshSbaccounts.Find(accno);

            if(newAcc != null){
                newAcc.CurrentBalance += amt;
                db.BhaveshSbaccounts.Update(newAcc);
                // add the trasaction into db
                BhaveshSbtransaction depTrans = new BhaveshSbtransaction();
                depTrans.AccountNumber = accno;
                depTrans.Amount = amt;
                depTrans.TransactionDate = DateTime.Now;
                depTrans.TransactionType = "Credit";

                db.BhaveshSbtransactions.Add(depTrans);
                db.SaveChanges();
                // db.BhaveshSbaccounts.Add(depTrans);
            }
            else{
                throw new AccountNotFoundException("Account Not Found!!!");
            }
        }

        public void WithDrawAmound(int accno, decimal amt)
        {
            if(amt <= 0){ //deposite amount is smaller than zero.
                throw new NegativeAmountException("Invalid Amount!!!");
            }


            BhaveshSbaccount newAcc = db.BhaveshSbaccounts.Find(accno);

            if(newAcc != null){
                if(newAcc.CurrentBalance < amt){
                    throw new LowBalanceException("Sorry, Your Balance is Low !!!");
                }
                else{
                    newAcc.CurrentBalance -= amt;
                    db.BhaveshSbaccounts.Update(newAcc);
                    // add the trasaction into db
                    BhaveshSbtransaction depTrans = new BhaveshSbtransaction();
                    depTrans.AccountNumber = accno;
                    depTrans.Amount = amt;
                    depTrans.TransactionDate = DateTime.Now;
                    depTrans.TransactionType = "Debit";

                    db.BhaveshSbtransactions.Add(depTrans);
                    db.SaveChanges();
                    // db.BhaveshSbaccounts.Add(depTrans);
                }
            }
            else{
                throw new AccountNotFoundException("Account Not Found!!!");
            }
        }

        public List<BhaveshSbtransaction> GetTransactions(int accno)
        {
            List<BhaveshSbtransaction> transcList = new List<BhaveshSbtransaction>();
            bool validAcc = false;
            foreach (var item in db.BhaveshSbtransactions)
            {
                if(item.AccountNumber == accno){
                    validAcc = true;
                    break;
                }
            }

            if(validAcc == true){
                BhaveshSbaccount newAcc = db.BhaveshSbaccounts.Find(accno);
                foreach(var item in newAcc.BhaveshSbtransactions){
                    transcList.Add(item);
                }
            }
            else{
                throw new AccountNotFoundException("Account Not Found!!!");
            }

            return transcList;
        }
        public BhaveshSbaccount GetAccountDetails(int accno)
        {
            BhaveshSbaccount Acc = db.BhaveshSbaccounts.Find(accno);
            if(Acc == null){
                throw new AccountNotFoundException("Account Not Found!!!");
            }
            return Acc;
        }
        public List<BhaveshSbaccount> GetAllAccount()
        {
            List<BhaveshSbaccount> allAcc = new List<BhaveshSbaccount>();
            foreach (var item in db.BhaveshSbaccounts)
            {
                allAcc.Add(item);
            }
            return allAcc;
        }
    }
}
