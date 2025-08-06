using System.Globalization;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {

           char userInputSelect = Ui_Methods.SelectingGameOrCreateMode();

            if (userInputSelect == ConstantsVAR.START_PLAY_MODE) // this will house the Play Mode

            {
                Ui_Methods.PrintWelcomeMessage();
                QuizQuestion start = new GuitarQuestionsList().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object
               
                
                // QuizQuestion Question_2 = new GuitarQuestionsList().GetSampleQuestion_1();


                QuizQuestion.PrintOutSelectedNumberOfQuestions();
                Ui_Methods.GetCorrectAnswer(Ui_Methods.GetUserInput());
                //Ui_Methods.PrintGoodbyeMessage();

            }
            if (userInputSelect == ConstantsVAR.BUILD_QUIZ_MODE) // this will house the Create mode
            {
                //Console.WriteLine("you have selected ");

                Ui_Methods.CreateUserTypedQuestion();
                QuizQuestion.PrintOutSelectedNumberOfQuestions();
            }
            //_----____----_-______--_-______----------------  ---------__---__-_-_-_-------------_--_-_--__---------------__--__-_-___- 

            GuitarQuestionsList questionManager = new GuitarQuestionsList(); // creating an instance of the GuitarQuestion class

            // create the question
            QuizQuestion question = new GuitarQuestionsList().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

           
            
            //serialized question to Xml
            string filepath = @"D:\Random Drawings\Serialization Guitar.xml";
            questionManager.SaveQuestionToFile(question, filepath); // saving the question to a file
            Ui_Methods.DisplayingSavedToFile(); // displaying a message to the user that the question has been saved

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
