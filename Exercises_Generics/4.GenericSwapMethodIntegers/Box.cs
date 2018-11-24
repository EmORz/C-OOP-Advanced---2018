
namespace _3.GenericSwapMethodStrings
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box(List<T> items)
        {
            this.Items = items;
        }
        public List<T> Items { get; set; }

        public void Swap(int ind1, int ind2)
        {
            var temp = this.Items[ind1];
            this.Items[ind1] = this.Items[ind2];
            this.Items[ind2] = temp;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return stringBuilder.ToString();
        }
    }
}
