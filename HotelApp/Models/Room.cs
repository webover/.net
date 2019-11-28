namespace HotelApp
{
    /// <summary>
    /// Class Room keeps details about room name, rate, number of adults and number of children
    /// </summary>
    /// <remarks>    
    /// </remarks>
    class Room : DisplayFields
    {
        private string name;
        private Rate rate;
        private byte adults;
        private byte children;

        public Room()
        {

        }

        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public Rate Rate
        {
            set
            {
                this.rate = value;
                /*
                 * Print rate
                 */
                this.rate.Print();
            }
            get { return this.rate; }
        }

        public byte Adults
        {
            set { this.adults = value; }
            get { return this.adults; }
        }

        public byte Children
        {
            set { this.children = value; }
            get { return this.children; }
        }

        public decimal GetPriceForDays(int days)
        {
            return this.Rate.Amount * days;
        }
    }
}
