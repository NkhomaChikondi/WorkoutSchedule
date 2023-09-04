using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutSchedule.Interfaces;

namespace workoutSchedule.Services
{
    public class DataManagerServices : IDataManager
    {
        public string getFile()
        {
            // get file from directory            
            string fullPath = "C:\\Users\\User\\Documents\\AngleDimension\\Workout Schedule\\workoutSchedule\\Data\\workout_schedule_gym_exercises.csv";
            // check if file exist
            return fullPath;           
            
        }
    }
}
