using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutSchedule.Class;

namespace workoutSchedule.Interfaces
{
    public interface IExerciseSchedular
    {
        List<Exercise> ReadData(string filepath);
        void GenerateWorkoutSchedule(List<Exercise> exerciseList, bool isBeginner, int exerciseNumber);
    }
}
