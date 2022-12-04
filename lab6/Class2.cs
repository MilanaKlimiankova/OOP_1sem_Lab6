using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab6
{
    public partial class StBook
    {
        new public void Info()
        {
            Console.WriteLine("Название: " + Name);
            Console.WriteLine("Год: " + Year);
            Console.WriteLine("Издательство: " + Izdat);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("Тип - учебник");
        }
    }
}