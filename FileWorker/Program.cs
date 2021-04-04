using System;

namespace FileWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AFileWorker fw = new AFileWorker("text.txt", AFileWorker.Mode.Read))
            {
                fw.Write();
                fw.Read();
                
            }
            Console.WriteLine("------------------------------");
            AFileWorker fw2 = new AFileWorker("text.txt", AFileWorker.Mode.Write);
            fw2.Read();
            fw2.Write();
            fw2.Dispose();
        }
    }
}
