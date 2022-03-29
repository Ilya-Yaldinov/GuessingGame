using GameCore;

namespace GuessingGame
{
    class MyClass
    {
        public static void Main()
        {
            GameDraw gameDraw = new GameDraw();
            gameDraw.StartDraw();
        }
    }
    
    class GameDraw
    {
        public void StartDraw()
        {
            GameLogic gameLogic = new GameLogic();
            gameLogic.GameStart();
            WriteRules(gameLogic);
            GameRender(gameLogic);
        }

        private void GameRender(GameLogic gameLogic)
        {
            while (!gameLogic.IsGameOver())
            {   
                Console.SetCursorPosition(47, 11);
                Console.Write("Введите число: ");
                var inputNumber = Console.ReadLine();
                Status status = gameLogic.TryGuessNumber(Convert.ToInt32(inputNumber));
                Console.Clear();
                Console.SetCursorPosition(53, 13);
                Console.Write($"<--{gameLogic.LowerThreshold}---*---{gameLogic.UpperThreshold}-->");
                Console.SetCursorPosition(47, 10);
                switch (status)
                {
                    case Status.CorrectNumber:
                        Console.Write("Поздравляем с победой.");
                        break;
                    case Status.LessNumber:
                        Console.Write("Число больше загаданного.");
                        break;
                    case Status.MoreNumber:
                        Console.Write("Число меньше загаданного.");
                        break;
                    case Status.RepeatedNumber:
                        Console.Write("Повторите ввод.");
                        break;
                }
            }
        }

        private void WriteRules(GameLogic gameLogic)
        {
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Это игра в угадайку.");
            Console.SetCursorPosition(49, 11);
            Console.WriteLine("Правила крайне просты.");
            Console.SetCursorPosition(42, 12);
            Console.WriteLine($"Вы должны угадать число от 1 до {gameLogic.NumberOfAttempts}.");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("После каждого введенного числа мы будем давать вам подсказку.");
            Console.SetCursorPosition(44, 14);
            Console.WriteLine($"Вы можете ошибиться всего {gameLogic.MarginForMistake} раз.");
            Console.SetCursorPosition(41, 15);
            Console.WriteLine("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}