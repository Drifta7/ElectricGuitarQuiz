using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    class Logic
    {
        // create a random method that can pick up out a number between 1 and 7-8 and display it to the user 
        //then that number will be used to select a question from the list of questions.

        // might have to use a foreach loop to get the question to the user but that miight be in the UImethods file
       
        public static int QuestionRandomizer(int questionNumber)
        {// in order for this to work ther needs to be a saved var that stores a question number 
            Random random = new Random();
            questionNumber = random.Next(1, 8); // this will pick a number between 1 and 8
            return questionNumber;
        }
    }
}
