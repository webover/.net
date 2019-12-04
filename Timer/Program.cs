namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.TimeDelegate timeDelegate = Timer.Message;

            timeDelegate += Timer.Message;
            timeDelegate += Timer.Message;
            timeDelegate += Timer.Message;

            timeDelegate(2);
        }
    }
}
