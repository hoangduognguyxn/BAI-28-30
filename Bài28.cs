using ex4;
using System;

namespace ex4
{
    public class class_demo
    {
        public void Show()
        {
            Console.WriteLine("Tôi là một lớp đơn giản!");
        }

        public ushort nhapsonguyen2bytekhongdau()
        {
            ushort n = 0;
            while (true)
            {
                try
                {
                    string sz = Console.ReadLine();
                    n = ushort.Parse(sz);
                    break;
                }
                catch
                {
                    Console.Beep();

                }
            }
            return n;
        }
    }
}


    class Program
    {
        static void Main(string[] args)
        {
            class_demo ob = new class_demo();
            ob.Show();

            Console.WriteLine("Nhập n:");
            ushort n = ob.nhapsonguyen2bytekhongdau();
            Console.WriteLine("n = " + n);
        }
    }
