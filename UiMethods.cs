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
    class UiMethods
    {
        public static void PrintWelcomeMessageForBuildMode()
        {
            Console.WriteLine("\n Welcome to Quiz Creator mode you'll be guided step by step to Build you own quiz");
            Console.WriteLine("\nFirst you will either select build or Play");
        }
        public static void PrintMainMenu()
        {
            Console.WriteLine(" 1. Build a new set of Questions");
            Console.WriteLine(" 2. View existing Questions");
            Console.WriteLine(" 3. Save and exit");

            Console.WriteLine("\nPlease Enter a Selection :");
        }

        public static bool CheckIfListIsNotEmpty(List<QuizQuestion> checkingList)
        {
            return checkingList != null && checkingList.Any(); // this checks if the list isn't null before it checks if it's empty
        }

        public static void ContinueWithPlayingMessage()
        {
            Console.WriteLine("Please continue with playing");
        }
        public static void EnterTheRightAnswerLetter()
        {
            Console.WriteLine("PLease lock in the answer");
            Console.WriteLine("Enter the correct (A,B,C,D, etc...):");
        }
        public static void PrintEndOfGameMenu() // place this at the end of the game.
        {
            Console.WriteLine("1. Create a new set of Questions");
            Console.WriteLine("2. View existing questions and answers ");
            Console.WriteLine("3. Save and exit");

            Console.WriteLine("\n Please enter a selection: ");
        }
        public static int PrintWhatTheUserSelected(int userInput)
        {
            if (userInput == ConstantsVAR.USER_GAME_CHOICE_1)
            {
                Console.WriteLine($"You Have selected {userInput}: Create a new set");
            }

            else if (userInput == ConstantsVAR.USER_GAME_CHOICE_2)
            {
                Console.WriteLine($"You have selected{userInput}: View existing questions");
            }
            else
                Console.WriteLine($" You have selected {userInput}: Save and exit");

            return userInput;
        }
        public static void NoListToDisplayMessage()
        {
            Console.WriteLine("There is no list to display, You have to create on first");
        }
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

        public static int UserChoice()
        {
            int userChoice;
            bool isTheInputValid = false;
            do
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out userChoice))
                {
                    if (userChoice >= ConstantsVAR.GAMEOPTION_MIN && userChoice <= ConstantsVAR.GAMEOPTION_MAX)
                    {
                        Console.WriteLine($"You have selected {userChoice}");
                        isTheInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine($" Number is out of range. Please enter a number between" +
                            $"{ConstantsVAR.GAMEOPTION_MIN} & {ConstantsVAR.GAMEOPTION_MAX}");
                    }
                }
                else
                {
                    Console.WriteLine("This is not a valid selection, please try again");
                }
            }
            while (!isTheInputValid);

            return userChoice;
        }

        public static void GetCorrectAnswer(char getUserInput)
        {
            if (char.ToUpper(getUserInput) == ConstantsVAR.USER_SELECTION_A || char.ToUpper(getUserInput) == ConstantsVAR.USER_SELECTION_B ||
                char.ToUpper(getUserInput) == ConstantsVAR.USER_SELECTION_C || char.ToUpper(getUserInput) == ConstantsVAR.USER_SELECTION_D ||
                char.ToUpper(getUserInput) == ConstantsVAR.USER_SELECTION_E)
            {
                Console.WriteLine("This is NOT the correct Answer!");
            }
        }

        public static void DisplayingSavedToFile()
        {
            // basic message for saving files
            Console.WriteLine("Saved To XML!");
        }
        ///__-------------------------------------------- UserCreation Prompts ---------------------------------------____-----_--_----_-//

        public static void PromptUserToCreateQuestions() // NOTE: use for create part of program
        {
            Console.WriteLine("Please Enter the question text"); // use for Create part of program
        }

        public static void PromptUserToCreateCorrectAnswer()
        {
            Console.WriteLine("Please input the correct answer, ex: (A, B, C, D, etc..):");
        }

        public static int InputNumberOfQuestions()// prompt user question on how many "questions" they want 
        {
            Console.WriteLine("How many questions do you want to create?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            return numberOfQuestions;
        }

        public static int InputNumberOfAnswers()
        {
            Console.WriteLine("How many options/answers do you want?");
            int numberOfAnswers = int.Parse(Console.ReadLine()); // if Parse wasn't there it would have given an answer of 54 (ASCII)
            return numberOfAnswers;
        }

        public static char PromptingUserToCreateMoreQuestions() // this will allow the user to create a quiz question 
        {
            char userGameQuestionChoice; // declare for char input for User variable DELETE THE FUNCTION
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
                    userGameQuestionChoice = char.ToUpper(Console.ReadKey().KeyChar); // if the user input is not valid, it will ask the user to try again.
                }
                else
                {
                    isTheInputValid = true;
                }

            }
            while (!isTheInputValid); // this will keep asking the user for input until the input is valid.

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

        public static List<QuizQuestion> PrintQuestionsAndAnswersForGame()
        {
            int numberOfQuestions = UiMethods.InputNumberOfQuestions();
            int numberOfAnswers = UiMethods.InputNumberOfAnswers();

            List<QuizQuestion> quizQuestion = new List<QuizQuestion>();

            bool isQuestionCreationComplete = false;

            for (int i = 0; i < numberOfQuestions; i++) // this will print out the selected number of questions
            {
                char multiChoiceChar = (char)('A' + i); // this will cast a char and the iterator "i" will increment the char value A, B, C, etc.
                QuizQuestion question = new QuizQuestion(); // creates a new instance of the question.
                question.Options = new List<string>();

                UiMethods.PromptUserToCreateQuestions();

                Console.WriteLine($" Enter question {i + 1}:");
                question.WrittenOutQuestion = Console.ReadLine(); // waits for user to input question

                for (int j = 0; j < numberOfAnswers; j++)
                {
                    char optionLabel = (char)('A' + j);
                    Console.WriteLine($"Option {optionLabel}");
                    string optionText = Console.ReadLine();
                    question.Options.Add($"{optionLabel}: {optionText}");// adds the option to the list with the label
                }

                string correctValidInput;
                do
                { // here should be a question asking for which is the right answer
                    Console.WriteLine("which question is the right answer?");
                    correctValidInput = Console.ReadLine().Trim().ToUpper();
                }
                while (string.IsNullOrEmpty(correctValidInput)); // used to make sure the user doesn't enter a blank entry
                UiMethods.EnterTheRightAnswerLetter();// <-----this is not needed 
                question.CorrectAnswer = Console.ReadLine().ToUpper()[0];// saved question? 

                quizQuestion.Add(question); // adds typed answer to the list NEEDS to BE SAVED TO VARIABLE?
            }
            return quizQuestion;
        }

        // here put in a method to seperate the nested for loop.
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
        public static char SelectingGameOrCreateMode()// selecting either create or play mode 
        {
            Console.WriteLine("Please select a mode A or B \n A: Build Mode \n B: Play Mode");

            char userSelection = Console.ReadKey().KeyChar; // wait for user input for A and B selection 

            userSelection = char.ToUpper(userSelection); // convert the user input to uppercase for consistency 

            bool isTheSelectionValid = false;
            do
            {
                if (userSelection != ConstantsVAR.USER_SELECTION_A && userSelection != ConstantsVAR.USER_SELECTION_B)
                {
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
        public static void GetAndDisplayUserCreatedQAndAs(List<QuizQuestion> questions)
        {
            foreach (var question in questions)
            {
                Console.WriteLine(question.WrittenOutQuestion);
                foreach (var option in question.Options)
                {
                    Console.WriteLine(option);
                }
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer}");
            }
        }
    }
}
