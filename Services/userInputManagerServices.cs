using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutSchedule.Class;
using workoutSchedule.Interfaces;

namespace workoutSchedule.SchedularClasses
{
    public class userInputManagerServices: IUserInputManager
    {
        // get user chosen level
       public int GetExerciseNumber(bool isBeginner ,int exerciseCount)
       {
            string workoutLevel = null;
            if (isBeginner)
                workoutLevel = "Beginner";
            else
                workoutLevel = "Advanced";

            Console.WriteLine($"you have selected {workoutLevel} level. ");

            Console.WriteLine($"Specify the number of exercises you want for your schedule.(1 to {exerciseCount})\n" +
                $"Note: atleast 1 exercise required. Default is 3 exercises if not specified. ");
            var exerciseNumber = Convert.ToInt32(Console.ReadLine());
            return exerciseNumber;
        }
        // get user chosen level
        public int GetUserWorkoutPreferance(int num)
        {                                    
            int exerciseNumber = num;            
            return exerciseNumber;
        }      

        public bool isBeginner()
        {            
            //get inputs from a user
            Console.WriteLine("Welcome to Chikondi gym center, please enter your name:");
            string fullName = Console.ReadLine();

            // handle situation where user has not specified the name
            if (fullName == "")
                fullName = "User";

            // choose workout level
            Console.WriteLine($"Hello {fullName}, this gym has got 2 workout levels:");
            Console.WriteLine("1. Beginner");
            Console.WriteLine("2. Advanced");
            Console.Write("Choose your preferred workout level: (1-2) ");

            int userLevel = Convert.ToInt32(Console.ReadLine());            
                if (userLevel.Equals(1))
                    return true;
                else if (userLevel.Equals(2))
                    return false;

            return false;
            
        }
    }
}
