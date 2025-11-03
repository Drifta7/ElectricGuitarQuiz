using System.Collections.Generic;
using System.Diagnostics;
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

            char userInputSelect = UiMethods.GetValidOptionMode();

            //used as a safty measure to ensure that if the user selects to view it will prompt a create message
            List<QuizQuestion> questions = null;
            //placed here to make this a global variable.

            List<QuizQuestion> createdQsAndAs = new List<QuizQuestion>();

            bool isBuildModeCompeleted = false;
            bool areTheQuestionsAndAnswersSaved = false;

            if (userInputSelect == Constants.BUILD_QUIZ_MODE)
            {
                UiMethods.PrintMainMenu();

                while (!isBuildModeCompeleted)
                {
                    int userChoice = UiMethods.UserChoice();

                    bool didTheUserFinishedCreatingTheQsAndAs = false;
                    // Builds a new set of Questions.
                    if (userChoice == Constants.USER_SELECT_CHOICE_1)
                    {
                        while (!didTheUserFinishedCreatingTheQsAndAs)
                        {
                            UiMethods.PrintWhatTheUserSelected(userChoice);

                            createdQsAndAs = UiMethods.PrintQuestionsAndAnswersForGame(); // saved to a var to be displayed later in the program
                            UiMethods.GetAndDisplayUserCreatedQAndAs(createdQsAndAs);

                            didTheUserFinishedCreatingTheQsAndAs = true;
                        }
                    }

                    // if the user selects 2 view existing questions
                    if (userChoice == Constants.USER_SELECT_CHOICE_2)
                    {
                        Logic.EnsureQuestionListExists(createdQsAndAs); // checks if the is there or not 

                        // existing questions for the list that the user has created
                        UiMethods.GetAndDisplayUserCreatedQAndAs(createdQsAndAs);
                        areTheQuestionsAndAnswersSaved = true;

                    }

                    //if user selects 3 save question to file 
                    if (userChoice == Constants.USER_SELECT_CHOICE_3_SAVE)
                    {
                        // here put 
                        Logic.EnsureQuestionListExists(createdQsAndAs);
                        List<QuizQuestion> results = createdQsAndAs;

                        string saveUserDirectoryPath = UiMethods.GetUserSelectedSavePath();

                        // method made to save questions to XML file
                        QuizQuestion.SaveQuestionToFile(results, saveUserDirectoryPath);

                        // this is just a message informing the user that the questions have been saved.
                        UiMethods.DisplayingSavedToFileMessage();

                    }

                    // used to deserialize the list from file
                    if (userChoice == Constants.USER_SELECT_CHOICE_4_DESERIALIZE)
                    {
                        Logic.EnsureQuestionListExists(questions);
                        QuizQuestion.LoadQuestionFromFile(UiMethods.GetUserSelectedSavePath());
                    }

                    if (isBuildModeCompeleted && areTheQuestionsAndAnswersSaved)
                    {
                        break;
                    }
                    else 
                        UiMethods.PrintMainMenuWOBuildingNewQuestions();
                    continue;
                }

                bool isThereAListInPlace = UiMethods.CheckIfListIsNotEmpty(questions); // this is to check if the list is empty or not




                //QuizQuestion start = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object
                List<QuizQuestion> GetRandomListQuestions = new List<QuizQuestion>();


                //List<QuizQuestion> PrintQnAndAnsMethodResults = UiMethods.PrintQuestionsAndAnswersForGame();
                if (userInputSelect == Constants.START_PLAY_MODE) // this will houses the Create mode
                {
                    UiMethods.WelcomeToPlayModeMessage(); // welcome message

                    UiMethods.PrintQuestionsAndAnswersForGame();

                    // will get a random question from the list
                    GetRandomListQuestions = new List<QuizQuestion> { Logic.GetRandomQuestion(createdQsAndAs) };

                    // this will loop through and display the questions and answers to the user
                    UiMethods.GetAndDisplayUserCreatedQAndAs(GetRandomListQuestions);

                    char UserSelection = UiMethods.GetUserInput();
                    char CorrectAnswer = GetRandomListQuestions[0].CorrectAnswer; // MIGHT HAVE TO DELECT THIS LATER!!!!!

                    bool gameOver = false;

                    while (!gameOver)
                    {
                        UiMethods.PlayGameMode(UserSelection, CorrectAnswer); // fix this later
                        if (GameVariable.PLAYER_SCORE >= 12)
                        {
                            Console.WriteLine("Congratulations! You win!"); // testing purposes
                        }
                        else if (GameVariable.PLAYER_SCORE <= 0)
                        {
                            Console.WriteLine("Game Over! Better luck next time."); // testing purposes 
                        }
                        gameOver = true;
                    }
                    // create or look for a function that will answer for the question that are being displayed 
                    // validate if the answers to the question are correct using if statements 
                    // integrate whether 2 answwrs to the question are correct or not 
                    // if the player answers above 70% of the game then they win if not they lose 

                    int userChoice = UiMethods.UserChoice(); //used to check if the entry is valid

                    // if the user selects 1 enter game creation mode 
                    if (userChoice == Constants.USER_SELECT_CHOICE_1)
                    {
                        UiMethods.PrintWhatTheUserSelected(userChoice);
                      

                    }
                    else if (userChoice == Constants.USER_SELECT_CHOICE_2)
                    {
                        UiMethods.ValidatingCreatedQuestionList();
                        UiMethods.GetAndDisplayUserCreatedQAndAs(UiMethods.PrintQuestionsAndAnswersForGame());
                    }

                    // select to save the list
                    else if (userChoice == Constants.USER_SELECT_CHOICE_3_SAVE)
                    {
                        // is placed the just in case the user tries to save without creating any questions first
                        Logic.EnsureQuestionListExists(UiMethods.PrintQuestionsAndAnswersForGame());

                        List<QuizQuestion> results = UiMethods.PrintQuestionsAndAnswersForGame();
                        string saveFilePath = UiMethods.GetUserSelectedSavePath();
                        QuizQuestion.SaveQuestionToFile(results, saveFilePath);
                    }

                    // deserialize the list
                    else if (userChoice == Constants.USER_SELECT_CHOICE_4_DESERIALIZE)
                    {
                        // is placed the just in case the user tries to load without creating any questions first
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
}