using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorApp.Entities;

namespace TutorApp.Web.ViewModels
{
    public class TeacherSearchViewModel
    {
        public List<Teachers> Teacher { get; set; }
        public string Search { get; set; }
        public Pager Pager { get; internal set; }
    }

    public class NewTeacherViewModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public int TeachingSubjectID { get; set; }
        public int TeachingSubject2ID { get; set; }
        public int TeachingSubject3ID { get; set; }
        public int TeachingSubject4ID { get; set; }
        public int TeachingSubject5ID { get; set; }

        public List<CoursesField> TeachingSubjects { get; set; }
        public List<CoursesField> TeachingSubjects2 { get; set; }
        public List<CoursesField> TeachingSubjects3 { get; set; }
        public List<CoursesField> TeachingSubjects4 { get; set; }
        public List<CoursesField> TeachingSubjects5 { get; set; }

        public string LName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsTeacher { get; set; }
        public string Experience { get; set; }
        public string StudentType { get; set; }
        public string LessonLocation { get; set; }
        public string AvailableHours { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string UndergraduateCollage { get; set; }
        public string UndergraduateMajor { get; set; }
        public string GraduateCollage { get; set; }
        public string GraduateDegree { get; set; }
        public string GraduateCollage2 { get; set; }
        public string GraduateDegree2 { get; set; }

        public Decimal HoulryRate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Google { get; set; }

        public string Linkedin { get; set; }

        public string Rating { get; set; }

    }
}