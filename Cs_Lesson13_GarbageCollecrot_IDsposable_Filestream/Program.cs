using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Lesson13_GarbageCollecrot_IDsposable_Filestream
{
    class Demo
    {
        private static int lastId = 0;
        int[] arr;
        public static int DefaultSize = 100000;
        public readonly int ID = ++lastId;
        public Demo()
        {
            arr = new int[DefaultSize];
            Console.WriteLine($"Was created blokc # {ID}");
        }
        ~Demo() // finalizer
        {
            Console.WriteLine($"~~~~~~~~~~ Removed block {ID}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
        }
    }
}
