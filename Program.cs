using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool gameLoopDone = false;
            bool PlayerWon = false;
            
            int failCounter = 0;
            string nextSteps = "";
            Random random = new Random();
            int randomNum = random.Next(1, 11);

            Console.WriteLine("Welcome to the number guessing game!");
            Console.WriteLine("A number between 1 and 10 will be generated.");
            Console.WriteLine("You have three guesses. If you guess the correct number, you win!");

            while (!gameLoopDone && failCounter < 3)
            {

                Console.WriteLine("Please enter your guess:");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (guess > randomNum)
                {
                    Console.WriteLine("Your guess is too high.");
                    failCounter++;
                } 
                else if (guess < randomNum)
                {
                    Console.WriteLine("Your guess is too low.");
                    failCounter++;
                }
                else if (guess == randomNum)
                {
                    Console.WriteLine("Correct!");
                    gameLoopDone = true;
                    PlayerWon = true;
                }

                if (failCounter > 2)
                {
                    gameLoopDone = true;
                    Console.WriteLine("You lost.");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again? (yes/no)");
                    nextSteps = Console.ReadLine();
                }
                else if (PlayerWon == true)
                {
                    Console.WriteLine("Congratulations, you won the game!");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again? (yes/no)");
                    nextSteps = Console.ReadLine();
                }

                if (gameLoopDone == true && nextSteps == "yes")
                {
                    gameLoopDone = false;
                    PlayerWon = false;
                    failCounter = 0;
                }
                else if (gameLoopDone == true && nextSteps == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Cheers. Press any key to close program.");
                }

            }
            
            Console.ReadKey();
        }
    }
}
