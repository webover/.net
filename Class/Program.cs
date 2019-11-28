namespace Class
{
    class Program : Hotel
    {
        private const int V = 10;

        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[5][];
            jaggedArray[0] = new int[] { 1, 2, 3 }; // 3 item array
            jaggedArray[1] = new int[10]; // 10 item array
            jaggedArray[2] = new int[10]; // 10 item array
            jaggedArray[3] = new int[10]; // 10 item array
            jaggedArray[4] = new int[10]; // 10 item array
        }

        public override string Name
        {
            get { return this.name; }
            //set { this.name = value; }
        }


    }

    struct MyName()
        {
        }

}
