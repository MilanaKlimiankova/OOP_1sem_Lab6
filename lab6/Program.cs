using System;
using System.Collections;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Журнал, Книга, Печатное издание, Учебник, Журнал, Персона,
//Автор, Издательство.

//Создать Библиотеку с книгами, журналами.--------
//Вывести наименование всех книг в библиотеке, вышедших не
//ранее указанного года; найти суммарное количество
//учебников в библиотеке, подсчитать стоимость изданий,
//находящихся в библиотеке.




namespace lab6
{

    interface IPaper//интерфейс
    {
        void Info();
        string Name { get; set; }
        int Year { get; set; }
        string Izdat { get; set; }
        string Color { get; set; }

    }
    public abstract class PechatnoyeIzd : IPaper //абстрактный класс
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Izdat { get; set; }
        public string Color { get; set; }
        virtual public void Info() //метод добавлен в интерфейс и абстрактный класс, переопредлён в классах-наследниках
        {
            Console.WriteLine("Название:" + Name);
            Console.WriteLine("Год:" + Year);
            Console.WriteLine("Издательство:" + Izdat);
            Console.WriteLine("Цвет:" + Color);
        }
    }
    public class Book : PechatnoyeIzd
    {
        public Type Tp { get; set; }
        public Book(string Name, int Year, string Izdat, string Color)
        {
            this.Name = Name;
            this.Year = Year;
            this.Izdat = Izdat;
            this.Color = Color;
            Tp = Type.Book;

        }
        new public void Info()
        {
            Console.WriteLine("Название: " + Name);
            Console.WriteLine("Год: " + Year);
            Console.WriteLine("Издательство: " + Izdat);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("Тип - книга");
        }
        public override string ToString()
        {
            return $"Название:{this.Name}.\nГод:{this.Year}.\nИздательство:{this.Izdat}.\nЦвет:{this.Color}.\nТип:{this.Tp}";
        }
    }
    public class Magazine : PechatnoyeIzd
    {
        public Type Tp { get; set; }
        public Magazine(string Name, int Year, string Izdat, string Color)
        {
            this.Name = Name;
            this.Year = Year;
            this.Izdat = Izdat;
            this.Color = Color;
            Tp = Type.Magazine;
        }
        public override void Info()
        {
            Console.WriteLine("Название: " + Name);
            Console.WriteLine("Год: " + Year);
            Console.WriteLine("Издательство: " + Izdat);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("Тип: " + Tp);
        }
        public override string ToString()
        {
            return $"Название:{this.Name}.\nГод:{this.Year}.\nИздательство:{this.Izdat}.\nЦвет:{this.Color}.\nТип:{this.Tp}";
        }
    }
 
    //6 lab
    public partial class StBook : PechatnoyeIzd //частичный класс
    {
        public Type Tp { get; set; }
        public StBook(string Name, int Year, string Izdat, string Color)
        {
            this.Name = Name;
            this.Year = Year;
            this.Izdat = Izdat;
            this.Color = Color;
            Tp = Type.StBook;
        }
 
        public override string ToString()
        {
            return $"Название:{this.Name}.\nГод:{this.Year}.\nИздательство:{this.Izdat}.\nЦвет:{this.Color}.\nТип:{this.Tp}";
        }
    }

    public enum Type //перечисление
    {
        Book,
        StBook,
        Magazine
    }
    struct Review //структура
    {
        public string Mark;
        public Review(string Mark)
        {
            this.Mark = Mark;
        }
        public void GetInfo()
        {
            Console.WriteLine("Рецензия:{0}", Mark);
        }
    }

    public class Controller
    {
        public void After(Library l, int y)
        {
            Console.WriteLine("Книги, выпущенные после "+y+" года:");
            for (int i = 0; i < l.Lib.Count; i++)
            {
                if (l.Lib[i].Year > y)
                {
                    Console.WriteLine(l.Lib[i].ToString());
                    Console.WriteLine();
                }
            }
        }
        public void Sum(Library l)
        {
            int stcount = 0;
            for (int i = 0; i < l.Lib.Count; i++)
            {
                if (l.Lib[i] is StBook) stcount++;
            }
            Console.WriteLine("Кол-во учебников в библиотеке: " + stcount);
        }
        public void TotalPrice(Library l) //вместо цен сложила год издания
        {
            int total = 0;
            for (int i = 0; i < l.Lib.Count; i++)
            {
                total += l.Lib[i].Year;
            }
            Console.WriteLine("Стоимость всех изданий: " + total);
        }
    }
     public class Library //класс-контейнер Библиотека
     {
        public List<PechatnoyeIzd> Lib { get; set; } 
        public int counter = 0;
        public Library()
        {
            Lib = new List<PechatnoyeIzd>(1);
        }
        public void Add(PechatnoyeIzd lu) //добавление
        {
            Lib.Insert(counter, lu);
            counter++;
        }
        public void Delete(PechatnoyeIzd lu) //удаление
        {
            Lib.Remove(lu);
            Console.WriteLine("Item was deleted!");
        }
        public void Print() //вывод
        {
            Console.WriteLine();
            foreach (PechatnoyeIzd i in Lib)
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine();
            }
        }

        
     }


        class Program
        {
            static void Main(string[] args)
            {
                Book book1 = new Book("TinSoldier", 2000, "PassiveApp", "Orange");
                Book book2 = new Book("ShoesOfGlass", 1978, "AgrassiveApe", "Green");
                Magazine mag1 = new Magazine("Devil", 1995, "WearsPrada", "White");
                Magazine mag2 = new Magazine("FantasyShow", 2005, "Victoria'sSecret", "Magenta");
                StBook stbook1 = new StBook("Botanic", 2001, "FallingLeaf", "Black");
                StBook stbook2 = new StBook("HowToWalkGracefully", 2010, "PeasefullLorena", "Cyan");

                Library MyLibrary = new Library();
                MyLibrary.Add(book1); MyLibrary.Add(book2);
                MyLibrary.Add(mag1); MyLibrary.Add(mag2);
                MyLibrary.Add(stbook1); MyLibrary.Add(stbook2);
                MyLibrary.Delete(mag2); MyLibrary.Delete(mag1);

                MyLibrary.Print();
                Controller c = new Controller();
                c.After(MyLibrary, 1999);
                c.Sum(MyLibrary);
                c.TotalPrice(MyLibrary);
            }
        }

}
