using System.Diagnostics;

namespace ElectricGuitarQuiz
{
    class UiMethods
    {
        public static void PrintWelcomeMessageForBuildMode()
        {
            Console.WriteLine("\n Welcome to Quiz Creator mode you'll be guided step by step to Build you own quiz");
            Console.WriteLine("\nFirst you will either select build or Play");
        }

        public static char PrintWelcomeMessageForPlayMode()
        {
            Console.WriteLine("Please select a mode A or B \n A: Build Mode [Completed] \n B: Play Mode");

            char userSelection = Console.ReadKey().KeyChar; // wait for user input for A and B selection 

            userSelection = char.ToUpper(userSelection); // convert the user input to uppercase for consistency 

            bool isTheSelectionValid = false;
            do
            {
                if (userSelection != Constants.USER_SELECTION_A && userSelection != Constants.USER_SELECTION_B)
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

        public static void PrintMainMenu()
        {
            Console.WriteLine(" 1. Build a new set of Questions");
            Console.WriteLine(" 2. View existing Questions");
            Console.WriteLine(" 3. Save and exit");
            Console.WriteLine(" 4. Load Game");

            Console.WriteLine("\nPlease Enter a Selection :");
        }

        public static void PrintMainMenuWOBuildingNewQuestions()
        {
            Console.WriteLine(" 1.Build a new set of Questions [COMPLETED]");
            Console.WriteLine(" 2. View existing Questions");
            Console.WriteLine(" 3. Save and exit");
            Console.WriteLine(" 4. Load Game");

            Console.WriteLine("\nPlease Enter a Selection :");
        }

        public static void PriniMainMenuWithoutOptions123()
        {
            Console.WriteLine(" 1.Build a new set of Questions [COMPLETED]");
            Console.WriteLine(" 2. View existing Questions[COMPLETED]");
            Console.WriteLine(" 3. Save and exit[COMPLETED]");
            Console.WriteLine(" 4. Load Game");

            Console.WriteLine("\nPlease Enter a Selection :");
        }
        public static void CreatedQuestionsMessage()
        {
            Console.WriteLine("Here are the Questions that were created ");
        }

        public static void NoQuestionsCreatedMessage()
        {
            Console.WriteLine("No questions have been created yet, please create some questions first.");
        }
        
        public static void WelcomeToPlayModeMessage()
        {
            Console.WriteLine("Welcome to play mode");
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

        
        public static void ClearingTheUserScreen()
        {
            Console.Clear();
        }
        public static int PrintWhatTheUserSelected(int userInput)
        {
            if (userInput == Constants.USER_SELECT_CHOICE_1)
            {
                Console.WriteLine($"You Have selected {userInput}: Create a new set");
            }

            else if (userInput == Constants.USER_SELECT_CHOICE_2)
            {
                Console.WriteLine($"You have selected{userInput}: View existing questions");
            }
            else if (userInput == Constants.USER_SELECT_CHOICE_3_SAVE)
            {
                Console.WriteLine($" You have selected {userInput}: Save and exit");
            }
            else if (userInput == Constants.USER_SELECT_CHOICE_4_DESERIALIZE)
            {
                Console.WriteLine($"You have selected {userInput}: Deserialize");
            }

            return userInput;
        }
        public static void NoListToDisplayMessage()
        {
            Console.WriteLine("There is no list to display, You have to create one first");
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
                    if (userChoice >= Constants.GAMEOPTION_MIN && userChoice <= Constants.GAMEOPTION_MAX)
                    {
                        Console.WriteLine($"You have selected {userChoice}");
                        isTheInputValid = true;
                    }
                    else
                    {
                        Console.WriteLine($" Number is out of range. Please enter a number between" +
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
            Console.WriteLine("\n example (Name).xml");
            string userDirectory = Console.ReadLine();
            return userDirectory;
        }

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

        public static void PromptUserToCreateCorrectAnswer()
        {
            Console.WriteLine("Please input the correct answer, ex: (A, B, C, D, etc..):");
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

                isTheInputValid = userGameQuestionChoice == Constants.USERSELECT_YES ||
                                  userGameQuestionChoice == Constants.USERSELECT_NO; // this will check if the user input is valid or not

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

            if (userGameQuestionChoice == Constants.USERSELECT_YES)
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

                question.CorrectAnswers = CreatingMultipleOrSingleCorrectAnswers();
                Console.WriteLine();

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

        public static void ValidatingCreatedQuestionList()
        {
            List<QuizQuestion> questions = UiMethods.PrintQuestionsAndAnswersForGame();
            if (questions == null || questions.Count == 0)
            {
                Console.WriteLine("No questions available. Please create some questions first.");
                questions = UiMethods.PrintQuestionsAndAnswersForGame();

            }
            else
            {
                Console.WriteLine($"There are {questions.Count} questions available.");
            } //  dont use this method yet 
        }

        public static List<QuizQuestion> EnsureQuestionListExists(List<QuizQuestion> existingList)
        {
            if (existingList == null || existingList.Count == 0)
            {
                Console.WriteLine("No questions and answers are available. Please create some them first.");
                existingList = UiMethods.PrintQuestionsAndAnswersForGame();
            }
            else
            {
                Console.WriteLine($"There are {existingList.Count} questions available.");
            }

            return existingList;
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
        //use this in the main program to replace the other stuff I have in the playmode and change the name of method later
        public static void PlayGameMode(char userSelection, List <char> CorrectAnswer)
        {
            // have a display message for created questions method here
            // usd randomizer method to pick a random question from the list

            // and also display the questions to the user, The random questions 
           // GamePLAy MOde should have game points in this method 

            // step1 display the questions to the user 
            //step 2 display the current score to the user
            // Perhaps that this whole method should return a score so that the consdition under it can deterime whether the...
            // ..user has won or not 

            UiMethods.CreatedQuestionsMessage();
            bool isTheAnswerCorrect = false;
            int addedScore, deductedScore;

            // might have to change the logic here later
            if (CorrectAnswer.Contains(userSelection)) //used Contains() method because cannot compare list to char directly
            {
                isTheAnswerCorrect = true;
                Console.WriteLine($"{userSelection} is correct");
                addedScore = GameVariable.POINTS_PER_CORRECT_ANSWER + GameVariable.PLAYER_SCORE;
                Console.WriteLine($" Your score is :{addedScore}");
            }
            else if (CorrectAnswer.Contains(userSelection)) //used Contains() method because cannot compare list to char directly
            {
                Console.WriteLine($"{userSelection} is incorrect");
                deductedScore = GameVariable.POINTS_DEDUCTED_PER_WRONG_ANSWER + GameVariable.PLAYER_SCORE;
                Console.WriteLine($" Your score is :{deductedScore}");
            }
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
        public static List <char> CreatingMultipleOrSingleCorrectAnswers() // this is for if one or more answers are correct. this will be corrected afterwards
        {
            Console.WriteLine("Would you like for there to be 2 correct answers in the Question Y/N?");

            char userInput = char.ToUpper(Console.ReadKey().KeyChar); // get the user input and make it uppercase

            List<char> correctAnswers = new List<char>();

            if (userInput == Constants.USERSELECT_YES)
            {
                Console.WriteLine("\nPlease Enter the 1st of two correct answers");
                char ans1 = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                Console.WriteLine("Enter the 2nd of 2 correct answers");
                char ans2 = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                correctAnswers.Add(ans1);
                correctAnswers.Add(ans2);

            }
            else if (userInput == Constants.USERSELECT_NO)
            {
                Console.WriteLine(" \nPlease Continue with creating the Single Questions..press any key to proceed");
                char ans = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                correctAnswers.Add(ans);
            }
                return correctAnswers; // if the user does not want to have two correct answers, then return false
        }
    }
}
