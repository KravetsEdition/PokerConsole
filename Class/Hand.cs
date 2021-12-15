using System.Collections.Generic;
using System.Linq;

namespace PokerLogic
{
    public class Hand // логика пар
    {
        public IEnumerable<Card> Cards { get; set; } // Интерфейс IEnumerable колекция с типом нашего класа

        private bool contains(Value val) // находим определённую карту из Колоды
        {
            return Cards.Any(c => c.Value == val);
        }

        // правила от сюда https://www.pokerstars.com/poker/games/rules/hand-rankings/?no_redirect=1
        public bool pair() // Одна пара
        {
            return Cards.GroupBy(h => h.Value).Count(g => g.Count() == 2) == 1; // если 2 карты похожи
        }

        public bool twoPair() // Две пары
        {
            return Cards.GroupBy(h => h.Value).Count(g => g.Count() == 2) == 2; // если 2 карты похожы 2 раза
        }

        public bool threeOfAKind() // Три карты одного ранга и две несвязанные побочные карты.
        {
            return Cards.GroupBy(h => h.Value).Any(g => g.Count() == 3); //групируем значение где 3 карты одного ранга
        }

        public bool fourOfAKind() // Четыре карты одного достоинства и одна побочная карта или «кикер».
        {
            return Cards.GroupBy(h => h.Value).Any(g => g.Count() == 4); //групируем значение где 4 карты одного ранга
        }

        public bool flush() // Пять карт одной масти.
        {
            return Cards.GroupBy(h => h.Suit).Count() == 1; // сравниваем с enum мастей
        }

        public bool fullHouse() // Три карты одного ранга и две карты другого, соответствующего ранга.
        {
            return pair() && threeOfAKind(); // если сработали 2 правила выше
        }

        public bool straight() // Пять карт подряд.
        {
            // если пять кард подрят от джокера до 10
            if (contains(Value.Джокер) &&
                contains(Value.Король) &&
                contains(Value.Дама) &&
                contains(Value.Валет) &&
                contains(Value.Десять))
            {
                return true;
            }
            var ordered = Cards.OrderBy(h => h.Value).ToArray();
            var straightStart = (int) ordered.First().Value;
            for (var i = 1; i < ordered.Length; i++)
            {
                if ((int) ordered[i].Value != straightStart + i)
                    return false;
            }
            return true;
        }

        public bool straightFlush() // Пять карт в порядке номеров, все одинаковые масти. //Стрит-флеш
        {
            return straight() && flush(); // 2 метода тру
        }

        public bool royalStraightFlush()
        {
            // Рояль-стрит-флеш 
            return straight() && flush() && contains(Value.Джокер) && contains(Value.Король); // сработали 2 пары и был найден джокер и король
        }
    }
}