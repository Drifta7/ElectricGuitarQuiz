using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricGuitarQuiz
{
    public class ConstantsVAR
    {
        // these numbers will repsent the game choices like for The SelectionGamemode() method
        public const char USER_GAME_CHOICE1 = '1';
        public const char USER_OPTION_CHOICE2 = '2';
        public const char USER_SELECT_CHOICE3 = '3';
        public const char USER_GAME_CHOICE4 = '4';

        //these represent the in game multiple choice selections
        public const char USER_SELECTION_A = 'A';
        public const char USER_SELECTION_B = 'B';
        public const char USER_SELECTION_C = 'C';
        public const char USER_SELECTION_D = 'D';
        public const char USER_SELECTION_E = 'E';

        public const char BUILD_QUIZ_MODE = 'A'; // const for the Build Quiz mode 
        public const char START_PLAY_MODE = 'B'; // const for the mutiple choice 

        public const int RANGE_MIN = 1;
        public const int NUMBER_SELECTION_TWO = 2;
        public const int NUMBER_ELECTION_THREE = 3;
        public const int RANGE_MAX = 4;

        public const int GAMEOPTION_MIN = 1; // when selecting the choice for PrintGameMenu
        public const int GAMEOPTION_MAX = 4;// when selecting the choice for PrintGameMenu


        public const int USER_SELECT_CHOICE_1 = 1; // for the select game menu
        public const int USER_SELECT_CHOICE_2 = 2; // ""
        public const int USER_SELECT_CHOICE_3_SAVE = 3; // ""
        public const int USER_SELECT_CHOICE_4_DESERIALIZE = 4; //

        public const char USERSELECT_YES = 'Y'; // these are the user selections for the quiz game, like if they want to create a question or not
        public const char USERSELECT_NO = 'N'; // " " " "

       
    }
}
