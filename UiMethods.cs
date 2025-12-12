using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace ElectricGuitarQuiz
{
    class UiMethods
    {
        public static void PrintWelcomeMessageForBuildMode()
        {
            Console.WriteLine("\n Welcome to Quiz Creator mode you'll be guided step by step to Build you own quiz");
            Console.WriteLine("\nFirst you will either select build or Play");
        }

        public static char GetValidSelectionWhileBuildModeIsCompleted()
        {
            Console.WriteLine($"\nPlease select a mode {Constants.USER_SELECTION_A} or {Constants.USER_SELECTION_B} \n" +
                $" {Constants.USER_SELECTION_A}: Build Mode [Completed] \n {Constants.USER_SELECTION_B}: Play Mode");

            char userSelection = Console.ReadKey().KeyChar; // wait for user input for A and B selection 

            userSelection = char.ToUpper(userSelection); // convert the user input to uppercase for consistency 

            bool isTheSelectionValid = false;
            do
            {
                if (userSelection != Constants.USER_SELECTION_A && userSelection != Constants.USER_SELECTION_B)
                {
                    Console.WriteLine("\n This is not the correct selection, please make the correct selection");
                    userSelection = char.ToUpper(Console.ReadKey().KeyChar);// prompts the user to enter again.
                }
                else if (userSelection == Constants.USER_SELECTION_A)
                {
                    Console.WriteLine($"\n You have selected {userSelection} Build Mode");
                    isTheSelectionValid = true;
                }
                else if (userSelection == Constants.USER_SELECTION_B)
                {
                    Console.WriteLine($"\n You have selected {userSelection} Play Mode");
                    isTheSelectionValid = true;
                }
            }
            while (!isTheSelectionValid);
            return userSelection;

        }
        public static void PrintMainMenu()
        {
            Console.WriteLine(" 1. Build a new set of Questions");
            Console.WriteLine(" 2. View existing Questions");
            Console.WriteLine(" 3. Save");
            Console.WriteLine(" 4. Load Game");

            Console.WriteLine("\nPlease Enter a Selection :");
        }

        public static void PrintMainMenuWithBuildQuestCompleted()
        {
            Console.WriteLine(" 1.Build a new set of Questions [COMPLETED]");
            Console.WriteLine(" 2. View existing Questions");
            Console.WriteLine(" 3. Save");
            Console.WriteLine(" 4. Load Game");

            Console.WriteLine("\nPlease Enter a Selection :");
        }

        public static void PrintMainMenuWithoutOptions123()
        {
            Console.WriteLine(" 1.Build a new set of Questions [COMPLETED]");
            Console.WriteLine(" 2. View existing Questions[COMPLETED]");
            Console.WriteLine(" 3. Save[COMPLETED]");
            Console.WriteLine(" 4. Load Game");

            Console.WriteLine("\nPlease Enter a Selection :");
        }

        public static void WelcomeToPlayModeMessage()
        {
            Console.WriteLine("Welcome to play mode");
        }
        public static void ClearScreenAfterPlayModeSelected()
        {
            Console.Clear();
        }

        public static void ClearingTheUserScreen()
        {
            Console.WriteLine("Press any key to clear the screen");
            char PressAnyKey = char.ToUpper(Console.ReadKey().KeyChar);
            Console.Clear();
        }
        
        public static void PrintWhatTheUserSelected(int userInput)
        {
            switch (userInput)
            {
                case Constants.USER_SELECT_CHOICE_BUILD_GAME_MODE_1:
                    Console.WriteLine($"You have selected {userInput}: Create a new set");
                    
                    break;
                
                case Constants.USER_SELECT_CHOICE_VIEW_QUESTIONS_2:
                    Console.WriteLine($"You have selected {userInput}: View existing questions");
                
                    break;
                
                case Constants.USER_SELECT_CHOICE_3_SAVE:
                    Console.WriteLine($"You have selected {userInput}: Save and exit");
                   
                    break;
                
                case Constants.USER_SELECT_CHOICE_4_DESERIALIZE:
                    Console.WriteLine($"You have selected {userInput}: Deserialize");
                   
                    break;
                
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
        public static void NoListToDisplayMessage()
        {
            Console.WriteLine("There is no list to display, You have to create one first");
        }

        public static string GetUserInput() // this will act as a placeholder for the user input unless saved in a var
        {
            string userInput = Console.ReadLine(); // get the user input to work in the in game selection
            return userInput;
        }

        public static int ValidateUserChoice()
        {
            int userChoice;
            bool isTheInputValid = false;
            do
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out userChoice))
                {
                    if (userChoice >= Constants.GAMEOPTION_MIN && userChoice <= Constants.GAMEOPTION_MAX)
                    {
                        Console.WriteLine($"You have selected {userChoice}");
                        isTheInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine($" Number is out of range. Please enter a number between " +
                             $"{Constants.GAMEOPTION_MIN} & {Constants.GAMEOPTION_MAX}");
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

        public static string GetUserSelectedSavePath()
        {
            Console.WriteLine("Please enter the Directory to load your questions and answers to and please affix a XML file.");
            Console.WriteLine("\nexample: (Name).xml");
            string userDirectory = Console.ReadLine();
            return userDirectory;
        }

        public static void QuestionsLoadedMessage()
        {
            Console.WriteLine("Questions from xml file loaded.....");
        }

        public static string saveUserDirectoryPath = null;

        public static void DisplayingSavedFileMessage()
        {
            // basic message for saving files
            Console.WriteLine(".....Saved To XML!");
        }
       
        ///__-------------------------------------------- UserCreation Prompts ---------------------------------------____-----_--_----_-//

        public static void PromptUserToCreateQuestions() // NOTE: use for create part of program
        {
            Console.WriteLine("Please Enter the question text"); // use for Create part of program
        }

        public static int InputNumberOfQuestions()// prompt user question on how many "questions" they want 
        {
            Console.WriteLine("\nHow many questions do you want to create?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            return numberOfQuestions;
        }

        public static int InputNumberOfAnswers()
        {
            Console.WriteLine("How many options/answers do you want?");
            int numberOfAnswers = int.Parse(Console.ReadLine()); // used Parse because it would have given an answer of 54 (ASCII)
            return numberOfAnswers;
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

                question.CorrectAnswers = CreatingMultipleOrSingleCorrectAnswers();
                Console.WriteLine();

                quizQuestion.Add(question); // adds typed answer to the list NEEDS to BE SAVED TO VARIABLE?
            }
            return quizQuestion;
        }
        public static char GetValidOptionMode()// selecting either create or play mode 
        {
            Console.WriteLine("Please select a mode A or B \n A: Build Mode \n B: Play Mode");

            char userSelection = Console.ReadKey().KeyChar; // wait for user input for A and B selection 

            userSelection = char.ToUpper(userSelection); // convert the user input to uppercase for consistency 

            bool isTheSelectionValid = false;
            do
            {
                if (userSelection != Constants.USER_SELECTION_A && userSelection != Constants.USER_SELECTION_B)
                {
                    Console.WriteLine("\n This is not the correct selection, please make the correct selection");
                    userSelection = char.ToUpper(Console.ReadKey().KeyChar);// prompts the user to enter again.
                }
                else if (userSelection == Constants.USER_SELECTION_A)
                {
                    Console.WriteLine($"\n You have selected {userSelection}... Build Mode");
                    isTheSelectionValid = true;
                }
                else if (userSelection == Constants.USER_SELECTION_B)
                {
                    Console.WriteLine($"\n You have selected {userSelection}... Play Mode");
                    isTheSelectionValid = true;
                }
            }
            while (!isTheSelectionValid);
            return userSelection;
        }
        //use this in the main program to replace the other stuff I have in the playmode and change the name of method later

        public static int ReturnPlayerScore(string userSelection, List<string> CorrectAnswer)
        {
            bool isTheAnswerCorrect = false;
            bool isEitherAnswerCorrectOrIncorrect = false;
            int addedScore, deductedScore;

            if (CorrectAnswer.Contains(userSelection)) //used Contains() method because cannot compare list to char directly
            {
                isTheAnswerCorrect = true;
                Console.WriteLine($"{userSelection} is correct");
                addedScore = GameVariable.POINTS_PER_CORRECT_ANSWER + GameVariable.PLAYER_SCORE;
                Console.WriteLine($" Your score is :{addedScore}");
                isTheAnswerCorrect = true;

            }
            else if (!CorrectAnswer.Contains(userSelection)) //used Contains() method because cannot compare list to char directly
            {
                Console.WriteLine($"{userSelection} is incorrect");
                deductedScore = GameVariable.POINTS_DEDUCTED_PER_WRONG_ANSWER + GameVariable.PLAYER_SCORE;
                Console.WriteLine($" Your score is :{deductedScore}");
            }
            //return isEitherAnswerCorrectOrIncorrect; // this might now wotk correctly GO OVER THIS AGAIN!!
            GameVariable.PLAYER_SCORE++;

            return GameVariable.PLAYER_SCORE;
        }

        // used to pass questions and answers variable to display them to user
        public static void GetAndDisplayUserCreatedQAndAs(List<QuizQuestion> questions) // q's and A's = questions and answers :P
        {
            foreach (var question in questions)
            {
                Console.WriteLine(question.WrittenOutQuestion);
                foreach (var option in question.Options)
                {
                    Console.WriteLine(option);
                }
                // Console.WriteLine($"Correct Answer: {question.CorrectAnswer}"); commented out to not display correct answer to Player
            }
        }
        // put this into the program create Mode
        public static List<string> CreatingMultipleOrSingleCorrectAnswers() // this is for if one or more answers are correct. this will be corrected afterwards
        {
            Console.WriteLine("Would you like for there to be 2 correct answers in the Question Y/N?");

            char userInput = char.ToUpper(Console.ReadKey().KeyChar); // get the user input and make it uppercase

            List<string> correctAnswers = new List<string>();

            if (userInput == Constants.USERSELECT_YES)
            {
                Console.WriteLine("\nPlease Enter the 1st of 2 correct answers");
                string ans1 = (Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("\nPLease Enter the 2nd of 2 correct answers");
                string ans2 = (Console.ReadLine());
                Console.WriteLine();

                correctAnswers.Add(ans1);
                correctAnswers.Add(ans2);

            }
            else if (userInput == Constants.USERSELECT_NO)
            {
                Console.WriteLine(" \nPlease input one single correct answer for the question..");
                string ans = (Console.ReadLine()); // have the User create the single answer 
                string upperAns = ans.ToUpper(); // used to make the answer uppercase
                Console.WriteLine();
                correctAnswers.Add(ans);
            }

            return correctAnswers; // if the user does not want to have two correct answers, then return false
        }
    }
}
