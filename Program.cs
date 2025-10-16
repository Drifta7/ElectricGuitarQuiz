using System.Globalization;
using System.Xml.Linq;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UiMethods.PrintWelcomeMessageForBuildMode();
            //UiMethods.PrintMainMenu();

            char userInputSelect = UiMethods.SelectingGameOrCreateMode();

            if (userInputSelect == ConstantsVAR.BUILD_QUIZ_MODE)
            {
                UiMethods.PrintMainMenu();
                int userChoice = UiMethods.UserChoice();

                if (userChoice == ConstantsVAR.USER_GAME_CHOICE_1)
                {
                    UiMethods.PrintWhatTheUserSelected(userChoice); // NEED TO INITIALIZE OPIONS 2 AND 3
                    bool gameOver = false;

                    while (!gameOver)
                    {
                        UiMethods.PrintQuestionsAndAnswersForGame();

                        char userToQuit = UiMethods.PromptingUserToCreateMoreQuestions();

                        if (userToQuit == ConstantsVAR.USERSELECT_NO)
                        {
                            UiMethods.PrintGoodbyeMessage(); // this will print out a goodbye message to the user when they quit the game
                            gameOver = true;
                        }
                    }
                }
                else if (userChoice == ConstantsVAR.USER_OPTION_CHOICE2)
                {
                    // view existing questions for the list that the user has created 
                    Logic.ValidatingCreatedQuestionList();
                }
                if (userChoice == ConstantsVAR.USER_OPTION_CHOICE3)
                {
                    // this is just a message method.
                    UiMethods.DisplayingSavedToFile(); // stating the obivious message
                                                       // save and exit: 
                                                       // bools quitGame = false;
                                                       // 1 create a method for saving the list for the XLM file?


                }
                List<QuizQuestion> questions = null;

                bool isThereAListInPlace = UiMethods.CheckIfListIsNotEmpty(questions); // this is to check if the list is empty or not

                if (!isThereAListInPlace)
                {
                    UiMethods.ContinueWithPlayingMessage();
                }
                else
                {
                    questions = Logic.EnsureQuestionListExists(questions);
                }
                Logic.ValidatingCreatedQuestionList();

                //QuizQuestion start = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

                QuizQuestion.PrintOutSelectedNumberOfQuestions();
                UiMethods.GetCorrectAnswer(UiMethods.GetUserInput());
                //UiMethods.PrintGoodbyeMessage();
            }
            //List<QuizQuestion> PrintQnAndAnsMethodResults = UiMethods.PrintQuestionsAndAnswersForGame();
            if (userInputSelect == ConstantsVAR.START_PLAY_MODE) // this will houses the Create mode
            {
                UiMethods.PrintMainMenu();
                int userChoice = UiMethods.UserChoice(); //used to check if the entry is valid

                // if the user selects 1 enter game creation mode 
                if (userChoice == ConstantsVAR.USER_GAME_CHOICE_1)
                {
                    UiMethods.PrintWhatTheUserSelected(userChoice);
                    bool gameOver = false;

                    while (!gameOver)
                    {
                        UiMethods.PrintQuestionsAndAnswersForGame();

                        char userToQuit = UiMethods.PromptingUserToCreateMoreQuestions();

                        if (userToQuit == ConstantsVAR.USERSELECT_NO)
                        {
                            UiMethods.PrintGoodbyeMessage(); // this will print out a goodbye message to the user when they quit the game
                            gameOver = true;
                        }
                    }
                }
                else if (userChoice == ConstantsVAR.USER_GAME_CHOICE_2)
                {
                    Logic.ValidatingCreatedQuestionList();
                    UiMethods.GetAndDisplayUserCreatedQAndAs(UiMethods.PrintQuestionsAndAnswersForGame());
                    // put in from Line 55 to Line 65 with in this file and Perhaps make it a Logic method

                }
                else if (userChoice == ConstantsVAR.USER_GAME_CHOICE_3)
                {
                    Logic.SavingQuestionsToFile(); 
                }
            }

               // QuizQuestion questionManager = new QuizQuestion(); // creating an instance of the GuitarQuestion class

            // create the question
            // QuizQuestion question = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

           

        }
    }
}
