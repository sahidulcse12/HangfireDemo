namespace HangfireDemo.Service
{
    public interface IService
    {
        void FireAndForgot();
        void RecurringJOb();
        void DelayedJob();
        void CotinuationJob();
    }
}
