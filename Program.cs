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

            Logic.saveUserDirectoryPath = "";

            //placed here to make this a global variable.
            List<QuizQuestion> createdQsAndAs = new List<QuizQuestion>();

            bool isBuildModeCompeleted = false;
            bool areTheQuestionsAndAnswersSaved = false;
            bool hasDeserializeTakenPlace = false;
            bool hasTheSavingOfquestionsHappend = false;

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
                        // used so that the other menu doesn't trigger
                        // placed here just in case if the user selects option as a safety measure 
                        if (!Logic.CheckIfListIsNotEmpty(createdQsAndAs))
                        {
                            UiMethods.NoListToDisplayMessage();
                            continue;
                        }

                        Logic.saveUserDirectoryPath = UiMethods.GetUserSelectedSavePath();

                        // method made to save questions passed into the parameters to create an XML file
                        Logic.SaveQuestionToFile(createdQsAndAs, Logic.saveUserDirectoryPath);

                        // this is just a message informing the user that the questions have been saved.
                        UiMethods.DisplayingSavedFileMessage();

                        UiMethods.ClearingTheUserScreen();

                        hasTheSavingOfquestionsHappend = true;

                        UiMethods.PriniMainMenuWithoutOptions123();
                        areTheQuestionsAndAnswersSaved = true;

                    }

                    // used to deserialize the list from file
                    if (userChoice == Constants.USER_SELECT_CHOICE_4_DESERIALIZE)
                    {
                        questions = Logic.LoadQuestionFromFile(Logic.saveUserDirectoryPath);
                        UiMethods.QuestionsLoadedMessage();// generic message
                        isBuildModeCompeleted = true;
                    }

                    if (isBuildModeCompeleted && areTheQuestionsAndAnswersSaved)
                    {
                        break;
                    }
                    else if (!hasTheSavingOfquestionsHappend) // used so that the bool is tagged if the user hasn't saved yet.

                        UiMethods.PrintMainMenuWithBuildQuestCompleted(); // used to show that the first option of build mode is completed 
                    continue;
                }

                //used this to have the User go back to first menu w/ the build mode & play mode
                userInputSelect = UiMethods.GetValidSelectionWhileBuildModeIsCompleted();
            }

            List<QuizQuestion> GetRandomListQuestions = new List<QuizQuestion>();

            if (userInputSelect == Constants.START_PLAY_MODE) // this will houses the play mode
            {
                //placed to check if user accidentally selected play mode without creating questions
                //UiMethods.CheckingForCreatedQuestionsList();

                UiMethods.ClearScreenAfterPlayModeSelected();
                UiMethods.WelcomeToPlayModeMessage(); // welcome message

                // will get a random question from the list that was saved to variable GetRandomListQuestions
                GetRandomListQuestions = new List<QuizQuestion> { Logic.GetRandomQuestion(createdQsAndAs) };

                // displays the question(s) and answer(s) through a loop
                UiMethods.GetAndDisplayUserCreatedQAndAs(GetRandomListQuestions);

                // 1. here should be user input to answer the question
                
                // 2. here should check the answer if it's correct 
                
                List<QuizQuestion> availableQuestions = new List<QuizQuestion>(createdQsAndAs);

                bool gameOver = false;
                bool checkIfCorrect = false;

                while (!gameOver && availableQuestions.Count > Constants.VALUE_OF_ZERO)
                {
                    // randomizes the questions order and places it in a variable
                    QuizQuestion currentQuestion = Logic.GetRandomQuestion(availableQuestions); 

                    // displays  the question(s) for the user to answer
                    UiMethods.GetAndDisplayUserCreatedQAndAs(new List<QuizQuestion> { currentQuestion }); 
                    
                    //get the user input 
                    string userSelection = UiMethods.GetUserInput();

                    // this checks the single answer from the user 
                    List<string> correctAnswer = currentQuestion.CorrectAnswers; 
                    checkIfCorrect = UiMethods.CheckIfAnswerIsCorrect(userSelection, correctAnswer); // might have to delete this later

                    GameVariable.PLAYER_SCORE = UiMethods.ReturnPlayerScore(userSelection, correctAnswer); // used this for to check player score
                   
                    // removes the question once it has been asked  
                    availableQuestions.Remove(currentQuestion); 

                    //checks conditions for winning or losing the game
                    if (GameVariable.PLAYER_SCORE >= GameVariable.WINNING_SCORE_THRESHOLD)
                    {
                        Console.WriteLine("Congratulations! You win!");
                        gameOver = true;
                    }
                    else if (GameVariable.PLAYER_SCORE <= GameVariable.LOSING_SCORE_THRESHOLD)
                    {
                        Console.WriteLine("Game Over! Better luck next time.");
                        gameOver = true;
                    }
                }
            }
        }
    }
}