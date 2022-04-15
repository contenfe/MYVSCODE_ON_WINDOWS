using System;

namespace Extends
{
    /***
    * c# 所有的类继承 sObject
    *
    */

    class Parent // TODO 我们的父类
    {
        private int age;
        public int Age
        {
            set
            {
                age = value;
            }
            get
            {
                return age;
            }
        }
        public void ShowInfo()
        {
            Console.WriteLine("父类");
            Age = 12;
        }

        public virtual void Move()
        {
            Console.WriteLine("父类 move");
        }
    }


    class Childer : Parent
    {

        private int age;
        public int Age
        {
            set
            {
                age = value;
            }
            get
            {
                return age;
            }
        }
        public Childer()
        {
            Age = 1;
        }
        // FIXME: bug
        void Test()
        {

        }
        public void ShowInfo()
        {
            Console.WriteLine("子类");
            Age = 14;
        }

        public override void Move()
        {
            Console.WriteLine("子类");
        }
        static void Main(string[] args)
        {
            Childer childer = new Childer();
            childer.ShowInfo();
            Console.WriteLine(childer.Age);
            Console.WriteLine(childer.Age);
        }
    }


    //
    class Tab
    {
        int s;


    }
}