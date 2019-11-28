using System.ComponentModel.DataAnnotations;

namespace HotelApp
{
    /// <summary>
    /// Class Rate amount and currency
    /// </summary>
    /// <remarks>    
    /// </remarks>
    class Rate : DisplayFields
    {
        public decimal amount;
        public Currency curency;
        /// <summary>
        /// The class constructor.
        /// </summary>
        public Rate()
        {

        }
        /// <summary>
        /// The class constructor with amount and currency arguments
        /// </summary>
        public Rate(decimal amount, Currency curency)
        {
            this.amount = amount;
            this.curency = curency;
            /*
            * print Rate
            */
            this.Print();
        }
        //[Required, Range(0, System.Double.PositiveInfinity)]
        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        [Required]
        public Currency Currency
        {
            get { return this.curency; }
            set { this.curency = value; }
        }

    }
}
