using System;
using Assignment_3.Models;
namespace bank{

    interface IBankRepository{

        public void NewAccount(BhaveshSbaccount acc);
        public List<BhaveshSbaccount> GetAllAccount();

        public BhaveshSbaccount GetAccountDetails(int accno);
        public void DepositeAmount(int accno, decimal amt);
        public void WithDrawAmound(int accno, decimal amt);

        public List<BhaveshSbtransaction> GetTransactions(int accno);
    }
}