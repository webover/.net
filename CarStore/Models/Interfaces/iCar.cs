namespace CarStore.Models.Interfaces
{
    interface ICar
    {
        public decimal Price
        {
            set;
            get;
        }

        public Producer Producer
        {
            set;
            get;
        }
    }
}
