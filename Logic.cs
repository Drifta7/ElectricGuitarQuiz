using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    public class Logic
    {

       

        // create a random method that can pick up out a number between 1 and 7-8 and display it to the user 
        //then that number will be used to select a question from the list of questions.

        // might have to use a foreach loop to get the question to the user but that miight be in the UImethods file
       
        public static int QuestionRandomizer(int questionNumber)
        {// in order for this to work ther needs to be a saved var that stores a question number 
            Random random = new Random();
            questionNumber = random.Next(ConstantsVAR.RANGE_MIN, ConstantsVAR.RANGE_MAX); // this will pick a number between 1 and 8
            return questionNumber;
        }

        // will have to change this later into ui methods.cs file
        public static void UndersStandingList()
        {
            List<string> questionList = new List<string>()
            {
                "What is the name of the first electric guitar?",
                "Who invented the electric guitar?",
                "What is the most popular electric guitar brand?",
                "What is the difference between an electric and an acoustic guitar?",
                "What is the most expensive electric guitar ever sold?",
                "What is the most popular electric guitar model?",
                "What is the most popular electric guitar pickup type?"
            };
            // this will display the list of questions to the user
            foreach (var question in questionList)
            {
                Console.WriteLine(question);
            }

            // serialize this list and put it into a file on the hard drive 
        }
    }
}
