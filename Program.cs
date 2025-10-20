using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UiMethods.PrintWelcomeMessageForBuildMode();
            // UiMethods.PrintQuestionsAndAnswersForGame(); //placed here to make this a global method
            //UiMethods.PrintMainMenu();
            // while (!quit) {
            char userInputSelect = UiMethods.SelectingGameOrCreateMode();

            List<QuizQuestion> questions = null;// used to scan for is user is going to select this first without creating a question first
            
            if (userInputSelect == ConstantsVAR.BUILD_QUIZ_MODE)
            {
                UiMethods.PrintMainMenu();
                int userChoice = UiMethods.UserChoice();

                // Builds a new set of Questions.
                if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_1)
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

                
                // if the user selects 2 view existing questions
                else if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_2)
                {
                    Logic.EnsureQuestionListExists(questions);
                    // method made to view existing questions for the list that the user has created
                    //Logic.ValidatingCreatedQuestionList();
                }

                //if user selects 3 save question to file 
                else if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_3_SAVE)
                {
                    // here put 
                    Logic.EnsureQuestionListExists(questions);
                    List<QuizQuestion> results = UiMethods.PrintQuestionsAndAnswersForGame();

                    string saveUserDirectoryPath = UiMethods.GetUserSelectedSavePath();

                    // method made to save questions to XML file
                    QuizQuestion.SaveQuestionToFile(results, saveUserDirectoryPath);

                    // this is just a message method.
                    UiMethods.DisplayingSavedToFileMessage();
                }

               

                bool isThereAListInPlace = UiMethods.CheckIfListIsNotEmpty(questions); // this is to check if the list is empty or not

                if (isThereAListInPlace)
                {
                    UiMethods.ContinueWithPlayingMessage();
                }
                else
                {
                    questions = Logic.EnsureQuestionListExists(questions);
                }
                Logic.EnsureQuestionListExists(questions);
                //Logic.ValidatingCreatedQuestionList(); // replace with the EnsureQuestionListExists method

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
                if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_1)
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
                else if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_2)
                {
                    Logic.ValidatingCreatedQuestionList();
                    UiMethods.GetAndDisplayUserCreatedQAndAs(UiMethods.PrintQuestionsAndAnswersForGame());

                }

                else if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_3_SAVE)
                {   // is placed the just in case the user tries to save without creating any questions first
                    Logic.EnsureQuestionListExists(UiMethods.PrintQuestionsAndAnswersForGame());

                    List<QuizQuestion> results = UiMethods.PrintQuestionsAndAnswersForGame();
                    string saveFilePath = UiMethods.GetUserSelectedSavePath();
                    QuizQuestion.SaveQuestionToFile(results, saveFilePath);
                }
                // deserialize the list
                else if (userChoice == ConstantsVAR.USER_SELECT_CHOICE_4_DESERIALIZE)
                {// is placed the just in case the user tries to load without creating any questions first
                    Logic.EnsureQuestionListExists(UiMethods.PrintQuestionsAndAnswersForGame());

                    string saveUserDirectoryPath = UiMethods.GetUserSelectedSavePath();
                    List<QuizQuestion> loadedQuestion = QuizQuestion.LoadQuestionFromFile(saveUserDirectoryPath);

                    foreach (QuizQuestion question in loadedQuestion)
                    {
                        Console.WriteLine(question.ToString());
                    }
                }
            }

            // QuizQuestion questionManager = new QuizQuestion(); // creating an instance of the GuitarQuestion class

            // create the question
            // QuizQuestion question = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object



        }
    }
}
