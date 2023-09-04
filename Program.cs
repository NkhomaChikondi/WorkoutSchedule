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
using workoutSchedule.Interfaces;
using workoutSchedule.Services;

namespace workoutSchedule
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            string file = null;
            bool isBeginner = false;
            int exerciseNumber = 0;

            // register dependencies
            var serviceProvider = new ServiceCollection().AddSingleton<IDataManager, DataManagerServices>().BuildServiceProvider();
            var exerciseProvider = new ServiceCollection().AddSingleton<IExerciseSchedular, ExerciseSchedularServices>().BuildServiceProvider();
            var userInputProvider = new ServiceCollection().AddSingleton<IUserInputManager, userInputManagerServices>().BuildServiceProvider();

            // Resolve dependencies
            var dataServices = serviceProvider.GetRequiredService<IDataManager>();
            var exerciseServices = exerciseProvider.GetRequiredService<IExerciseSchedular>();
            var userinputServices = userInputProvider.GetRequiredService<IUserInputManager>();

            // get file 
            try
            {
                file = dataServices.getFile();
            }
            catch (Exception)
            {

                Console.WriteLine("Error: File does not exist");
                return;
            }

            // read the data
            var exerciseList = exerciseServices.ReadData(file);
            // get user level
            try
            {
                isBeginner = userinputServices.isBeginner();
            }
            catch (Exception)
            {
                Console.WriteLine("Error: No option was selected");
                return;
            }

            // get number of exercise
            try
            {
                exerciseNumber = userinputServices.GetExerciseNumber(isBeginner, exerciseList.Count());
            }
            catch (Exception)
            {

                exerciseNumber = 3;
            }
            // generate the schedule
            try
            {
                exerciseServices.GenerateWorkoutSchedule(exerciseList, isBeginner, exerciseNumber);
            }
            catch (Exception)
            {

                Console.WriteLine("Error: Failed to generate the schedule");
            }
        }

    
                
               
               

    }
}
