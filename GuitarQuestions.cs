using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    class GuitarQuestions
    {
        // might have to change this all together soon
        public static char Question1(char UserGuess)
        {
           

            Console.WriteLine("What is the style the Guitar that has an arch-top?"); // perhaps make this a blank for spaceholder for a question 

            Console.WriteLine($"A: {UserGuess} Gibson Les Paul"); // make this a placeholder for a question perhaps( and for the rest of the other questions).
            Console.WriteLine($"B: {UserGuess} Fender Stratocaster");
            Console.WriteLine($"C: {UserGuess} Gibson ES-335");
            Console.WriteLine($"D: {UserGuess} Fender JazzMaster");
            Console.WriteLine($"E: {UserGuess} Gibson SG Standard");
            Console.WriteLine($"F: {UserGuess} Gretsch White Falcon");

            char correctAnswer = 'D'; // store this for XML serialization later.
            return correctAnswer;
        }

        public char UserCorrectAnswer = Question1(Ui_Methods.GetValidUserChoice()); // this will store the user answer or maybe serilize it later.

        

        //------will use this soon but want to test out one question first.

        //public char Question2(char UserGuess)
        //{
        //    Console.WriteLine("How many Pickups does a Fender startocaster have?");

        //    Console.WriteLine($"A: {UserGuess}2 Pickups");
        //    Console.WriteLine($"B: {UserGuess}3 Pickups");
        //    Console.WriteLine($"C: {UserGuess}4 Pickups");
        //    Console.WriteLine($"D: {UserGuess}5 Pickups");

        //    char correctAnswer = 'B';
        //    return correctAnswer;
        //}
    }
}
