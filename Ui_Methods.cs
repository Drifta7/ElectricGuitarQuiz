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

         
    }
}
