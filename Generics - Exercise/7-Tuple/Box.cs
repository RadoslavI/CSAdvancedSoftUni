using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box1
{
    public class Box<T> : IComparable<T> where T : IComparable<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elementsList)
        {
            ElementsList = elementsList;
        }

        public List<T> ElementsList { get; }
        public T Element { get; }

        public int CompareTo(T other)
        => Element.CompareTo(other);

        public int CountOfGreaterElements<T>(List<T> list, T ReadLine) where T : IComparable
            => list.Count(word => word.CompareTo(ReadLine) > 0);


        public void Swap(List<T> elements, int indexOne, int indexTwo)
        {
            T firstElement = elements[indexOne];
            elements[indexOne] = elements[indexTwo];
            elements[indexTwo] = firstElement;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (T element in ElementsList)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
            //return $"{typeof(T)}: {Element}";
        }

    }
}
