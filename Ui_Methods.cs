using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    class Ui_Methods
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Electric Guitar Quiz Challenge");
        }
        public static void PrintGoodbyeMessage()
        {
            Console.WriteLine("Thank you for playing the Electric Guitar Quiz Challenge");
        }
        public static char GetUserInput() // this will act as a placeholder for the user input unless saved in a var
        {
            char userInput = Console.ReadKey().KeyChar; // get the user input to work in the in game selection
            return userInput;
        }
        public static void GetCorrectAnswer(char getUserinput)
        {
            if (char.ToUpper(getUserinput) == ConstantsVAR.USER_SELECTION_A)
            {
                Console.WriteLine("This is NOT the correct Answer!");
            }
            else if (char.ToUpper(getUserinput) == ConstantsVAR.USER_SELECTION_B)
            {
                Console.WriteLine("This is NOT the correct Answer!");
            }
            else if (char.ToUpper(getUserinput) == ConstantsVAR.USER_SELECTION_C) // this is the correct answer
            {
                Console.WriteLine("This is the correct Answer!");
            }
            else if (char.ToUpper(getUserinput) == ConstantsVAR.USER_SELECTION_D)
            {
                Console.WriteLine("This is NOT the correct Answer!");
            }
        }

        public static void DisplayingSavedToFile()
        {
            // basic messagefor saving files
            Console.WriteLine("Saved To XML!");
        }
        ///__-------------------------------------------- UserCreation Prompts ---------------------------------------____-----_--_----_-//

        public static void CreatingQuestionPrompt()
        {
            Console.WriteLine("Please input the question text");
        }
        public static void CreatingAvaibleOptionsPrompt()
        {
            Console.WriteLine("Please Input the avaliable option");
        }
        public static void CreatingCorrectAnswerPrompt()
        {
            Console.WriteLine("Please input the correct answer");
        }

        public static int InputNumberOfQuestions()// prompt user question on how many "questions" they want 
        {
            Console.WriteLine("How many questions do you want to create?");
            int numberOfQuestions = Console.Read();
            return numberOfQuestions;
        }
        //--------_____--------------------------------------FORLOOP  ---------------------------------------







        ///--------_____--------------------------------------  ---------------------------------------

        public static char GetValidUserChoice()// this is a answer "bluePrint" for the In game selection
        {
            char userInput = Ui_Methods.GetUserInput();
            bool isTheSelectionValid = false;

            do
            {
                if (char.ToUpper(userInput) != ConstantsVAR.USER_SELECTION_A
                    && char.ToUpper(userInput) != ConstantsVAR.USER_SELECTION_B
                    && char.ToUpper(userInput) != ConstantsVAR.USER_SELECTION_C
                    && char.ToUpper(userInput) != ConstantsVAR.USER_SELECTION_D
                    && char.ToUpper(userInput) != ConstantsVAR.USER_SELECTION_E)
                {
                    Console.WriteLine("This isn't within the selection parameters, Please try again");
                    userInput = Ui_Methods.GetUserInput(); // if the user input is not valid, it will ask the user to try again.
                }

                else
                {
                    isTheSelectionValid = true; // if the user input is valid, it will set the variable to true.
                    Console.WriteLine($" You've selected {userInput}"); // might use GetcorrectAnswer() method here to check if the user input is correct or not.
                }

                Ui_Methods.GetCorrectAnswer(userInput); // this will check if the user input is correct or not.
            }
            while (!isTheSelectionValid); // this will keep asking the user for input until the input is valid.

            return userInput; // if the user input is valid, it will return the user input.
        }

        // ___-----_--------------------------------------  ---------------------------------------____-----_--_----_-//
        // Might delete from line 123 to line 147
        public static char CreateUserTypedQuestion() // this will allow the user to create a quiz question 
        {
            Console.WriteLine("Create a Question for your Quiz Game");
            string createdQuestionText = Console.ReadLine(); // this will store the users typed question text

            char userGameQuestionChoice = Console.ReadKey().KeyChar; // declare for char input for User variable
            bool isTheInputValid = false;

            do
            {
                Console.WriteLine("Would you like to Create more question for the Quiz Game Y/N ?");
                userGameQuestionChoice = char.ToUpper(Console.ReadKey().KeyChar); // this will get the user input and convert it to uppercase
                Console.WriteLine(); // creates a "break" line in the program 

                isTheInputValid = userGameQuestionChoice == ConstantsVAR.USERSELECT_YES ||
                                  userGameQuestionChoice == ConstantsVAR.USERSELECT_NO; // this will check if the user input is valid or not

                if (!isTheInputValid)
                {
                    Console.WriteLine("This is not a valid selection. PLease enter Y or N.");
                }

            } while (!isTheInputValid); // this will keep asking the user for input until the input is valid.

            if (userGameQuestionChoice == ConstantsVAR.USERSELECT_YES)
            {
                Console.WriteLine("Please continue to create more question");

            }
            else
            {
                Console.WriteLine("Thank you for creating a question for the Quiz Game");
            }
            return userGameQuestionChoice; // this will return the user input
        }




        // ___-----_--------------------------------------  ---------------------------------------____-----_--_----_-//


        public static string GetNumericUserInput() // This gets the Number input from the user for The SelectionGameMode() method
        {
            int numericInput;
            string userNumericInput = "";

            do
            {
                Console.WriteLine("Enter a choice ");
                userNumericInput = Console.ReadLine(); // <=== fix this potential issue with the input being null or empty

                if (int.TryParse(userNumericInput, out numericInput))
                {
                    Console.WriteLine($"You've Entered{numericInput} ");
                }
                else
                {
                    Console.WriteLine("Invaild number , please enter again.");
                }

            } while (!int.TryParse(userNumericInput, out numericInput)); // this will keep asking the user for input until the input is valid.

            return numericInput.ToString(); // return the numeric input as a string
        }
        public static int ValidatingNumericInput() // this will validate the numeric input within the range of 1 to 4 and will not exceed that range.
        {
            string userInput = GetNumericUserInput();
            int numericInput;
            bool isTheSelectionValid = false;

            do
            {
                if (Int32.TryParse(userInput, out numericInput))
                {
                    if (numericInput < ConstantsVAR.RANGE_MIN && numericInput > ConstantsVAR.RANGE_MAX)
                    {
                        Console.WriteLine("This is not within the Correct Selection range Please try again");
                        userInput = GetNumericUserInput();// the the input isn't valid the user get this message. 
                    }
                    else
                    {
                        isTheSelectionValid = true;
                        Console.WriteLine($"You have selected {numericInput}");
                    }
                }

            } while (!isTheSelectionValid);

            return numericInput;
        }

        public static int SelectingGameMode() // this is for the outer game mode meaning selecting numeric values.
        {
            Console.WriteLine("Please Select ONE of the following game mode please ");

            int userChoice = ValidatingNumericInput(); // potnetial issue?

            Console.WriteLine();

            if (userChoice == ConstantsVAR.RANGE_MIN)
            {
                Console.WriteLine($"You have selected: {userChoice}");
                Console.WriteLine("GuitarBodies");
            }

            else if (userChoice == ConstantsVAR.NUMBER_SELECTION_TWO)
            {
                Console.WriteLine($"You have selected: {userChoice}");
                Console.WriteLine("GuitarPickups");
            }

            else if (userChoice == ConstantsVAR.NUMBER_ELECTION_THREE)
            {
                Console.WriteLine($"You have selected: {userChoice}");
                Console.WriteLine("ColorORFinish");
            }
            else if (userChoice == ConstantsVAR.RANGE_MAX)
            {
                Console.WriteLine($"You have selected: {userChoice}");
                Console.WriteLine("FretBoard");
            }
            return userChoice;
        }

        public static char SelectingGameOrCreateMode()// selecting either create or play mode 
        {
            Console.WriteLine("Please select a game mode A or B"); 

            char userSelection = Console.ReadKey().KeyChar; // wait for user input
            bool isTheSelectionValid = false;
            do
            {
                if (userSelection != ConstantsVAR.USER_SELECTION_A && userSelection != ConstantsVAR.USER_SELECTION_B)
                {
                    isTheSelectionValid = false;
                    Console.WriteLine("\n This is not the correct selection, please make the correct selection");
                    userSelection = Console.ReadKey().KeyChar;// prompts the user to enter again.
                }
                else
                {
                    Console.WriteLine($"\n You have selected {userSelection}");
                    isTheSelectionValid = true;
                }
            }
            while (!isTheSelectionValid);
            return userSelection;
        }

        public static bool AreBothAnswersCorrect(char ans1, char ans2) // this is for if one or more answers are correct. this will be corrected afterwards
        {
            if (ans1 == 'C' && ans2 == 'D')
            {
                Console.WriteLine("These are the correct answers");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
