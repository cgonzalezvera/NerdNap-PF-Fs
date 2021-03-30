using System;
using System.Collections.Generic;
using System.Linq;
using FsOrdenamientoRapido;
namespace CsUsandoOrdenamiento
{
    class Program
    {
        const char sep = ',';
        static void Main(string[] args)
        {
            Console.WriteLine("QuickSort desde F#");
            Console.Write("Lista separada por comas: ");
            var items = Console.ReadLine();

            var listCs = ToListInt(items);
            var listFs = Microsoft.FSharp.Collections.ListModule.OfSeq(listCs);
            
            //fs
            var result = Ordenamiento.Rapido(listFs);
            //
            var resultFormateado = result.Select(r=>r.ToString())
                    .Aggregate((acc, item) => $"{acc},{item}");

            Console.WriteLine("\r\n\r\nResultado:");
            Console.WriteLine(resultFormateado);

            Console.ReadLine();
        }

        private static int[] ToListInt(string items)
        {
            List<int> resultList = new List<int>();
            foreach (var item in items.Split(sep))
            {
                if (int.TryParse(item, out int value))
                    resultList.Add(value);
            }
            return resultList.ToArray();
        }

        private static int[] ToListIntV2(string items)
        {

            return items.Split(sep)
                  .Where(item => item.All(i => char.IsDigit(i)))
                  .Select(item => int.Parse(item))
                  .ToArray();
        }
    }
}
