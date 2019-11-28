using static CarStore.Models.Producer;

namespace CarStore.Models.Interfaces
{
    interface IProducer
    {
        Brand Model
        {
            get;
            set;
        }
        int Year
        {
            get;
        }
    }
}
