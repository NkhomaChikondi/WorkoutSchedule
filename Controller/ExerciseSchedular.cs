using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutSchedule.Class;

namespace workoutSchedule.SchedularClasses
{
    public class ExerciseSchedular 
    {
        public static List<Exercise>ReadData(string filepath)
        {
            // create a list of exercises
            var list = new List<Exercise>();
            try
            {
                //text reader
                using (StreamReader reader = new StreamReader(filepath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] items = line.Split(',');
                        
                        // check if the length of the items are equal to 2
                        if(items.Length == 2)
                        {
                            string exerciseName = items[0];
                            string[] repsRange = items[1].Split('-');

                            if (repsRange.Length == 2 && int.TryParse(repsRange[0], out int minReps) && int.TryParse(repsRange[1], out int maxReps))
                            {
                                list.Add(new Exercise
                                {
                                    exerciseName = exerciseName,
                                    repMin = minReps,
                                    repMax = maxReps
                                });
                            }
                        }
                    }                  
                }               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public static void GenerateWorkoutSchedule(List<Exercise> exerciseList,bool isBeginner,int exerciseNumber)
        {
            int counter = 0;
            // check if number entered is valid
            if(exerciseNumber <= 0 || exerciseNumber > exerciseList.Count())
            {
                // give the user a chance to enter a valid number
                Console.WriteLine($"Error: make sure the specified number is between 1 and {exerciseList.Count()}, Enter a valid number");
                int newExerciseNumber = Convert.ToInt32(Console.ReadLine());
                if (newExerciseNumber <= 0 || newExerciseNumber > exerciseList.Count())
                {
                    Console.WriteLine("Error: Invalid number of exercise");
                    return;
                }
                else
                    exerciseNumber = newExerciseNumber;
            }
            // if it is valid
            else if (exerciseNumber > 0 && exerciseNumber <= exerciseList.Count())
            {
                // get the exercises
                List<Exercise> exercises = exerciseList;

                // create a new Random object 
                Random random = new Random();            
                // handle exceptions if it fails to generate workout schedule
                try
                {
                    Console.WriteLine(" YOUR WORKOUT SCHEDULE");
                    // display the table headers
                    Console.WriteLine("Exercise  \t  Reps");
                    Console.WriteLine("------------  -----------  ");
                    
                    // loop through the exercises 
                    foreach (var exercise in exercises)
                    {
                        counter++;
                        if (counter <= exerciseNumber)
                        {
                            // generate a random number from the reps range given
                            int randomNumber = random.Next(exercise.repMin, exercise.repMax);

                            // enforce the beginner rule
                            if (isBeginner)
                                randomNumber /= 2;

                            // display the generated schedule
                            Console.WriteLine($"{exercise.exerciseName}    \t{randomNumber}");
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Error: failed to generate your workout schedule");
                }
                
            }             

        }
    }
}
