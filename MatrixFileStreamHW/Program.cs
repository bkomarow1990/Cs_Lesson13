using System;
using System.IO;

namespace MatrixFileStreamHW
{
    static class DynamicMatrixWorker
    {
        static public void WriteMatrix(string path,DynamicMatrix dm) {
            if (dm.Matrix.Length == 0)
            {
                throw new Exception("Matrix is empty!\a");
            }
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                fs.WriteByte((byte)dm.Matrix.Length);
                for (int i = 0; i < dm.Matrix.Length; i++)
                {
                    fs.WriteByte((byte)dm.Matrix[i].Length);
                    // 1 23 42
                    // 12
                    // 1 321 4124 1 54242
                    // 1231 313 1
                }
                for (int i = 0; i < dm.Matrix.Length; i++)
                {
                    for (int j = 0; j < dm.Matrix[i].Length; j++)
                    {
                        fs.WriteByte(dm.Matrix[i][j]);
                    }
                }
            }
        }
        static public DynamicMatrix ReadMatrix(string path)
        {
            DynamicMatrix dm = new DynamicMatrix();
            
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                byte[] bytes = new byte[1];
                fs.Read(bytes, 0, 1);
                int length = bytes[0];
                byte[] sizes = new byte[length];
                
                for (int i = 0; i < length; i++)
                {
                    fs.Read(bytes, 0, 1);
                    sizes[i] = bytes[0];
                }
                dm.CreateJugged(sizes);
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < sizes[i]; j++)
                    {
                        fs.Read(bytes, 0, 1);

                        dm.Matrix[i][j] = bytes[0];
                    }
                }
            }
            return dm;
        }
    }
    class DynamicMatrix
    {
        public void CreateJugged(params byte[] cols)
        {
            Matrix = new byte[cols.Length][];
            for (int i = 0; i < Matrix.Length; i++)
            {
                Matrix[i] = new byte[cols[i]];
            }
            
        }
        public void Print()
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix[i].Length; j++)
                {
                    Console.Write($"{Matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public byte[][] Matrix;
    }
    class Program
    {
        static void Main(string[] args)
        {
            DynamicMatrix dm1 = new DynamicMatrix();
            dm1.CreateJugged(1, 5, 6, 2, 7, 3, 2, 1);
            Random rnd = new Random();
            for (int i = 0; i < dm1.Matrix.Length; i++)
            {
                for (int j = 0; j < dm1.Matrix[i].Length; j++)
                {
                    dm1.Matrix[i][j] = (byte)rnd.Next(0, 201);
                }
            }
            DynamicMatrixWorker.WriteMatrix("matrix.txt", dm1);
            DynamicMatrix dm2 = DynamicMatrixWorker.ReadMatrix("matrix.txt");
            dm2.Print();
        }
    }
}
