using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            // Первый способ создания задачи (не запуска!). Так никто не создаёт задачи.
            Task<int> task = new Task<int>(() => 1);
            Task actionTask = new Task(() => Console.WriteLine("2"));

            // Запуск задачи.
            task.Start();

            // Второй способ создания задачи(тонкая настройка задачи). StartNew и создаёт, и запускает одновременно. Использовать только опытным.
            Task.Factory.StartNew(() => Console.WriteLine(), TaskCreationOptions.LongRunning);

            // Третий способ (запуск CPU bound операции - всегда).
            Task.Run(() => 1);
        }

    }
}
