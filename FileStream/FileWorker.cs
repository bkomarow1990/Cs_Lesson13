using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream
{
    class FileWorker
    {
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
    }
}
