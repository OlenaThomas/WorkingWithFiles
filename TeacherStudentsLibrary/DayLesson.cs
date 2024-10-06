using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherStudentsLibrary
{
    public struct DayLesson
    {
        public const int MAX_DAY_LESSONS_COUNT = 6;

        public int LessonNumber { get; set; }
        DayOfWeek Day { get; set; }

        public override int GetHashCode()
        {
            return ((int)Day * MAX_DAY_LESSONS_COUNT) + LessonNumber;
        }

        public override bool Equals(object obj)
        {
            DayLesson other = (DayLesson)obj;

            return (Day == other.Day) && (LessonNumber == other.LessonNumber);
        }
    }
}
