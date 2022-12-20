using System;

namespace moonShip{

    class Program {

        static void Main(string[] args){

            //Данные
            double h = 100; //в метрах
            string t = ""; //время
            double f = 45;//топливо в секундах
            double v = 0; // скорость корабля
            const double a = 2; // ускорение от двигателей
            const double g = -1.62; // ускорение свободного падения на луне 
            const double crushspeed = 10; //скорость при которой корабль разобьется
            bool onDrive = false;
            double x = 0;

            // Тело программы
            while (h>=0.001){
                // Че по чем 
                Console.WriteLine ($"Расстояние до луны {Math.Abs(h)}, метров\n Скорость корабля {Math.Abs(v)}, м/с\n Осталось топлива {f},сек ");
                // ввод пользователя и проверка его на честность
                Console.WriteLine("На сколько секунд вы хотите включить двигатель?");
                t = Console.ReadLine();
                if (double.TryParse(t, out var number))
                {
                    onDrive = true;
                    if (number <= 0){
                        x = g;
                    }else{
                        x = a;
                    }
                    if(number<0) number=0;
                    if(number>f) number=f;
                    //перерасчет
                    if ( x == a){
                        if (onDrive) f -= number;
                        h = h + v*number + x/2*number*number;
                        v = v + x*number;
                    }else{
                        if (onDrive) f -=number;
                        h = h + x + v;
                        v = v + x;
                    }
                }else
                {
                    Console.WriteLine ("Введите число");
                }
            }
            //данные после ввода пользователем
            Console.WriteLine($"Расстояние до луны {Math.Abs(h)}, метров \n Скорость корабля {Math.Abs(v)}, м/с \n Осталось топлива {f}, сек");

            //приземление удачное или не удачное 
            if (Math.Abs(v) < crushspeed){
                Console.WriteLine("Вы успешно приземлились");
            }else{
                Console.WriteLine("Вы успешно разбились :)");
            }
        }
    }
}
