using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            // Создаём первый объект Money 
            Money money1 = new Money(52, 45);
            // Увеличим копейки и сделаем проверку
            money1.Kopecks += 160;
            money1.Ruble();            
            Console.WriteLine(money1.ToString());
            // Перевод денег в double
            money1.ToConvert();
            // Создаём второй объект Money 
            Money money2 = new Money();
            // Присвоим ему значение double
            money2.ReverseConvert(24.36);
            Console.WriteLine(money1.ToString());            
            Money money3 = new Money();
            // Найдём сумму первого и второго объектов
            money3 = money1 + money2;
            // При выводе на экран, преобразуем сумму в double
            Console.WriteLine($"{money1.ToString()} + {money2.ToString()} = {money3.ConvertMoney()} руб.");             
            // Найдём разность первого и второго объектов           
            Console.WriteLine($"{money1.ToString()} - {money2.ToString()} = {money1.Defference(money2).ToString()}");
        }
    }
}
