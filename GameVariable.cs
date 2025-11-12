using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    public class GameVariable
    {
        public static int PLAYER_SCORE = 10;
        public static int POINTS_PER_CORRECT_ANSWER = 1; // points awarded per correct answer
        public static int POINTS_DEDUCTED_PER_WRONG_ANSWER = -1; // points deducted per wrong answer

        public static int WINNING_SCORE_THRESHOLD = 12; // score needed to win
        public static int LOSING_SCORE_THRESHOLD = 0; // score at which the game is over
    }
}
// dispay the question and answers in play mode
// have a method MATCH the UserAnswer to The CorrectANswer then if correctadd points else deduct points
// update the PLAYER_SCORE variable accordingly
// at the end of the quiz display the final score

// Give the option to display the Random Question from the quiz
// give the option to play again or exit the game