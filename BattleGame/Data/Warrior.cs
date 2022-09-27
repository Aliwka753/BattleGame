namespace BattleGame.Data
{
    //класс шаблон для создания классов бойцов
    public class Warrior
    {
        //имя бойца
        internal string Name { get; set; }
        //очки жизней бойца
        internal int HealthPoint { get; set; }
        //мин урон бойца
        internal int minDamage { get; set; }
        //максимальный урон бойца
        internal int maxDamage { get; set; }
        //оружие бойца
        internal string Weapon { get; set; }

        //пустой конструктор
        public Warrior()
        {

        }
        //конструктор для создания бойца
        public Warrior(string name, int healthPoint, int minHit, int maxHit, string weapon)
        {
            Name = name;
            HealthPoint = healthPoint;
            this.minDamage = minHit;
            this.maxDamage = maxHit;
            Weapon = weapon;
        }
        //метод для нанесения случайного удара на основе минимального и максимального урона бойцов
        public int Hit(Warrior warrior)
        {
            Random random = new Random();
            return random.Next(warrior.minDamage, warrior.maxDamage);

        }

    }
}
