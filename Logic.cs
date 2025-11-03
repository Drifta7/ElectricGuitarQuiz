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


        public static  QuizQuestion GetRandomQuestion(List<QuizQuestion> questions)
        {
            Random random = new Random();
            int randomIndex = random.Next(questions.Count); // get a random index based on the number of questions available
            return questions[randomIndex]; // return the randomly selected question
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


        // used to pass in list of questions to check if null or empty "THIS IS MORE DYNAMIC"
        public static List<QuizQuestion> EnsureQuestionListExists(List<QuizQuestion> existingList)
        {
            if (existingList == null || existingList.Count == 0)
            {
                    
                Console.WriteLine("No questions and answers are available. Please create some them first.");
                existingList = UiMethods.PrintQuestionsAndAnswersForGame();
            }
            else
            {
                Console.WriteLine($"There are {existingList.Count} questions available.");
            } // 
            return existingList;
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
