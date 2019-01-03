using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorApp.Web.Helper
{
    public static class URLHelper
    {
        /**************** ADMIN *****************/
        public static string Signin(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Admin",
                action = "Signin",
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Signout(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Admin",
                action = "Signout",
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }


        /**************** Shared *****************/
        public static string Imageuploader(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Shared",
                action = "UploadImage",
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string Fileuploader(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Shared",
                action = "UploadFile",
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string Videouploader(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Shared",
                action = "UploadVideo",
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }



        /********************* Account **********************/
        public static string AccountTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "_AccountTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateAccount(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditAccount(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteAccount(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /*********************** Courses ***************************/

        public static string CoursesTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Coursestable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateCourses(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditCourse(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteCourse(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /******************* Course Field **********************/

        public static string CourseFieldTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_CourseFieldTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateCourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditCourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteCourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /******************* Topic Field **********************/

        public static string FieldTopicsTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FieldTopics",
                action = "_FieldTopicTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateFieldTopics(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FieldTopics",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditFieldTopics(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FieldTopics",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteFieldTopics(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FieldTopics",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /******************* Topic Field **********************/

        public static string TopicDetailsTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "TopicDetails",
                action = "_TopicDetailTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateTopicDetails(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "TopicDetails",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditTopicDetails(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "TopicDetails",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteTopicDetails(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "TopicDetails",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /************************* Teachers ***********************/

        public static string TeachersTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Teachers",
                action = "_TeacherTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateTeachers(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Teachers",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditTeachers(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Teachers",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteTeachers(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Teachers",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /************************* Video Category ***********************/

        public static string VideoCategoryTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "VideoCategory",
                action = "_VideoCategtable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateVideoCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "VideoCategory",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditVideoCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "VideoCategory",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteVideoCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "VideoCategory",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }


        /************************* Student ***********************/

        public static string StudentTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Student",
                action = "_Studenttable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateStudent(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Student",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditStudent(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Student",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteStudent(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Student",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }


        /************************* FileCategory ***********************/

        public static string FileCategoryTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FileCategory",
                action = "_FileCategtable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateFileCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FileCategory",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditFileCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FileCategory",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteFileCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FileCategory",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /************************* Question ***********************/

        public static string QuestionTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Question",
                action = "_QuestionTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateQuestion(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Question",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditQuestion(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Question",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteQuestion(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Question",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /************************* Answer ***********************/

        public static string AnswerTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Answer",
                action = "_AnswerTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateAnswer(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Answer",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditAnswer(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Answer",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteAnswer(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Answer",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }



        /************************* File ***********************/

        public static string FileTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Files",
                action = "_FileTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateFile(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Files",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditFile(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Files",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteFile(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Files",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }



        /************************* Video ***********************/

        public static string VideoTable(this UrlHelper helper, string Search)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Video",
                action = "_VideoTable",
                Search = Search
            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string CreateVideo(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Video",
                action = "_Create",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string EditVideo(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Video",
                action = "_Edit",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string DeleteVideo(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Video",
                action = "_Delete",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        /****************************** INDEX *****************************/
        public static string Account(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Account",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string Answer(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Answer",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }

        public static string CourseField(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "CourseField",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string FieldTopics(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FieldTopics",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Courses(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Courses",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string FileCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "FileCategory",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Files(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Files",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Question(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Question",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Student(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Student",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Teacher(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Teachers",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string TopicDetails(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "TopicDetails",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string Video(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "Video",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
        public static string VideoCategory(this UrlHelper helper)
        {
            string routeURL = string.Empty;

            routeURL = helper.RouteUrl("Default", new
            {
                controller = "VideoCategory",
                action = "Index",

            });

            routeURL = HttpUtility.UrlDecode(routeURL, System.Text.Encoding.UTF8);

            return routeURL.ToLower();
        }
    }
}