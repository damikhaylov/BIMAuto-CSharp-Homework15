using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Разработать интерфейс ISeries генерации ряда чисел. Интерфейс содержит следующие элементы:
                метод void setStart(int x) - устанавливает начальное значение
                метод int getNext() - возвращает следующее число ряда
                метод void reset() - выполняет сброс к начальному значению
            Разработать классы ArithProgression и GeomProgression, которые реализуют интерфейс ISeries.
            В классах реализовать методы интерфейса в соответствии с логикой арифметической
            и геометрической прогрессии соответственно.
            */

            Console.WriteLine("Тестирование классов арифметической и геометрической прогрессий, "
                              + "реализующих общий интерфейс\n");

            Console.WriteLine("Пример арифметической прогрессии:");
            Console.Write("Прогрессия начинается с {0} : ", 0);
            ArithProgression arProgr = new ArithProgression(0, 1);
            for (int i = 0; i < 10; i++)
                Console.Write(arProgr.getNext() + " ");
            Console.WriteLine();
            Console.WriteLine("\nИзменение арифметической прогрессии после изменения "
                              + "начального члена и приращения:");
            Console.Write("Прогрессия начинается с {0} : ", 6);
            arProgr.setStart(6);
            arProgr.SetIncrement(2);
            for (int i = 0; i < 10; i++)
                Console.Write(arProgr.getNext() + " ");

            Console.WriteLine("\n\nПример геометрической прогрессии:");
            Console.Write("Прогрессия начинается с {0} : ", 1);
            GeomProgression geomProgr = new GeomProgression(1, 2);
            for (int i = 0; i < 10; i++)
                Console.Write(geomProgr.getNext() + " ");
            Console.WriteLine();
            Console.WriteLine("\nИзменение геометрической прогрессии после изменения "
                              + "начального члена и приращения:");
            Console.Write("Прогрессия начинается с {0} : ", 3);
            geomProgr.setStart(3);
            geomProgr.SetIncrement(3);
            for (int i = 0; i < 10; i++)
                Console.Write(geomProgr.getNext() + " ");

            Console.ReadKey();
        }
    }
    interface ISeries
    {
        void setStart(int x);
        void SetIncrement(int q);
        int getNext();
        void reset();
    }
    class ArithProgression : ISeries
    {
        int startItem;
        int increment;
        int currentItem;

        public ArithProgression(int start, int increment)
        {
            setStart(start);
            SetIncrement(increment);
        }
        public int getNext()
        {
            currentItem += increment;
            return currentItem;
        }

        public void reset()
        {
            currentItem = startItem;
        }

        public void SetIncrement(int q)
        {
            increment = q;
            reset();
        }

        public void setStart(int x)
        {
            startItem = x;
            reset();
        }
    }
    class GeomProgression : ISeries
    {
        int startItem;
        int increment;
        int currentItem;

        public GeomProgression(int start, int increment)
        {
            setStart(start);
            SetIncrement(increment);
        }
        public int getNext()
        {
            currentItem *= increment;
            return currentItem;
        }

        public void reset()
        {
            currentItem = startItem;
        }

        public void SetIncrement(int q)
        {
            if (q == 0) throw new Exception("Знаменатель геометрической прогрессии не может быть нулём.");
            increment = q;
            reset();
        }

        public void setStart(int x)
        {
            if (x == 0) throw new Exception("Первый член геометрической прогрессии не может быть нулём.");
            startItem = x;
            reset();
        }
    }
}
