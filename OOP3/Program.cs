namespace oop
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Welcome to TextRPG");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Load Game");
                Console.WriteLine("3. Exit Game");
                Console.Write("선택 : ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("New Game");
                        goto start;
                    case "2":
                        Console.WriteLine("Load Game");
                        return;
                    case "3":
                        Console.WriteLine("Exit Game");
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        start:
            CreateCharacter player = CreateCharacter.Create();
            player.PrintInfo();
            Enemy enemy = new Enemy();
            Stage stage = new Stage();
            while (player.Stage <= 30)
            {
                stage.Fight(player, enemy);
            }
        }
    }
}
