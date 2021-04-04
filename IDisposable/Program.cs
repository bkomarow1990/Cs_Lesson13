using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposable_
{
    class DBConnection : IDisposable
    {
        private string nameDb;
        private bool isOpen;
        private bool isDisposed;
        public string NameDb {
            get => nameDb;
            set => nameDb=value;
        }
        public DBConnection(string name="NoName")
        {
            this.NameDb = name;
            Console.WriteLine("Db connection ctor");
        }
        public void Work() {
            Console.WriteLine("We got all records from table....");
        }
        public void Open(string nameDb) {
            if (isOpen)
            {
                Console.WriteLine($"DB {nameDb} is open now");
            }
            else
            {
                isOpen = true;
                this.nameDb = nameDb;
            }
        }
        public void Dispose() {
            if (!isDisposed)
            {
                isOpen = false;
                Console.WriteLine("Disposed done");
                isDisposed = true;
                GC.SuppressFinalize(this);
            }
            
        }
        ~DBConnection()
        {
            Dispose();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DBConnection dc = new DBConnection();
            dc.Open("aa.mdf");
            dc.Work();
            GC.Collect(0);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
