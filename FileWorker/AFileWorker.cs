using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWorker
{
   
    class AFileWorker : IDisposable
    {
        public enum Mode { Read= 1 , Write, ReadWrite};
        private bool isOpen=true;
        public string Path { get; set; }
        private bool isDisposed;
        private Mode fileMode;
        public void Dispose()
        {
            if (!isDisposed)
            {
                isOpen = false;
                Console.WriteLine("Disposed done");
                isDisposed = true;
                GC.SuppressFinalize(this);
            }

        }
        public void Read()
        {
            if (fileMode == Mode.Read || fileMode == Mode.ReadWrite)
            {
                Console.WriteLine($"Reading file with path: {Path}");
            }
            else
            {
                Console.WriteLine("Can`t to Read");
            }
        }
        public void Write() {
            if (fileMode == Mode.ReadWrite || fileMode == Mode.Write)
            {
                Console.WriteLine($"Writing file with path: {Path}");
            }
            else
            {
                Console.WriteLine("Can`t to write");
            }
        }
        public AFileWorker(string path, Mode mode)
        {
            this.Path = path;
            this.fileMode = mode;
        }
        ~AFileWorker()
        {
            Dispose();
        }
    }
}
