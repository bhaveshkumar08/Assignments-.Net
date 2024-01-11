In Assignment2(change in GetTransaction() and SBTransaction) folder I applied a different approach to execute the tast.

So, in SBTransaction class I made all the properties (except AccountNumber) as List.

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

Then in GetTransaction(), I changed the return type from List<SBTransaction> to SBTransaction.
The reason behind this was that, as I already created List of all properties in SBTransaction class (except AccountNumber) so, now only one instance of the 
SBTransaction class having the same accountNumber can hold all the transaction detail (like transactionId, transactionType, etc) in the respective property 
List. Hence by traversing over the List<SBTransacton>, searching for the give AccountNumber whoes TransactionDetails are to be fetched, once found then the GetTransaction() methods needs only to return that instance of the class.

public SBTransaction GetTransactions(int accno){
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

And in tne Main(), from were it was called we can print the transaction details by travesing over each SBTransaction class properties.

SBTransaction transDetail = bank.GetTransactions(acttran);
                        
if(transDetail != null){
  Console.WriteLine("Traction under Account No. "+transDetail.AccountNo+" are listed below :");

  for(int i = 0; i < transDetail.TransactionId.Count; i++){
      Console.WriteLine("Transaction Type :"+transDetail.TransactionType[i]);
      Console.WriteLine("Transaction ID :"+transDetail.TransactionId[i]);
      Console.WriteLine("Transaction Date :"+transDetail.TransactionDate[i]);
      Console.WriteLine("Amount :"+transDetail.Amount[i]);
  }
}
