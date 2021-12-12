using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_22
{
    class Program
    // Сформировать массив случайных целых чисел(размер задается пользователем).
    // Вычислить сумму чисел массива и максимальное число в массиве.
    // Реализовать решение  задачи с  использованием механизма  задач продолжения.
    {
        //объявление переменных
        static int[] massivM;
        static int w;
        static int summa;
        static int max;
        static void Main(string[] args)
        {
            //Запрос размера массива
            Console.WriteLine("Задайте размер массива");
            w = Convert.ToInt32(Console.ReadLine());
            summa = 0;
            max = 0;
            massivM = new int[w];
            Random random = new Random();
            //заполнение массива случайными числами
            for (int i = 0; i < massivM.Length; i++)
            {
                massivM[i] = random.Next(100);
                Console.WriteLine($"Значение индекса = {i}\nЗначение элемента = {massivM[i]}");
            }
            //Создание задач
            Action action = new Action(SummaMassiva);
            Action<Task> action2 = new Action<Task>(MaxMassiva);
            Task task1 = new Task(action);
            Task task2 = task1.ContinueWith(action2);
            task1.Start();
            task2.Wait();
            Console.WriteLine($"Сумма чисел равна {summa}\nМаксимальное число равно {max}" );
            

            Console.ReadKey();
        }
        //создание методов нахождения суммы и максимума
        static void SummaMassiva()
        {
            summa = massivM.Sum();
            
        }
        static void MaxMassiva(Task task)
        {
            max = massivM.Max();
            
        }

    }


}
