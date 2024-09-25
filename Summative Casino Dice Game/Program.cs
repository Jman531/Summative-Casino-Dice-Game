using System.Text;

namespace Summative_Casino_Dice_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Die dice1 = new Die();
            Die dice2 = new Die();

            string quit, userOutcomePredict = "";
            int dice1Int = 0, dice2Int = 0, doubleCount = 0, notDoubleCount = 0, evenSumCount = 0, oddSumCount = 0, gamesPlayed = 0, gamesWon = 0, gamesLost = 0;
            double money = 100, betAmount = 0, totalMoneyMade = 0, totalMoneyLost = 0;
            bool done = false, donePrediction = false, doneQuitChoice = false;

            Console.WriteLine("Welcome to the casino! You start with $100.00. Press ENTER to begin...");
            Console.ReadLine();

            Console.Clear();

            while (!done)
            {
                gamesPlayed++;
                donePrediction = false;
                doneQuitChoice = false;

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

                Console.Clear();

                while (!donePrediction)
                {
                    Console.WriteLine("What do you think will happen when the dice are rolled: ");

                    Console.WriteLine();

                    Console.WriteLine("1. Doubles (Will win double your bet)");
                    Console.WriteLine("2. Not Doubles (Will win half your bet)");
                    Console.WriteLine("3. Even Sum (Will win your bet back)");
                    Console.WriteLine("4. Odd Sum (Will win your bet back)");
                    userOutcomePredict = Console.ReadLine();

                    if (userOutcomePredict == "1" || userOutcomePredict.ToLower() == "doubles")
                    {
                        donePrediction = true;
                        userOutcomePredict = "1";
                        doubleCount++;
                    }
                    else if (userOutcomePredict == "2" || userOutcomePredict.ToLower() == "not doubles")
                    {
                        donePrediction = true;
                        userOutcomePredict = "2";
                        notDoubleCount++;
                    }
                    else if (userOutcomePredict == "3" || userOutcomePredict.ToLower() == "even sum")
                    {
                        donePrediction = true;
                        userOutcomePredict = "3";
                        evenSumCount++;
                    }
                    else if (userOutcomePredict == "4" || userOutcomePredict.ToLower() == "odd sum")
                    {
                        donePrediction = true;
                        userOutcomePredict = "4";
                        oddSumCount++;
                    }
                    else
                        Console.WriteLine("That's not one of the options, please try again");

                    Console.WriteLine();
                }
                Console.Clear();

                Console.WriteLine("It's time to roll the dice! Press ENTER to roll");
                Console.ReadLine();

                dice1.RollDie();
                dice2.RollDie();

                dice1Int = Convert.ToInt32(dice1.ToString());
                dice2Int = Convert.ToInt32(dice2.ToString());

                Console.WriteLine($"Dice 1 rolled a {dice1}");
                dice1.DrawRoll();

                Console.WriteLine();

                Console.WriteLine($"Dice 2 rolled a {dice2}");
                dice2.DrawRoll();

                Console.WriteLine();

                if (dice1Int == dice2Int && userOutcomePredict == "1")
                {
                    Console.WriteLine("You predicted it would roll doubles and you were correct! Adding " + (betAmount * 2).ToString("C") + " to your money!");
                    money += betAmount * 2;
                    totalMoneyMade += betAmount * 2;
                    gamesWon++;
                }
                else if (dice1Int != dice2Int && userOutcomePredict == "1")
                {
                    Console.WriteLine("You predicted it would roll doubles and you were incorrect... You will lose " + betAmount.ToString("C") + "...");
                    money -= betAmount;
                    totalMoneyLost += betAmount;
                    gamesLost++;
                }
                if (dice1Int != dice2Int && userOutcomePredict == "2")
                {
                    Console.WriteLine("You predicted it would not roll doubles and you were correct! Adding " + (betAmount / 2).ToString("C") + " to your money!");
                    money += betAmount / 2;
                    totalMoneyMade += betAmount / 2;
                    gamesWon++;
                }
                else if (dice1Int == dice2Int && userOutcomePredict == "2")
                {
                    Console.WriteLine("You predicted it would not roll doubles and you were incorrect... You will lose " + betAmount.ToString("C") + "...");
                    money -= betAmount;
                    totalMoneyLost += betAmount;
                    gamesLost++;
                }
                if ((dice1Int % dice2Int) == 0 && userOutcomePredict == "3")
                {
                    Console.WriteLine("You predicted it would be an even sum and you were correct! Adding " + betAmount.ToString("C") + " to your money!");
                    money += betAmount;
                    totalMoneyMade += betAmount;
                    gamesWon++;
                }
                else if ((dice1Int % dice2Int) != 0 && userOutcomePredict == "3")
                {
                    Console.WriteLine("You predicted it would be an even sum and you were incorrect... You will lose " + betAmount.ToString("C") + "...");
                    money -= betAmount;
                    totalMoneyLost += betAmount;
                    gamesLost++;
                }
                if ((dice1Int % dice2Int) != 0 && userOutcomePredict == "4")
                {
                    Console.WriteLine("You predicted it would be an odd sum and you were correct! Adding " + betAmount.ToString("C") + " to your money!");
                    money += betAmount;
                    totalMoneyMade += betAmount;
                    gamesWon++;
                }
                else if ((dice1Int % dice2Int) == 0 && userOutcomePredict == "4")
                {
                    Console.WriteLine("You predicted it would roll doubles and you were incorrect... You will lose " + betAmount.ToString("C") + "...");
                    money -= betAmount;
                    totalMoneyLost += betAmount;
                    gamesLost++;
                }

                Console.WriteLine();

                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();

                Console.Clear();

                if (money == 0)
                {
                    Console.WriteLine("You ran out of money... Press ENTER to end the game!");
                    Console.ReadLine();

                    done = true;
                }
                else
                {
                    while (!doneQuitChoice)
                    {
                        Console.Write("Do you want to quit? ");
                        quit = Console.ReadLine();

                        Console.WriteLine();

                        if (quit.ToLower() == "yes")
                        {
                            Console.WriteLine("Okay, quitting the program...");
                            doneQuitChoice = true;
                            done = true;
                        }
                        else if (quit.ToLower() == "no")
                        {
                            Console.WriteLine("Okay, let's play again...");
                            doneQuitChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("Please choose either yes or no...");

                            Console.WriteLine();
                        }
                    }
                }
                Console.Clear();
            }
            Console.WriteLine("Thanks for playing the game! Here are some stats: ");

            Console.WriteLine();

            Console.WriteLine("Total money remaining: " + money.ToString("C"));
            Console.WriteLine("Total money made: " + totalMoneyMade.ToString("C"));
            Console.WriteLine("Total money lost: " + totalMoneyLost.ToString("C"));
            Console.WriteLine("Total times you chose doubles: " + doubleCount);
            Console.WriteLine("Total times you chose not doubles: " + notDoubleCount);
            Console.WriteLine("Total times you chose even sum: " + evenSumCount);
            Console.WriteLine("Total times you chose odd sum: " + oddSumCount);
            Console.WriteLine("Total games played: " + gamesPlayed);
            Console.WriteLine("Total games won: " + gamesWon);
            Console.WriteLine("Total games lost: " + gamesLost);
            Console.ReadLine();
        }
    }
}
