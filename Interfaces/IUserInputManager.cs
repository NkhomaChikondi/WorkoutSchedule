using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutSchedule.Interfaces
{
    public interface IUserInputManager
    {
        int GetExerciseNumber(bool isBeginner, int exerciseCount);
        int GetUserWorkoutPreferance(int num);
        bool isBeginner();
    }
}
