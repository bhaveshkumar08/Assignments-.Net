using System;
using Ie;

namespace B{
    class Employee:IEmployee{

        public int Empid{set;get;}
        public string? Empname{set;get;}
        public float Salary{set;get;}
        public DateTime Doj{set;get;}

        public virtual void CalculateSalary(){

        }

        public void GetDetails()
        {
            Console.WriteLine("Enter Your EID : ");
            Empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Your Name : ");
            Empname = Console.ReadLine();
            Console.WriteLine("Enter DOJ : ");
            Doj = Convert.ToDateTime(Console.ReadLine());
        }

        public void ShowDetails()
        {
            Console.WriteLine("Your EID is : " +Empid);
            Console.WriteLine("Your Name is : " +Empname);
            Console.WriteLine("Your DOJ is : " +Doj.ToShortDateString());
        }
    }

    class Permanent:Employee{
        public float BasicPay{set;get;}
        public float HRA{set;get;}
        public float DA{set;get;}
        public float PF{set;get;}

        public new void GetDetails(){
            base.GetDetails();
            Console.WriteLine("Basic Pay of permanet employee : ");
            BasicPay = float.Parse(Console.ReadLine());
            Console.WriteLine("HRA of permanet employee : ");
            HRA = float.Parse(Console.ReadLine());
            Console.WriteLine("DA of permanet employee : ");
            DA = float.Parse(Console.ReadLine());
            Console.WriteLine("PF of permanet employee : ");
            PF = float.Parse(Console.ReadLine());
        }
        public new void ShowDetails(){
            base.ShowDetails();
            Console.WriteLine("Basic Pay of permanet employee : " +BasicPay);
            Console.WriteLine("HRA of permanet employee : "+HRA);
            Console.WriteLine("DA of permanet employee : "+DA);
            Console.WriteLine("PF of permanet employee : "+PF);
            Console.WriteLine("SALARY IS : "+Salary);
        }

        public override void CalculateSalary(){
            Salary = BasicPay + HRA + DA - PF;
        }
    }
    class Trainee:Employee{
        public float BasicPay{set;get;}
        public float Bonus{set;get;}
        public string ProjectName{set;get;}

        public new void GetDetails(){
            base.GetDetails();
            Console.WriteLine("Basic Pay of trainee : ");
            BasicPay = float.Parse(Console.ReadLine());
            Console.WriteLine("Project Name : ");
            ProjectName = Console.ReadLine();
        }
        public new void ShowDetails(){
            base.ShowDetails();
            Console.WriteLine("Basic Pay of trainee : " +BasicPay);
            Console.WriteLine("Bonus : " +Bonus);
            Console.WriteLine("ProjectName : " +ProjectName);
            Console.WriteLine("SALARY : " +Salary);

        }

        public override void CalculateSalary(){
            if(ProjectName == "Banking"){
                Bonus = 0.05f*BasicPay;
            }
            else if(ProjectName == "Insurance"){
                Bonus = 0.1f*BasicPay;
            }
            Salary = Bonus + BasicPay;
        }
    }
}
