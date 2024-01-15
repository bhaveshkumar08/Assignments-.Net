using System.Runtime.ConstrainedExecution;
using System;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.ComponentModel;
using Assignment_3.Models;

namespace bank{
    class Test{
        public static void Main(){

            bankRepo bank = new bankRepo();
            
            while(true){
                Console.WriteLine("Menu: ");
                Console.WriteLine("Press 1 to 'Create New Account'");
                Console.WriteLine("Press 2 to 'Deposite Amount'");
                Console.WriteLine("Press 3 to 'Withdraw Amount'");
                Console.WriteLine("Press 4 to 'Get Account Details'");
                Console.WriteLine("Press 5 to 'Get Transactions'");
                Console.WriteLine("Press 6 to 'Get All Account Details'");
                Console.WriteLine("Press 7 to 'EXIT'");

                string? option = Console.ReadLine();

                switch(option){

                    case "1":
                        Console.WriteLine("Enter the Following Details");
                        BhaveshSbaccount cust = new BhaveshSbaccount();

                        Console.WriteLine("Name: ");
                        cust.CustomerName = Console.ReadLine();
                        Console.WriteLine("Address: ");
                        cust.CustomerAddress = Console.ReadLine();

                        try{
                            Console.WriteLine("Current Balance: ");
                            cust.CurrentBalance = decimal.Parse(Console.ReadLine());

                            bank.NewAccount(cust);    
                        }
                        catch(FormatException){
                            Console.WriteLine("Numbers Only Please!!!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Depositing Amount........");
                        try{
                            Console.WriteLine("Enter Account Number: ");
                            int actdep = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Amount: ");
                            decimal amtdep = decimal.Parse(Console.ReadLine());
                            bank.DepositeAmount(actdep, amtdep);
                        }
                        catch(FormatException){
                            Console.WriteLine("Numbers Only Please!!!");
                        }     
                        catch(NegativeAmountException e){
                            Console.WriteLine(e.Message);
                        } 
                        catch(AccountNotFoundException ae){
                            Console.WriteLine(ae.Message);
                        }       
                        break;

                    case "3":
                        Console.WriteLine("WithDrawing Amount........");
                        try{
                            Console.WriteLine("Enter Account Number: ");
                            int actwid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Amount: ");
                            decimal amtwid = decimal.Parse(Console.ReadLine());

                            bank.WithDrawAmound(actwid, amtwid);
                        }
                        catch(FormatException){
                            Console.WriteLine("Numbers Only Please!!!");
                        }     
                        catch(NegativeAmountException e){
                            Console.WriteLine(e.Message);
                        }
                        catch(AccountNotFoundException ae){
                            Console.WriteLine(ae.Message);
                        }
                        catch(LowBalanceException le){
                            Console.WriteLine(le.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Fetching Account Details........");

                        try{
                            Console.WriteLine("Enter Account Number: ");
                            int actdet = Convert.ToInt32(Console.ReadLine());
                            BhaveshSbaccount custDetail = bank.GetAccountDetails(actdet);
                            Console.WriteLine("Name :"+custDetail.CustomerName);
                            Console.WriteLine("Address :"+custDetail.CustomerAddress);
                            Console.WriteLine("Current Balance :"+custDetail.CurrentBalance);
                            Console.WriteLine("Account No. :"+custDetail.AccountNumber);
                        }
                        catch(FormatException){
                            Console.WriteLine("Numbers Only Please!!!");
                        }
                        catch(AccountNotFoundException e){
                            Console.WriteLine(e.Message);
                        }                       
                        break;
                    case "5":
                        Console.WriteLine("Fetching Transaction Details........");
                        try{
                            Console.WriteLine("Enter Account Number: ");
                            int acttran = Convert.ToInt32(Console.ReadLine());

                            List<BhaveshSbtransaction> transDetail = bank.GetTransactions(acttran);
                        
                            Console.WriteLine("Traction under Account No. "+transDetail[0].AccountNumber+" are listed below :");

                            foreach (var item in transDetail)
                            {
                                Console.WriteLine("("+item.TransactionDate+") "+"Transaction ID :"+item.TransactionId+"    "+item.TransactionType+"  "+item.Amount);
                                 
                            }
                        }
                        catch(FormatException){
                            Console.WriteLine("Numbers Only Please!!!");
                        }
                        catch(AccountNotFoundException ae){
                            Console.WriteLine(ae.Message);
                        }
                        
                        break;
                    case "6":
                        Console.WriteLine("Fetching All Account Details........");                        
                        List<BhaveshSbaccount> allAccDetail;

                        allAccDetail = bank.GetAllAccount();
                        if(allAccDetail.Count() != 0){ //if no account is created.
                            int counts = 1;
                            foreach (var item in allAccDetail)
                            {
                                Console.WriteLine("Account "+counts);
                                Console.WriteLine("Name :"+item.CustomerName);
                                Console.WriteLine("Address :"+item.CustomerAddress);
                                Console.WriteLine("Current Balance :"+item.CurrentBalance);
                                Console.WriteLine("Account No. :"+item.AccountNumber);
                                counts++;
                            }
                        }
                        else{
                            Console.WriteLine(" NO Account created YET ");
                        }
                
                                               
                        break;
                    
                    case "7":{
                        Console.WriteLine("EXIT PROGRAM");
                        break;
                    }

                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }

                if(option == "7"){ //to exit the infinit ture while loop.
                    break;
                }

            }
        }
    }
}