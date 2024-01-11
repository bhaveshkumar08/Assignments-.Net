using System;

namespace bank{

    interface IBankRepository{

        public void NewAccount(SBAccount acc);
        public List<SBAccount> GetAllAccount();

        public SBAccount GetAccountDetails(int accno);
        public void DepositeAmount(int accno, decimal amt);
        public void WithDrawAmound(int accno, decimal amt);

        public List<SBTransaction> GetTransactions(int accno);
    }
}