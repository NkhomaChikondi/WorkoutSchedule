using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Xml.Linq;
using workoutSchedule.Class;
using workoutSchedule.SchedularClasses;

namespace workoutSchedule
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            // register dependencies
            var serviceProvider = new ServiceCollection().AddSingleton<IDataManager, DataManagerService>().BuildServiceProvider();

            // get file 
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            bool isBeginner = false;
            string workoutLevel = null;
            int exerciseNumber = 0;
            bool shouldRun = false;


            // get file from directory            
            string fullPath = "C:\\Users\\User\\Documents\\Angle Dimension\\Workout Schedule\\workoutSchedule\\Data\\workout_schedule_gym_exercises.csv";
            // check if file exist
            if (File.Exists(fullPath) )
            {
                // pass the data to a list of exercises
                List<Exercise> exercises = ExerciseSchedular.ReadData(fullPath);

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

                // the program will give the users 2 chances to enter correct number if incorrect one is inputed
                for (int i = 0; i < 2; i++)
                {
                    int userLevel = userInputManager.GetUserlevel(1,2);
                    if (userLevel.Equals(1))
                    {
                        workoutLevel = "Beginner";
                        isBeginner = true;
                        shouldRun = true;
                        break;
                       
                    }
                    else if (userLevel.Equals(2))
                    {
                        workoutLevel = "Advanced";
                        isBeginner = false;
                        shouldRun = true;
                        break;
                        
                    }
                    else
                    {
                        Console.WriteLine("Error: Level number is between 1 and 2");
                        shouldRun = false;                        
                    }                        
                }         
                if(shouldRun)
                {
                    Console.WriteLine($"you have selected {workoutLevel} level. ");

                    Console.WriteLine($"Enter/specify the number of exercises you want for your schedule.(1 to {exercises.Count()})\n" +
                        $"Note: atleast 1 exercise required. Default is 3 exercises if not specified. ");

                    // handle exceptions if the user hasnt specified any number
                    try
                    {
                        exerciseNumber = Convert.ToInt32(Console.ReadLine());
                                                
                    }
                    catch (Exception)
                    {
                        // enforce default rule
                        exerciseNumber = 3;
                    }


                    // call the GetUserWorkoutPreferance
                    int workoutExerciseNumber = userInputManager.GetUserWorkoutPreferance(exerciseNumber);

                    // call the generate  workout schedule method
                    ExerciseSchedular.GenerateWorkoutSchedule(exercises, isBeginner, workoutExerciseNumber);

                }
               
               

            }
            else
            { Console.WriteLine("Error: File not found"); }            
           
        }
        string getExercise()
        {

        }
    }
}
