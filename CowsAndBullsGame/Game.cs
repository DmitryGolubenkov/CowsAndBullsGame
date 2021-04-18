using System;

namespace CowsAndBullsGame
{
    public class Game
    {


        public string Number { get; private set; }

        public Game()
        {
            Random random = new Random();
            Number = string.Empty;
            //Четырехзначное число с разными цифрами
            for (int i = 0; i < 4; i++)
            {
                bool isValid = false;
                do
                {
                    isValid = true;
                    //Создаем цифру
                    int generated = random.Next(0, 10);
                    //Проверяем, есть ли уже такая цифра
                    foreach (var ch in Number)
                    {
                        if (ch == generated)
                        {
                            isValid = false;
                            break;
                        }
                    }
                } while (!isValid);
            }
        }

        public string Turn(string input)
        {
            int cows = CountCows(input);
            int bulls = CountBulls(input);
            
            return BuildAnswer(cows, bulls);
        }

        private string BuildAnswer(in int cows, in int bulls)
        {
            string answer = cows.ToString();
            switch (cows)
            {
                
                case 0:
                {
                    answer += " коров, ";
                } 
                    break;
                case 1:
                {
                    answer += " корова, ";
                    }
                    break;
                case 2:
                case 3:
                case 4:
                {
                    answer += " коровы, ";
                    }
                    break;
            }

            answer = bulls.ToString();
            switch (bulls)
            {

                case 0:
                {
                    answer += " быков, ";
                }
                    break;
                case 1:
                {
                    answer += " бык, ";
                }
                    break;
                case 2:
                case 3:
                case 4:
                {
                    answer += " быка, ";
                }
                    break;
            }

            return answer;
        }

        //Метод считает быков - сколько чисел угадано
        private int CountBulls(string input)
        {
            int bulls = 0;
            //Ищем количество совпадений в 2 массивах
            foreach (var ch in input)
            {
                foreach (var num in Number)
                {
                    if (ch == num) //Если есть совпадение
                    {
                        bulls++;
                        break;
                    }
                }
            }

            return bulls;
        }

        //Метод считает коров - сколько чисел угадано и стоит на своих местах
        private int CountCows(string input)
        {
            int cows = 0;
            for (int i = 0; i < 4; i++)
            {
                if (input[i] == Number[i])
                    cows++;
            }

            return cows;
        }
    }
}
