using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    internal class Money
    {
        public int Rubles {  get; set; }      // Поле, отображающе рубли
        public int Kopecks {  get; set; }     // Поле, отображающее копейки
        // Конструктор по умолчанию
        public Money()
            : this(0, 0) { }
        // Конструктор с параметрами
        public Money(int rubles, int kopecks)
        {
            Rubles = rubles;
            Kopecks = kopecks;
        }
        // Метод вывода
        public override string ToString()
        {
            return $"{Rubles} руб. {Kopecks} коп.";
        }
        // Метод прверки копеек: копеек должно быть меньше 100
        public bool Ruble()
        {
            while (Kopecks >= 100)  
            {
                Kopecks -= 100;     // Если копеек больше 100, 100 отнимаем
                Rubles++;           // И увеличиваем рубыли на 1
            }                       // Повтор пока копеек не будет меньше 100
            return true;
        }
        // Методы нахождения суммы
        public Money Sum(Money other)
        {
            Rubles += other.Rubles;    
            Kopecks += other.Kopecks;  
            Ruble();
            return this;
        }
        public static Money operator +(Money money1, Money money2)
        {
            int rub = money1.Rubles + money2.Rubles;
            int kop = money1.Kopecks + money2.Kopecks;
            Money money = new Money(rub, kop);
            money.Ruble();
            return money;
        }
        // Методы нахождения разности
        public Money Defference(Money other)
        {
            if (Rubles > other.Rubles)
            {
                if (Kopecks < other.Kopecks)
                {
                    Rubles--;
                    Kopecks = Kopecks + 100 - other.Kopecks;
                }
                else
                {
                    Kopecks -= other.Kopecks;
                }                
            }
            else
            {
                if (other.Kopecks < Kopecks)
                {
                    other.Rubles--;
                    Kopecks = other.Kopecks + 100 - Kopecks;
                }
                else
                {
                    Kopecks = other.Kopecks - Kopecks;
                }                
            }
            Rubles -= other.Rubles;
            return this;
        }        
        public static Money operator- (Money money1, Money money2)
        {
            int rub = 0, kop = 0;
            if (money1.Rubles > money2.Rubles)
            {
                if (money1.Kopecks > money2.Kopecks)
                {
                    kop = money1.Kopecks - money2.Kopecks;                    
                }
                else
                {
                    money1.Rubles--;
                    kop = money1.Kopecks + 100 - money2.Kopecks;
                }                
            }
            else
            {
                if (money2.Kopecks > money1.Kopecks)
                {
                    kop = money2.Kopecks - money1.Kopecks;
                }
                else
                {
                    money2.Rubles--;
                    kop = money2.Kopecks + 100 - money1.Kopecks;
                }                
            }
            rub = money1.Rubles - money2.Rubles;
            Money money = new Money(rub, kop);
            money.Ruble();
            return money;
        }
        // Методы получения денежного значения в double
        public double ConvertMoney()
        {
            double res = (double)Rubles + (double)Kopecks / 100;
            return res;
        }        
        public void ToConvert()
        {
            Console.WriteLine(this.ConvertMoney());
        }
        // Методы инициализации денежного значения из double 
        public Money ReverseConvert(double value)
        {
            Rubles = (int)value;                    
            Kopecks = (int)(value * 100 % 100);     
            return this;
        }
        public void ToReverse(double value)
        {
            ReverseConvert(value);
            Console.WriteLine(this.ToString());
        }
    }
}
