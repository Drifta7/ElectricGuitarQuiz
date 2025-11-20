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

                            UiMethods.ClearingTheUserScreen();
                            didTheUserFinishedCreatingTheQsAndAs = true;

                        }

                    }

                    // if the user selects 2 view existing questions
                    if (userChoice == Constants.USER_SELECT_CHOICE_2)
                    {
                        // placed here just in case if the user selects option as a safety measure 
                        if (Logic.CheckIfListIsNotEmpty(createdQsAndAs)) // checks if the created questions are there or not 
                        {
                            // displaying existing questions for the list that the user created
                            UiMethods.GetAndDisplayUserCreatedQAndAs(createdQsAndAs);
                            areTheQuestionsAndAnswersSaved = true;
                        }
                        else
                        {
                            UiMethods.NoListToDisplayMessage();
                        }
                        UiMethods.ClearingTheUserScreen();
                    }

                    //if user selects 3 save question to file 
                    if (userChoice == Constants.USER_SELECT_CHOICE_3_SAVE)
                    {
                        // placed here just in case if the user selects option as a safety measure 
                        if (!Logic.CheckIfListIsNotEmpty(createdQsAndAs))
                        {
                            UiMethods.NoListToDisplayMessage();
                            continue;
                        }

                        string saveUserDirectoryPath = UiMethods.GetUserSelectedSavePath();

                        // method made to save questions passed into the parameters to create an XML file
                        Logic.SaveQuestionToFile(createdQsAndAs, saveUserDirectoryPath);

                        // this is just a message informing the user that the questions have been saved.
                        UiMethods.DisplayingSavedFileMessage();

                        UiMethods.ClearingTheUserScreen();
                        UiMethods.PriniMainMenuWithoutOptions123();
                        areTheQuestionsAndAnswersSaved = true;
                    }

                    // used to deserialize the list from file
                    if (userChoice == Constants.USER_SELECT_CHOICE_4_DESERIALIZE)
                    {

                        //UiMethods.EnsureQuestionListExists(createdQsAndAs);
                       // Logic.LoadQuestionFromFile(UiMethods.GetUserSelectedSavePath());// this is incorrect


                        // issue is that the GetUserSelectedSavePath() is called twice which it doesn't need to be
                        string filepath = UiMethods.GetUserSelectedSavePath();
                        questions = Logic.LoadQuestionFromFile(filepath);
                        
                        Console.WriteLine($"Loaded {questions.Count} questions.");
                        foreach (var q in questions)
                        {
                            Console.WriteLine(q.ToString());
                        }


                    }

                    if (isBuildModeCompeleted && areTheQuestionsAndAnswersSaved)
                    {
                        break;
                    }
                    else

                        UiMethods.PrintMainMenuWOBuildingNewQuestions();
                    continue;
                }

                UiMethods.PrintWelcomeMessageForPlayMode(); // used this to have the User go back to first menu

                userInputSelect = UiMethods.GetValidOptionMode();

                //bottom method not needed 
                // bool isThereAListInPlace = Logic.CheckIfListIsNotEmpty(questions); // this is to check if the list is empty or not



                //bottom method not needed delete later
                // UiMethods.CreatingMultipleOrSingleCorrectAnswers(); // used to create multiple correct answers


                // create or look for a function that will answer for the question that are being displayed 
                // validate if the answers to the question are correct using if statements 
                // integrate whether 2 answwrs to the question are correct or not 
                // if the player answers above 70% of the game then they win if not they lose 

                // int userChoice = UiMethods.UserChoice(); //used to check if the entry is valid

                // if the user selects 1 enter game creation mode 


                // QuizQuestion questionManager = new QuizQuestion(); // creating an instance of the GuitarQuestion class

                // create the question
                // QuizQuestion question = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object



            }

            List<QuizQuestion> GetRandomListQuestions = new List<QuizQuestion>();

            if (userInputSelect == Constants.START_PLAY_MODE) // this will houses the play mode
            {
                //placed to check if user accidentally selected play mode without creating questions
                //UiMethods.CheckingForCreatedQuestionsList();

                UiMethods.WelcomeToPlayModeMessage(); // welcome message

                // will get a random question from the list
                GetRandomListQuestions = new List<QuizQuestion> { Logic.GetRandomQuestion(createdQsAndAs) };

                // this will loop through and display the questions and answers to the user
                UiMethods.GetAndDisplayUserCreatedQAndAs(GetRandomListQuestions);

                string UserSelection = UiMethods.GetUserInput();
                List<string> CorrectAnswer = GetRandomListQuestions[0].CorrectAnswers; // used GetRandomListQuestions w/ [0] to get the first question in the list

                bool gameOver = false;

                while (!gameOver)
                {
                    // display the questions here 
                    UiMethods.PlayGameMode(UserSelection, CorrectAnswer); // fix this later
                    if (GameVariable.PLAYER_SCORE >= GameVariable.WINNING_SCORE_THRESHOLD)
                    {
                        Console.WriteLine("Congratulations! You win!"); // testing purposes
                        gameOver = true;
                    }
                    else if (GameVariable.PLAYER_SCORE <= GameVariable.LOSING_SCORE_THRESHOLD)
                    {
                        Console.WriteLine("Game Over! Better luck next time."); // testing purposes 
                        gameOver = true;
                    }
                }
            }
        }
    }
}