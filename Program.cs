using System;

namespace PokerLogic
{
    public class Program
    {
        public static void Main()
        {
            Deck deck = new Deck(); // создаём колоду
            Player player = new Player("Player", 1000); // создания игрока
            for (;;)
            {
                deck.shuffle(); // мешаем
                Hand hand = deck.dealStandardHand(); // берём первые 5 карт
                float money;
                Console.WriteLine("Приветсвую: " + player.Name +
                                  "\nВаши деньги: " + player.Money);
                Console.WriteLine("Ваша ставка: ");

                try // обработка правильного ввода
                {
                    money = (float) Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e) // при обнаружении ошибки выходим из приложения
                {
                    Console.WriteLine(e); // вывод самой ошибки
                    break; // выход из програмы
                }

                if (money < player.Money) // ставка больше ли чем у плеера нету сколько денег
                {
                    player.Money -= money;
                    Console.WriteLine("Вам выпало:");

                    foreach (var grade in hand.Cards) // вывод 5 карт
                    {
                        Console.WriteLine(grade.Suit + " " + grade.Value);
                    }

                    if (hand.royalStraightFlush())
                    {
                        money *= 10;
                        Console.WriteLine("У вас комбинация Стрит-Рояль-Флеш");
                    }
                    else if (hand.straightFlush())
                    {
                        money *= 5;
                        Console.WriteLine("У вас комбинация Стрит-флеш");
                    }
                    else if (hand.fullHouse())
                    {
                        money *= 4.5f;
                        Console.WriteLine("У вас комбинация Фулл хаус");
                    }
                    else if (hand.straight())
                    {
                        money *= 4;
                        Console.WriteLine("У вас комбинация Стрит");
                    }
                    else if (hand.flush())
                    {
                        money *= 3.5f;
                        Console.WriteLine("У вас комбинация Флеш");
                    }
                    else if (hand.fourOfAKind())
                    {
                        money *= 3;
                        Console.WriteLine("У вас комбинация Четвёрка");
                    }
                    else if (hand.threeOfAKind())
                    {
                        money *= 2.5f;
                        Console.WriteLine("У вас комбинация Тройка");
                    }
                    else if (hand.twoPair())
                    {
                        money *= 2;
                        Console.WriteLine("У вас комбинация Две пары");
                    }
                    else if (hand.pair())
                    {
                        money *= 1.5f;
                        Console.WriteLine("У вас комбинация Пара");
                    }
                    else
                    {
                        money = 0;
                        Console.WriteLine("Вам ничего не выпало.");
                    }

                    Console.WriteLine("Вы выиграли " + money);
                    player.Money += money;
                }
                else 
                {
                    Console.WriteLine("У вас недостаточно средств для выполнения данной операции!");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения.\nДля выхода введите 1.");
                var inp = Convert.ToString(Console.ReadLine());

                if (inp.Equals("1")) break;
            }
        }
    }
}

/* тесты
                // Console.WriteLine("Пара: " + hand.isPair());
                // Console.WriteLine("Две пары: " + hand.isTwoPair());
                // Console.WriteLine("Тройка: " + hand.isThreeOfAKind());
                // Console.WriteLine("Четвёрка: " + hand.isFourOfAKind());
                // Console.WriteLine("Флеш: " + hand.isFlush());
                // Console.WriteLine("Стрит: " + hand.isStraight());
                // Console.WriteLine("Фулл хаус: " + hand.isFullHouse());
                // Console.WriteLine("Стрит-флеш: " + hand.isStraightFlush());
                // Console.WriteLine("Стрит-Рояль-Флеш: " + hand.isRoyalStraightFlush());
 */