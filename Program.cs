using System.Globalization;

namespace ElectricGuitarQuiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            //_----____----_-______--_-______----------------  ---------__---__-_-_-_-------------_--_-_--__---------------__--__-_-___- 

            GuitarQuestionsList questionManager = new GuitarQuestionsList(); // creating an instance of the GuitarQuestion class

            // create the question
            QuizQuestion question = new GuitarQuestionsList().GetSampleQuestion(); // accessing the GuitarQuestions class to call the GetSampleQuestion method to create a question object

            //__-_----__--_____-_----_(Serialize and Deserialize)---_-_-_-_--_______-----__---_-_-_-_-_-________----___-\\
            
            
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
