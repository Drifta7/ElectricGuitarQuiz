using System.Globalization;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
             
            if (userInputSelect == ConstantsVAR.BUILD_QUIZ_MODE) // this will houses the Create mode
            {
                bool hasTheUserQuit = false; // a Flag if the user has quit the game or not
                bool gameOver = false;
               
                // will fix this later
                while (!gameOver) 
                {
                        QuizQuestion.PrintOutSelectedNumberOfQuestions();
                        QuizQuestion.PrintOutSelectedNumberOfOptions();
                        UiMethods.PromptingUserToCreateMoreQuestions();
                    
                    if (hasTheUserQuit)
                    {
                        gameOver = true;
                    }
                }
            }
            

            QuizQuestion questionManager = new QuizQuestion(); // creating an instance of the GuitarQuestion class
            
            // create the question
            QuizQuestion question = new QuizQuestion().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

           
            //serialized question to Xml
            string filepath = @"D:\Random Drawings\Serialization Guitar.xml";
            questionManager.SaveQuestionToFile(question, filepath); // saving the question to a file
            UiMethods.DisplayingSavedToFile(); // displaying a message to the user that the question has been saved

            // derserialize the question from the file
            QuizQuestion loadedQuestion = questionManager.LoadQuestionFromFile(filepath); // loading the question from the file
            Console.WriteLine("\nLoaded Question:");
            Console.WriteLine("Question:" + loadedQuestion.Question);

            // prints out the list within the class QuizQuestion from SampleQuestion().cs (method)
            foreach (string option in question.Options)
            {
                Console.WriteLine(option);
            }
        }
    }
}
