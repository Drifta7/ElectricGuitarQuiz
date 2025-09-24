using System.Globalization;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UiMethods.PrintWelcomeMessageForCreateMode();
            UiMethods.PrintMainMenu();

            char userInputSelect = UiMethods.SelectingGameOrCreateMode();

            if (userInputSelect == ConstantsVAR.START_PLAY_MODE) // this will house the Play Mode
            {
                UiMethods.PrintWelcomeMessage();
                QuizQuestion start = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

                // QuizQuestion Question_2 = new GuitarQuestionsList().GetSampleQuestion_1();

                QuizQuestion.PrintOutSelectedNumberOfQuestions();
                UiMethods.GetCorrectAnswer(UiMethods.GetUserInput());
                //UiMethods.PrintGoodbyeMessage();
            }
           
            
            List<QuizQuestion> PrintQnAndAnsMethodResults = UiMethods.PrintQuestionsAndAnswersForGame();

            if (userInputSelect == ConstantsVAR.BUILD_QUIZ_MODE) // this will houses the Create mode
            {
                UiMethods.PrintWelcomeMessageForCreateMode();
                UiMethods.PrintMainMenu();
               
                int userChoice = Convert.ToInt32(Console.ReadLine());

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
                else if (userInputSelect == ConstantsVAR.USER_GAME_CHOICE_2)
                {
                    bool checkListVar =  UiMethods.CheckIfListIsNotEmpty(PrintQnAndAnsMethodResults); // the actual name of the list not the class

                    if (checkListVar)
                    {
                        // display the list
                        UiMethods.TestIfListIsThere(); //TESTing 
                    }
                    else if (!checkListVar)
                    {
                        UiMethods.NoListToDisplayMessage();
                    }
                }
            }
           
            QuizQuestion questionManager = new QuizQuestion(); // creating an instance of the GuitarQuestion class

            // create the question
            QuizQuestion question = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

            Logic.SavingQuestionsToFile(); //

        }
    }
}
