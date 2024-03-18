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
            // Game end variables
            bool gameLoopDone = false;
            bool PlayerWon = false;
            int failCounter = 0;

            // Storing if player wants to play again
            string nextSteps = "";

            // Random number generator (picks number between 1-10)
            Random random = new Random();
            int randomNum = random.Next(1, 11);

            // Welcome message to player and instructions
            Console.WriteLine("Welcome to the number guessing game!");
            Console.WriteLine("A number between 1 and 10 will be generated.");
            Console.WriteLine("You have three guesses. If you guess the correct number, you win!");

            // Game Loop. Player gets 3 guesses
            while (!gameLoopDone && failCounter < 3)
            {
                
                Console.WriteLine("Please enter your guess:");

                // Gets player guess, converts it from string to int
                int guess = Convert.ToInt32(Console.ReadLine());

                // Logic to test if guess is correct
                // Increase fail counter if guess is higher than randomNum
                if (guess > randomNum)
                {
                    Console.WriteLine("Your guess is too high.");
                    failCounter++;
                }
                // Increase fail counter if guess is lower than randomNum
                else if (guess < randomNum)
                {
                    Console.WriteLine("Your guess is too low.");
                    failCounter++;
                }
                // Sets two game end variables to true if player guess is correct
                else if (guess == randomNum)
                {
                    Console.WriteLine("Correct!");
                    gameLoopDone = true;
                    PlayerWon = true;
                }

                // Logic dependent on if player wins/loses
                // Player loses
                if (failCounter > 2)
                {
                    // Variable to end game loop
                    gameLoopDone = true;

                    // Notification that player won, askes if another round will be played
                    Console.WriteLine("You lost.");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again? (yes/no)");

                    // Store if player wants to play another round
                    nextSteps = Console.ReadLine();
                }
                // Player wins
                else if (PlayerWon == true)
                {
                    // Notification that player won, askes if another round will be played
                    Console.WriteLine("Congratulations, you won the game!");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again? (yes/no)");

                    // Store if player wants to play another round
                    nextSteps = Console.ReadLine();
                }

                // Decision if player will play another round
                // Player answers Yes
                if (gameLoopDone == true && nextSteps == "yes")
                {
                    // Reset game end variables
                    gameLoopDone = false;
                    PlayerWon = false;
                    failCounter = 0;

                    // Generates new number to guess
                    randomNum = random.Next(1, 11);
                }
                // Player answers No
                else if (gameLoopDone == true && nextSteps == "no")
                {
                    // Requests player input to close program
                    Console.WriteLine();
                    Console.WriteLine("Cheers. Press any key to close program.");
                }

            }
            
            // Close program
            Console.ReadKey();
        }
    }
}
