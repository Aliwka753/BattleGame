using BattleGame.Data;
using System;
using System.Reflection.Metadata.Ecma335;

/*Это простая игра с участием двух бойцов которых выбирает пользователь.
 * Пользователь вводит класс бойца который будет сражаться на его стороне и класс бойца
 * который будет сражаться против него.
 * 
 * В будущих релизах, для бойцов и данных каждого будет создана БД.
 * Так же будет создана система ударов в голову,грудь и пояс для пользователя и ПК,
 * чтобы игра была увлекательнее.
 * 
*/

// Создание экземпляров бойцов на основе существующих классов
//Рыцарь
Knight knight = new Knight("Arthur", 150, 25, 50, "Меч");
//Маг
Mage mage = new Mage("Merlin", 100, 30, 50, "Посох");
//Лучник
Archer archer = new Archer("Robin", 120, 30, 50, "Лук");
//Гном
Draft draft = new Draft("Gimli", 170, 20, 30, "Топор");

//создаю переменные для выбора классов пользователем
string userWarrior, botWarrior;

//создаю переменные для присвоения бойцов пользователю и ПК
Warrior user = new Warrior();
Warrior bot = new Warrior();

//переменная для выбора первого удара (ПК или пользователь)
int firstHit;

//вывод на экран записи о выборе бойца пользователем
Console.WriteLine("Выберите своего бойца введите: 'Рыцарь', 'Маг', 'Лучник', 'Гном'");
Console.WriteLine(" ");
//ввод класса пользоватем своего бойца
userWarrior = Console.ReadLine();
Console.WriteLine(" ");

//создаю конструкцию if...else для присвоения бойца пользователю на основе выбранного класса
if (userWarrior == "Рыцарь")
{
    user = knight;
    Console.WriteLine($"Ваш боец рыцарь {user.Name}!");
    Console.WriteLine(" ");
}
else if (userWarrior == "Маг")
{
    user = mage;
    Console.WriteLine($"Ваш боец маг {user.Name}!");
    Console.WriteLine(" ");
}
else if (userWarrior == "Лучник")
{
    user = archer;
    Console.WriteLine($"Ваш боец рыцарь {user.Name}!");
    Console.WriteLine(" ");
}
else if (userWarrior == "Гном")
{
    user = draft;
    Console.WriteLine($"Ваш боец рыцарь {user.Name}!");
    Console.WriteLine(" ");
}
else
{
    Console.WriteLine("Такого бойца не существует.");
}

//вывод на экран записи о выборе бойца пользователем для ПК
Console.WriteLine("Выберите бойца для компьютера");
Console.WriteLine(" ");
//ввод класса бойца пользоватем для ПК
botWarrior = Console.ReadLine();
Console.WriteLine(" ");

//создаю конструкцию if...else для присвоения бойца для ПК на основе выбранного класса
if (botWarrior == "Рыцарь")
{
    bot = knight;
    Console.WriteLine($"Против вас будет играть рыцарь {bot.Name}!");
    Console.WriteLine(" ");
    //после того как пользователь выбирает бойцов, вызывается метод StartBattle, для начала поединка
    StartBattle();
}
else if (botWarrior == "Маг")
{
    bot = mage;
    Console.WriteLine($"Против вас будет играть маг {bot.Name}!");
    Console.WriteLine(" ");
    StartBattle();
}
else if (botWarrior == "Лучник")
{
    bot = archer;
    Console.WriteLine($"Против вас будет играть рыцарь {bot.Name}!");
    Console.WriteLine(" ");
    StartBattle();
}
else if (botWarrior == "Гном")
{
    bot = draft;
    Console.WriteLine($"Против вас будет играть рыцарь {bot.Name}!");
    Console.WriteLine(" ");
    StartBattle();
}
else
{
    Console.WriteLine("Такого бойца не существует.");
}
//метод для начала поединка
void StartBattle()
{
    //переменная для случайного выбора первого удара
    Random random = new Random();
    firstHit = random.Next(0, 2);

    //вывод HP бойцов в отдельную переменную
    int userHealthPoint = bot.HealthPoint;
    int botHealthPoint = bot.HealthPoint;

    //если random == 0, боец игрока начинает бой первым
    if(firstHit == 0)
    {
        Console.WriteLine("Боец пользователя наносит первый удар");
        Console.WriteLine(" ");
        //вызов метода с началом боя пользователя
        UserStart();
    }
    //если random == 1, бой начинает ПК
    else
    {
        Console.WriteLine("Боец компьютера наносит первый удар");
        Console.WriteLine(" ");
        //вызов метода с началом боя ПК
        BotStart();
    }

    //метод для начала боя пользователем
    void UserStart()
    {
        //цикл while, пока HP одного из бойцов не равен нулю, бой продолжается
        while (true)
        {
            botHealthPoint = botHealthPoint - user.Hit(user);

            Console.WriteLine($"{user.Name} бьет {bot.Name}, у бойца {bot.Name} остается" +
            $" {botHealthPoint} HP");
            //если HP пользователя равны  или меньше 0, пользователь проиграл
            if (userHealthPoint <= 0)
            {
                Console.WriteLine("К сожалению вы проиграли:(");
                Console.WriteLine($"Победитель {bot.Name}");
                break;
            }
            //если HP ПК равны  или меньше 0, пользователь выиграл
            else if (botHealthPoint <= 0)
            {
                Console.WriteLine("Поздравляем вы выиграли!");
                Console.WriteLine($"Победитель {user.Name}");
                break;
            }

            userHealthPoint = userHealthPoint - bot.Hit(bot);

            Console.WriteLine($"{bot.Name} бьет {user.Name}, у бойца {user.Name} остается" +
            $" {userHealthPoint} HP");
            Console.WriteLine(" ");

            if (userHealthPoint <= 0)
            {
                Console.WriteLine("К сожалению вы проиграли:(");
                Console.WriteLine($"Победитель {bot.Name}");
                break;
            }
            else if (botHealthPoint <= 0)
            {
                Console.WriteLine("Поздравляем вы выиграли!");
                Console.WriteLine($"Победитель {user.Name}");
                break;
            }
        }
        Console.ReadLine();
    }
    //метод начала боя ПК
    void BotStart()
    {
        while (true)
        {

            userHealthPoint = userHealthPoint - bot.Hit(bot);

            Console.WriteLine($"{bot.Name} бьет {user.Name}, у бойца {user.Name} остается" +
                $" {userHealthPoint} HP");

            if (userHealthPoint <= 0)
            {
                Console.WriteLine("К сожалению вы проиграли:(");
                Console.WriteLine($"Победитель {bot.Name}");
                break;
            }
            else if (botHealthPoint <= 0)
            {
                Console.WriteLine("Поздравляем вы выиграли!");
                Console.WriteLine($"Победитель {bot.Name}");
                break;
            }


            botHealthPoint = botHealthPoint - user.Hit(user);

            Console.WriteLine($"{user.Name} бьет  {bot.Name}, у бойца {bot.Name} остается" +
                $"{botHealthPoint} HP");
            //пустая строка
            Console.WriteLine(" ");

            if (botHealthPoint <= 0)
            {
                Console.WriteLine("К сожалению вы проиграли:(");
                Console.WriteLine($"Победитель {bot.Name}");
                break;
            }
            else if (botHealthPoint <= 0)
            {
                Console.WriteLine("Поздравляем вы выиграли!");
                Console.WriteLine($"Победитель {user.Name}");
                break;
            }
        }
        Console.ReadLine();
    }
}

            
    
