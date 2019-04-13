using System;
using System.Threading;
namespace ThreadingTest
{
    class ThreadHandler
    {
        public delegate bool endCount();
        public static endCount endOfCount = new endCount(EndCountMessage);


        //Create a MainThread to output int
        //Create a OtherThread to take in user input
        public static void ThreadCounter()
        { 
            int countAmt = 10;
            int sleepAmt = 1000;

            Console.WriteLine("Begin Count!");
            for (int i = 1; i <= countAmt; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(sleepAmt);
            }
            endOfCount.Invoke();
        }
        public static bool EndCountMessage()
        {
            try
            {
                Console.WriteLine("End of Count!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return true;
        }



        /*static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ThreadStart countThread = new ThreadStart(ThreadCounter);

            do
            {
                Console.WriteLine("Do you want to count?");
                Console.WriteLine("Any Key to continue...");
                Console.ReadKey();
                bool loop = true;
                Thread counter = new Thread(countThread);
                counter.Start();
                do
                {
                    Console.ReadKey();
                } while (loop != false);
                counter.Abort();
            } while (1 < 0);

        }*/
    }
}
