using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskLesson
{
    class Program
    {
        private static readonly bool isLongTermOperation;

        static void Main(string[] args)
        {
            //// Первый способ создания задачи (не запуска!). Так никто не создаёт задачи.
            //var task = new Task<int>(() =>
            //{
            //    Thread.Sleep(1500);
            //    return 1;
            //});
            //var actionTask = new Task(() => Console.WriteLine("2"));

            //// Запуск задачи.
            //task.Start();

            //// Получение результата.
            //while (!task.IsCompleted)
            //{
            //    Console.WriteLine("Идёт работа...");
            //    Thread.Sleep(500);
            //}
            //var result = task.Result;

            //// Второй способ создания задачи(тонкая настройка задачи). StartNew и создаёт, и запускает одновременно. Использовать только опытным.
            //Task.Factory.StartNew(() => Console.WriteLine(), TaskCreationOptions.LongRunning);

            //// Третий способ (запуск CPU bound операции - всегда).
            //Task.Run(() => 1);

            // Отмена операции в процессе выполнения.
            //var cancellationTokenSource = new CancellationTokenSource();
            //var cancellationToken = cancellationTokenSource.Token;

            //var task = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Первая порция");

            //    Thread.Sleep(1000);
            //    Console.WriteLine("Вторая порция");

            //    Thread.Sleep(1000);
            //    Console.WriteLine("Получен результат");
            //    return "Ответ";
            //}, cancellationToken);

            //cancellationToken.ThrowIfCancellationRequested();
            //cancellationTokenSource.Cancel();



            //var result = task.Result;
            //// Dispose для токена и источника
            //Console.ReadLine();

            //LongOperation();

            var task1 = new Task(() => Console.WriteLine(1));

            task1.ContinueWith(resultTask => Console.WriteLine(2))
                 .ContinueWith(resultTask => Console.WriteLine(3))
                 .ContinueWith(resultTask => Console.WriteLine(4));

            var task2 = new Task<int>(() => 1);
            task2.ContinueWith
                (resultTask => Console.WriteLine(resultTask.Result + 100));

            task1.Start(); 
            task2.Start();

            Console.ReadLine();
        }

        private static Task LongOperation()
        {
            if(isLongTermOperation)
            {
                return Task.Run(() => Thread.Sleep(20000));
            }
            else
            {
                var x = 15 + 10;
                Console.WriteLine(x);
                return Task.CompletedTask;
                // Task.FromCanceled(результат); и Task.FromCanceled();
                // Если нужен результат, то return Task.FromResult(результат);
            }

        }

    }
}
