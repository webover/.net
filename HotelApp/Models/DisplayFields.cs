using System.Text;

namespace HotelApp
{
    abstract class DisplayFields
    {
        public void Print()
        {
            var sb = new StringBuilder();

            foreach (var PropertyInfo in GetType().GetProperties())
            {
                sb.AppendLine($"{PropertyInfo.DeclaringType.FullName}  {PropertyInfo.Name} {PropertyInfo.GetValue(this)}");
            }

            System.Console.WriteLine(sb.ToString());
        }
    }
}
