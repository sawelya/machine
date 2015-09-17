// эмулятр взаимодействия автомата с машиной
// В связи с тем, что условие задачи неполно, опускаю такие данные как наличие у покупателя 150 рублей 
// (Ведь не может автомат знать сколько денег у человек)
// Рассматриваю взаимодействие автомата с человеком с бесконечными деньгами

using System;
class Product
{
    public int Product_number;
    public int Product_price;
    public int Product_ID;    

    public Product(int a, int b, int c)
    {
        Product_number = a;
        Product_price = b;
        Product_ID = c;
    }
  

    public void Buying (int Sum)
    {
        if ((Sum >= Product_price) && (Product_number > 0))
        {
            Product_number -= 1;
            Console.WriteLine("Вы покупаете продукт под номером " + Product_ID +  " ПОЗДРАВЛЯЕМ!");
            Console.WriteLine("Чтобы получить сдачу нажмите 7 (семь), а затем Enter");
            Console.WriteLine("Чтобы купить продукт, нажмите 6 (шесть), а затем Enter");
        }
        if (Product_number == 0){
            Console.WriteLine("Товара под номером " + Product_ID + " не осталось");
            Console.WriteLine("Чтобы получить сдачу нажмите 7 (семь), а затем Enter");
            Console.WriteLine("Чтобы купить продукт, нажмите 6 (шесть), а затем Enter");             
            }
        if (Sum < Product_price){
            Console.WriteLine("Недостаточно денег для покупки продукта с номером " + Product_ID);
            Console.WriteLine("Чтобы получить сдачу нажмите 7 (семь), а затем Enter");
            Console.WriteLine("Чтобы купить продукт, нажмите 6 (шесть), а затем Enter");            
            }
    }
    public int Balance(int Sum)
    {
        int Kredit = Sum - Product_price;
        return Kredit;
    }
}
//------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------
// Считаю, что автомат знает сколько монет каждого номинала у него осталось

class Machine_job
{
   


    static void Main()
    {
        Product cake = new Product(4, 50, 1);
        Product biscuit = new Product(3, 10, 2);
        Product wafer = new Product(10, 30, 3);

        int a, b, c, d;
        int i = 0;
        int command;        
        int read_number;
        int Sum = 0;//---> внесенные в автомат деньги
        int[] coins = new int[100];
        int[] number_rub_machine = {10, 10, 10, 10}; //---> количество монет в автомате номиналом 1, 2, 5, 10 рублей
         
        // следующая часть кода описывает взаимодействие человека с автоматом
        for (; ; )
        {
			Console.WriteLine("Предлагаются следующие продукты");
			Console.WriteLine("Кексы имеют идентификатор 1");
			Console.WriteLine("Печенье имеет идентификатор 2");
			Console.WriteLine("Вафли имеют идентификатор 3");
            Console.WriteLine("Внесите деньги в приемник монет");
            Console.WriteLine("Введите через Enter монеты, которые вы хотите внести в автомат");
            Console.WriteLine("Когда посчитаете сумму денег достаточной введите 0 (ноль) и нажмите Enter");

            //внесение денег и пополнение монетами автомата
            for (i = 0; i < 100; i++)
            {
                coins[i] = Convert.ToInt32(Console.ReadLine());
                Sum = Sum + coins[i];                
                if (coins [i] == 1)
                    number_rub_machine [0]++;
                if (coins [i] == 2)
                    number_rub_machine [1]++;
                if (coins [i] == 5)
                    number_rub_machine [2]++;
                if (coins [i] == 10)
                    number_rub_machine [3]++;
                if (coins[i] == 0)
                    break;
            }
            
            Console.WriteLine("Итак, ваш кредит = " + Sum);
            Console.WriteLine("Введите индикатор жалаемого товара");

            read_number = Convert.ToInt32(Console.ReadLine());
            
            // Расчет кредита человека
            if (read_number == 1){
                cake.Buying(Sum);              
                if ((Sum >= cake.Product_price) && (cake.Product_number > 0))
                    Sum = cake.Balance(Sum);               
            }
            if (read_number == 2){
                biscuit.Buying(Sum);
                if ((Sum >= biscuit.Product_price) && (biscuit.Product_number > 0))
                    Sum = biscuit.Balance(Sum);
            }
            if (read_number == 3){
                wafer.Buying(Sum);
                if ((Sum >= wafer.Product_price) && (wafer.Product_number > 0))
                    Sum = wafer.Balance(Sum);
            }

            command = Convert.ToInt32(Console.ReadLine());

            if (command == 6)
                continue;
            if (command == 7){
                a = Sum / 10;
                if (a < number_rub_machine[3])
                {
                    Sum -= a * 10;
                    number_rub_machine[3] -= a;
                    Console.Write("ВАША СДАЧА:\n" + a + " монет по 10 рублей, \n");
                }
                else
                {
                    Sum -= number_rub_machine[3] * 10;                    
                    Console.Write("ВАША СДАЧА:\n" + number_rub_machine[3] + " монет по 10 рублей, \n");
                    number_rub_machine[3] = 0;
                }
                
                b = Sum / 5;
                if (b < number_rub_machine[2])
                {
                    Sum -= b * 5;
                    number_rub_machine[2] -= b;
                    Console.Write(b + " монет по 5 рублей, \n");
                }
                else
                {
                    Sum -= number_rub_machine[2] * 5;                    
                    Console.Write(number_rub_machine[2] + " монет по 5 рублей, \n");
                    number_rub_machine[2] = 0;
                }
                
                c = Sum / 2;
                if (c < number_rub_machine[1])
                {
                    Sum -= c * 2;
                    number_rub_machine[1] -= c;
                    Console.Write(c + " монет по 2 рубля, \n");
                }
                else
                {
                    Sum -= number_rub_machine[1] * 2;                    
                    Console.Write(number_rub_machine[1] + " монет по 2 рубля, \n");
                    number_rub_machine[1] = 0;
                }
                d = Sum;
                if (d < number_rub_machine[0])
                {                    
                    Sum = 0;
                    Console.Write(d + " монет по 1 рублю\n");
                }
                else
                {
                    Sum -= number_rub_machine[0];                    
                    Console.Write(number_rub_machine[0] + " монет по 1 рублю, \n");
                    number_rub_machine[0] = 0;
                    Console.WriteLine("Вы не получили сдачу доконца, обратитесь пожалуйста к администратору автомата");
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}

