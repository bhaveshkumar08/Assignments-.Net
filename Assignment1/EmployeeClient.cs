using System;
using System.Security.Cryptography;

namespace A{

    class Client{

        public static void main(){
            Permanent p1 = new Permanent();
            Trainee t1 = new Trainee();

            Console.WriteLine("Enter the details of Permanent Employee : ");
            p1.AcceptDetail();
            p1.GetDetails();
            p1.CalculateSalary();
            p1.DisplayDetail();
            p1.ShowDetails();

            Console.WriteLine("Enter the details of Trainee : ");
            t1.AcceptDetail();
            t1.GetDetails();
            t1.CalculateSalary();
            t1.DisplayDetail();
            t1.ShowDetails();
        }
    }
}