using System;

namespace Customs
{

    public class Custom
    {
        public int cons { get; set; }
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public void SendMsg()
        {
            Console.WriteLine(Console.ReadLine() + " hello " + cons); ;
        }


    }
}