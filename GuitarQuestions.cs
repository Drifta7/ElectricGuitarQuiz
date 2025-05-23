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
        public char Question1(char UserGuess)
        {
            Console.WriteLine( "What is the style the Guitar with arch-top?");
            
            Console.WriteLine($"B: {UserGuess}Gibson Les Paul");
            Console.WriteLine($"C: {UserGuess}Fender Stratocaster");
            Console.WriteLine($"D: {UserGuess}Gibson ES-335");
            Console.WriteLine($"E: {UserGuess}Fender JazzMaster");

            char correctAnswer = 'D';
            return correctAnswer;

        }


        public char Question2(char UserGuess)
        {
            Console.WriteLine("How many Pickups does a Fender startocaster have?");

            Console.WriteLine($"A: {UserGuess}2 Pickups");
            Console.WriteLine($"B: {UserGuess}3 Pickups");
            Console.WriteLine($"C: {UserGuess}4 Pickups");
            Console.WriteLine($"D: {UserGuess}5 Pickups");
             
            char correctAnswer = 'B';
            return correctAnswer;
        }
    }
}
