using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace workoutSchedule.SchedularClasses
{
    public class userInputManager
    {
        // get user chosen level
       public static int GetUserlevel( int min, int max)
       {
            int level = 0;
            
                Console.Write("Choose your preferred workout level: (" + min + "-" + max + "): ");
                try
                {
                    int chosenLevel = Convert.ToInt32(Console.ReadLine());
                    
                      if(chosenLevel >= min && chosenLevel <= max)
                      
                        level = chosenLevel;
                        return level;
                      
                                    
                }
                catch (Exception)
                {

                    Console.WriteLine("Error: Invalid level number specified");
                    return -1;
                }               
           
       }
        // get user chosen level
        public static int GetUserWorkoutPreferance(int num)
        {                                    
            int exerciseNumber = num;            
            return exerciseNumber;
        }
    }
}
