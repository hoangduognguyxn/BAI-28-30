// EditNumber.cs
using System;

public class EditNumbers
{
    public static int nhapsonguyenduong()
    {
        int n = 0;
        while (true)
        {
            try
            {
                Console.WriteLine("Nhập số nguyên dương:");
                n = int.Parse(Console.ReadLine());
                if (n > 0)
                    break;
                else
                    Console.WriteLine("Vui lòng nhập số nguyên dương!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
        return n;
    }

    public static float nhapsothuc4byte()
    {
        float x = 0.0f;
        while (true)
        {
            try
            {
                Console.WriteLine("Nhập số thực 4 byte:");
                x = float.Parse(Console.ReadLine());
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
        return x;
    }
}

public class array_float_2d
{
    private float[,] a;

    public void nhapmangfloat2d(int m, int n)
    {
        a = new float[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Nhập phần tử [{i},{j}]: ");
                a[i, j] = float.Parse(Console.ReadLine());
            }
        }
    }

    public void hienthimangfloat2d()
    {
        if (a == null)
        {
            Console.WriteLine("Mảng chưa được khởi tạo.");
            return;
        }

        int m = a.GetLength(0);
        int n = a.GetLength(1);

        Console.WriteLine("Hiển thị mảng 2 chiều:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(a[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void ghimang2dfloat_file_csv(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                int m = a.GetLength(0);
                int n = a.GetLength(1);

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        writer.Write(a[i, j]);
                        if (j < n - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine($"Ghi mảng vào file {fileName} thành công.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi ghi file: {ex.Message}");
        }
    }

    public float[,] docmang2dfloat_file_csv(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);
            int m = lines.Length;
            int n = lines[0].Split(',').Length;

            float[,] b = new float[m, n];

            for (int i = 0; i < m; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < n; j++)
                {
                    b[i, j] = float.Parse(values[j]);
                }
            }

            Console.WriteLine($"Đọc mảng từ file {fileName} thành công.");
            return b;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            return null;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int m = EditNumbers.nhapsonguyenduong();
        int n = EditNumbers.nhapsonguyenduong();
        float x = EditNumbers.nhapsothuc4byte();

        Console.WriteLine($"Giá trị m: {m}");
        Console.WriteLine($"Giá trị n: {n}");
        Console.WriteLine($"Giá trị x: {x}");

        array_float_2d ob = new array_float_2d();
        ob.nhapmangfloat2d(m, n);

        ob.hienthimangfloat2d();

        ob.ghimang2dfloat_file_csv("a2d.csv");

        float[,] b = ob.docmang2dfloat_file_csv("a2d.csv");
        if (b != null)
        {
            Console.WriteLine("Mảng b sau khi đọc từ file:");
            int mRead = b.GetLength(0);
            int nRead = b.GetLength(1);
            for (int i = 0; i < mRead; i++)
            {
                for (int j = 0; j < nRead; j++)
                {
                    Console.Write(b[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
