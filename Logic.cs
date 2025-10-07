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

        public static bool IsTheAnswerCorrect(char userInput, char correctAnswer)
        {
            if (userInput == correctAnswer)
            {
                return true; // the answer is correct
            }
            else
            {
                return false; // the answer is incorrect
            }
        }

        public static void SavingQuestionsToFile()
        {
            List<QuizQuestion> questions = QuizQuestion.PrintOutSelectedNumberOfOptions();
            QuizQuestion quizQuestionInstance = new QuizQuestion();
            quizQuestionInstance.SaveQuestionToFile(questions[0], @"D:\Random Drawings\Serialization Guitar.xml");
        }

        public static void ValidatingCreatedQuestionList()
        {
            List<QuizQuestion> questions = QuizQuestion.PrintOutSelectedNumberOfOptions();
            if (questions == null || questions.Count == 0)
            {
                Console.WriteLine("No questions available. Please create some questions first.");
            }
            else
            {
                Console.WriteLine($"There are {questions.Count} questions available.");
            } //  dont use this method yet 
        }

        //public static bool AreBothAnswersCorrect(char ans1, char ans2) // this is for if one or more answers are correct. this will be corrected afterwards
        //{
        //    Console.WriteLine("Would you like for there to be 2 correct answers in the Question Y/N?");

        //    char userInput = char.ToUpper(Console.ReadKey().KeyChar); // get the user input and make it uppercase

        //    if (userInput == ConstantsVAR.USERSELECT_YES)
        //    {
        //        Console.WriteLine("Please Enter the 1st of two correct answers");
        //        ans1 = char.ToUpper(Console.ReadKey().KeyChar);

        //        Console.WriteLine("Enter the 2nd of 2 correct answers");
        //        ans2 = char.ToUpper(Console.ReadKey().KeyChar);

        //        Console.WriteLine("Please confirm the two correct answers for the question (e.g., A ,B C, etc.):");
                
        //        Console.WriteLine("\nPlace in the 1st answer");
        //        char firstAnswer = char.ToUpper(Console.ReadKey().KeyChar);
                
        //        Console.WriteLine("\n Place in the 2nd answer");
        //        char secondAnswer = char.ToUpper(Console.ReadKey().KeyChar);

        //        if (ans1 == firstAnswer && ans2 == secondAnswer)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //        Console.WriteLine("Please Continue with creating the Questions");
        //    return false; // if the user does not want to have two correct answers, then return false
        //}
    }
}
