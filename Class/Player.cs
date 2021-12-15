using System;

namespace PokerLogic
{
    public class Player // класс наших будущих карт
    {
        public string Name { get; } // имя только геттер
        public float Money { get; set; } // деньги у игрока геттеры / сеттеры

        public Player(string name, float money) // конструктор
        {
            Name = name;
            Money = money;
        }
    }
}