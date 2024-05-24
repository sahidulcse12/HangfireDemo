namespace HangfireDemo.Service
{
    public class Service : IService
    {
        public void CotinuationJob()
        {
            Console.WriteLine("Hello from cotinuation job");
        }

        public void DelayedJob()
        {
            Console.WriteLine("Hello from delayed job");
        }

        public void FireAndForgot()
        {
            Console.WriteLine("Hello from fire and forgot job");
        }

        public void RecurringJOb()
        {
            Console.WriteLine("Hello from Recurring job");
        }
    }
}
