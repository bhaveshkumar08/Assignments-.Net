In Assignment2(change in GetTransaction() and SBTransaction) folder I applied a different approach to execute the tast.

So, in SBTransaction class I made all the properties (except AccountNumber) as List.

Then in GetTransaction(), I changed the return type from List<SBTransaction> to SBTransaction.
The reason behind this was that, as I already created List of all properties in SBTransaction class (except AccountNumber) so, now only one instance of the 
SBTransaction class having the same accountNumber can hold all the transaction detail (like transactionId, transactionType, etc) in the respective property List.
Hence by traversing over the List<SBTransacton>, searching for the give AccountNumber whoes TransactionDetails are to be fetched, once found then the GetTransaction()
methods needs only to return that instance of the class.
And in tne Main(), from were it was called we can print the transaction details by travesing over each SBTransaction class properties.
