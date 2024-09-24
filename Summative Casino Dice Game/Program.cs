namespace Summative_Casino_Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Die dice1 = new Die();
            Die dice2 = new Die();

            string userOutcomePredict;
            double money = 100, betAmount = 0;
            bool done = false, donePrediction = false;

            Console.WriteLine("Welcome to the casino! You start with $100.00. Press ENTER to begin...");
            Console.ReadLine();

            while (!done)
            {
                Console.Write("You have " + money.ToString("C") + ", how much do you want to bet: ");
                while (!Double.TryParse(Console.ReadLine(), out betAmount))
                    Console.Write("Invalid bet amount, please try again...");

                Console.WriteLine();

                while (betAmount < 0 || betAmount > money)
                {
                    Console.Write("You can't bet more than you have or a negative amount, please try again: ");
                    while (!Double.TryParse(Console.ReadLine(), out betAmount))
                        Console.Write("Invalid bet amount, please try again...");
                }

                while (!donePrediction)
                {
                    Console.WriteLine();

                    Console.WriteLine("What do you think will happen when the dice are rolled: ");

                    Console.WriteLine();

                    Console.WriteLine("1. Doubles (Will win double your bet)");
                    Console.WriteLine("2. Not Doubles (Will win half your bet)");
                    Console.WriteLine("3. Even Sum (Will win your bet back)");
                    Console.WriteLine("4. Odd Sum (Will win your bet back)");
                    userOutcomePredict = Console.ReadLine();

                    if (userOutcomePredict == "1" || userOutcomePredict.ToLower() == "doubles")
                        donePrediction = true;
                    else if (userOutcomePredict == "2" || userOutcomePredict.ToLower() == "not doubles")
                        donePrediction = true;
                    else if (userOutcomePredict == "3" || userOutcomePredict.ToLower() == "even sum")
                        donePrediction = true;
                    else if (userOutcomePredict == "4" || userOutcomePredict.ToLower() == "odd sum")
                        donePrediction = true;
                    else
                        Console.WriteLine("That's not one of the options, please try again");
                }
                Console.WriteLine();

                Console.WriteLine("It's time to roll the dice! Press ENTER to roll");
                Console.ReadLine();

                dice1.RollDie();
                dice2.RollDie();

                Console.WriteLine("Dice 1 rolled a");
            }
        }
    }
}
