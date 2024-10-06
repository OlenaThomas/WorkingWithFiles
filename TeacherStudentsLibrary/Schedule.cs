using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherStudentsLibrary
{
    public class Schedule
    {
        public int TeacherId { get; set; }
        public int Room { get; set; }
        public string Subject { get; set; }
        public int LessonNumber { get; set; }
        DayOfWeek Day { get; set; }
    }
}
