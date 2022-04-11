using System;
//using Customs;
namespace TestDemo
{
    class TestDemo
    {


        static void Main(string[] args)
        {
            Customs.Custom customs = new Customs.Custom();
            customs.SendMsg();

            int[] a1 = new int[]{1,2,3,4,5};
            int[]a2;
            a2=a1;
            a2[2]=100;
            Console.WriteLine(a2[2]+" "+a1[2]);

            Console.WriteLine("TestDemo");

        }
    }
}