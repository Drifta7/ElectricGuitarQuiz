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
          
            char userInputSelect = UiMethods.GetValidOptionMode();

            //used as a safty measure to ensure that if the user selects to view it will prompt a create message
            List<QuizQuestion> questions = null;

            string saveUserDirectoryPath = null; 

            //placed here to make this a global variable.
            List<QuizQuestion> createdQsAndAs = new List<QuizQuestion>();

            bool isBuildModeCompeleted = false;
            bool areTheQuestionsAndAnswersSaved = false;
            bool hasTheSavingOfquestionsHappend = false;

            if (userInputSelect == Constants.BUILD_QUIZ_MODE)
            {
                UiMethods.PrintMainMenu();

                while (!isBuildModeCompeleted)
                {
                    int userChoice = UiMethods.ValidateUserChoice();

                    bool didTheUserFinishedCreatingTheQsAndAs = false;

                    // Builds a new set of Questions.
                    if (userChoice == Constants.USER_SELECT_CHOICE_BUILD_GAME_MODE_1)
                    {
                        while (!didTheUserFinishedCreatingTheQsAndAs)
                        {
                            UiMethods.PrintWhatTheUserSelected(userChoice);
                            createdQsAndAs = UiMethods.PrintQuestionsAndAnswersForGame(); // saved to a var to be displayed later in the program

                            UiMethods.ClearingTheUserScreen();
                            didTheUserFinishedCreatingTheQsAndAs = true;
                        }
                    }

                    // view existing questions
                    if (userChoice == Constants.USER_SELECT_CHOICE_VIEW_QUESTIONS_2)
                    {
                        UiMethods.PrintWhatTheUserSelected(userChoice);
                       
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
                        UiMethods.PrintWhatTheUserSelected(userChoice);
                        
                        // placed here just in case if the user selects option as a safety measure 
                        if (!Logic.CheckIfListIsNotEmpty(createdQsAndAs))
                        {
                            UiMethods.NoListToDisplayMessage();
                            continue;
                        }
                        
                        saveUserDirectoryPath = UiMethods.GetUserSelectedSavePath();

                        // method made to save questions passed into the parameters to create an XML file
                        Logic.SaveQuestionToFile(createdQsAndAs, saveUserDirectoryPath);

                        // this is just a message informing the user that the questions have been saved.
                        UiMethods.DisplayingSavedFileMessage();
                        UiMethods.ClearingTheUserScreen();

                        hasTheSavingOfquestionsHappend = true;

                        UiMethods.PrintMainMenuWithoutOptions123();
                        areTheQuestionsAndAnswersSaved = true;
                    }

                    // used to deserialize the list from file
                    if (userChoice == Constants.USER_SELECT_CHOICE_4_DESERIALIZE)
                    {
                        UiMethods.PrintWhatTheUserSelected(userChoice);
                        questions = Logic.LoadQuestionFromFile(saveUserDirectoryPath);
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

            if (userInputSelect == Constants.START_PLAY_MODE) // this will houses the play mode
            {
                List<QuizQuestion> GetRandomListQuestions = new List<QuizQuestion>();
                
                // clears the screen
                UiMethods.ClearScreenAfterPlayModeSelected();
                UiMethods.WelcomeToPlayModeMessage(); // welcome message

                // will get a random question from the list that was saved to variable GetRandomListQuestions
                GetRandomListQuestions = new List<QuizQuestion> { Logic.GetRandomQuestion(createdQsAndAs) };

                // this is used to place the created list into a variable for the while loop condition count 
                List<QuizQuestion> availableQuestions = new List<QuizQuestion>(createdQsAndAs);

                bool gameOver = false;
                bool checkIfCorrect = false;

                while (!gameOver && availableQuestions.Count > Constants.VALUE_OF_ZERO)
                {
                    // randomizes the questions order and places it in a variable
                    QuizQuestion currentQuestion = Logic.GetRandomQuestion(availableQuestions);

                    // displays  the question(s) for the user to answer
                    UiMethods.GetAndDisplayUserCreatedQAndAs(new List<QuizQuestion> { currentQuestion });

                    string userSelection = UiMethods.GetUserInput();

                    // this checks the single answer from the user 
                    List<string> correctAnswer = currentQuestion.CorrectAnswers;
                   
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