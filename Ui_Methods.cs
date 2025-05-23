using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    class Ui_Methods
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Electric Guitar Quiz Challenge ");
        }
        public static void PrintGoodbyeMessage()
        {
            Console.WriteLine("Thank you for playing the Electric Guitar Quiz Challenge");
        }
        public static char UserInput(char playeranswer) // this will act as a placeholder for the user input unless saved in a var
        {
            return playeranswer;
        }

        public static int SelectingGameMode(int userChoice)
        {
            Console.WriteLine("Please Select ONE of the following game mode please ");

            Console.WriteLine();
            if (userChoice == 1)
            {
                Console.WriteLine("GuitarBodies");
                Console.WriteLine($"You have selected{userChoice}");
            }

            else if (userChoice == 2)
            {
                Console.WriteLine("GuitarPickups");
                Console.WriteLine($"You have selected {userChoice}");
            }

            else if (userChoice == 3)
            {
                Console.WriteLine($"ColorORFinish");
                Console.WriteLine($"You have selected {userChoice}");
            }
            return userChoice;
        }
    }
}
