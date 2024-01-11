using System;
using System.Security.Cryptography;

namespace B{

    class Client{

        public static void Main(){
            Permanent p1 = new Permanent();
            Trainee t1 = new Trainee();

            Console.WriteLine("Enter the details of Permanent Employee : ");
            p1.GetDetails();
            p1.CalculateSalary();
            p1.ShowDetails();

            Console.WriteLine("Enter the details of Trainee : ");
            t1.GetDetails();
            t1.CalculateSalary();
            t1.ShowDetails();
        }
    }
}