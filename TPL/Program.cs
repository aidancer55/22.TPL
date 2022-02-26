using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(SummArray);
            Task task1 = new Task(action);

            Action<Task, object> actionTask = new Action<Task, object>(MaxArray);
            Task task2 = task1.ContinueWith(actionTask, 100);

            task1.Start();
            Console.ReadKey();
        }

        static void SummArray()
        {
            const int n = 15;
            int[] array = new int[n];
            int sum = 0;
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write($"{array[i]} ");
                sum += array[i];
            }
            Console.WriteLine();
            Console.WriteLine("Сумма чисел равна {0}", sum);
            Console.WriteLine();
        }

        static void MaxArray(Task task, object a)
        {
            int n = (int) a;
            n = 15;
            int[] array = new int[n];
            Random random = new Random();
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
                Console.Write($"{array[i]} ");
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Максимальное число равно {0}", max);
        }
    }
}
