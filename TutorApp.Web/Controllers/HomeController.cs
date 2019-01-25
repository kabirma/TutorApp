using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorApp.Entities;
using TutorApp.Services;
using TutorApp.Web.ViewModels;
using System.Data.Entity;

namespace TutorApp.Web.Controllers
{
    public class HomeController : Controller
    {


        int items = 20;
        public ActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

            model.Courses = CourseServices.Instance.GetCourses().Where(courses => courses.IsFeatured).Distinct().Take(12).ToList();
            model.CourseFieldCount = CoursesFieldServices.Instance.GetCoursesFieldCount();
            model.Teachers = TeachersServices.Instance.GetTeachers().OrderBy(teacher => teacher.Rating).Take(10).ToList();
            model.FilesCount = FilesServices.Instance.GetFilesCount();
            model.VideoCount = VideosServices.Instance.GetVideosCount();
            model.StudentCount = StudentServices.Instance.GetStudentsCount();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.Job = JobsServices.Instance.GetJobs();
            return View(model);
        }

        public ActionResult About()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(Inbox inbox)
        {
            InboxServices.Instance.SaveInbox(inbox);
            ListViewModel model = new ListViewModel();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            return View(model);
        }

        public ActionResult Lesson()
        {
            ListViewModel model = new ListViewModel();
            model.Courses = CourseServices.Instance.GetCourses();
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            model.CourseFieldCount = CoursesFieldServices.Instance.GetCoursesFieldCount();
            model.CoursesCount = CourseServices.Instance.GetCoursesCount();
            model.FieldTopicCount = FieldTopicsServices.Instance.GetFieldTopicsCount();
            return View(model);
        }
        public ActionResult LessonFields(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.Courses = CourseServices.Instance.GetCourses();
            model.SingleCourseField = CoursesFieldServices.Instance.GetCourseField(ID);
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            model.CourseFieldCount = CoursesFieldServices.Instance.GetCoursesFieldCount();
            model.CoursesCount = CourseServices.Instance.GetCoursesCount();
            model.TopicField = FieldTopicsServices.Instance.GetFieldTopics();
            model.FieldTopicCount = FieldTopicsServices.Instance.GetFieldTopicsCount();
            model.TopicDetail = TopicDetailsServices.Instance.GetTopicDetails();
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField();
            return View(model);
        }

        public ActionResult LessonTopics(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.Courses = CourseServices.Instance.GetCourses();
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();
            model.CourseFieldCount = CoursesFieldServices.Instance.GetCoursesFieldCount();
            model.CoursesCount = CourseServices.Instance.GetCoursesCount();
            model.SingleTopicField = FieldTopicsServices.Instance.GetFieldTopic(ID);
            model.FieldTopicCount = FieldTopicsServices.Instance.GetFieldTopicsCount();
            model.TopicDetail = TopicDetailsServices.Instance.GetTopicDetails().Where(x=>x.Category.ID==ID).ToList();
            
            return View(model);
        }



        public ActionResult OfflineFiles()
        {
            ListViewModel model = new ListViewModel();
            model.Files = FilesServices.Instance.GetFiles();
            model.FileCategory = FileCategServices.Instance.GetFilesCategory();
            model.Teachers = TeachersServices.Instance.GetTeachers();
            model.FilesCount = FilesServices.Instance.GetFilesCount();

            return View(model);
        }
      
        public ActionResult _FileData(string Search, int? pageNo,string Category,string Writer,string timeperiod)
        {
            ListViewModel model = new ListViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            
            model.Files = FilesServices.Instance.GetFiles(Search, pageNo.Value, Category, Writer,timeperiod);
            model.FilesCount = FilesServices.Instance.GetFilesCount(Search, Category, Writer);
            if (model.Files != null)
            {
                model.Pager = new Pager(model.FilesCount, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }



        public ActionResult OnlineVideos()
        {
            ListViewModel model = new ListViewModel();
            model.Videos = VideosServices.Instance.GetVideos();
            model.VideoCategory = VideoCategServices.Instance.GetVideosCategory();
            model.Teachers = TeachersServices.Instance.GetTeachers();
            model.VideoCount = VideosServices.Instance.GetVideosCount();

            return View(model);
        }

        public ActionResult _VideoData(string Search, int? pageNo, string Writer, string Category, string timeperiod)
        {
            ListViewModel model = new ListViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.Videos = VideosServices.Instance.GetVideos(Search, pageNo.Value,  Writer, Category, timeperiod);
            model.VideoCount = VideosServices.Instance.GetVideosCount(Search,  Writer, Category);
            if (model.Videos != null)
            {
                model.Pager = new Pager(model.VideoCount, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult VideoDetails(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.Video = VideosServices.Instance.GetVideo(ID);
            model.Videos = VideosServices.Instance.GetVideos();
            model.Comments = VideoCommentServices.Instance.GetSelectedVideoComments(ID);
            model.CommentCount = VideoCommentServices.Instance.GetSelectedVideoComments(ID).Count();
            return View(model);
        }
        [HttpPost]
        public ActionResult VideoDetails(NewVideoCommentViewModel model)
        {
            var newVideoComment = new VideoComments
            {
                Name = model.Name,
                Comment = model.Comment,
                Date = model.Date,

                Video = VideosServices.Instance.GetVideo(model.VideosID),
            };

            VideoCommentServices.Instance.SaveVideoComments(newVideoComment);
            return RedirectToAction("VideoDetails",new { ID=model.VideosID});
        }

        public ActionResult AvailableTeacher()
        {
            ListViewModel model = new ListViewModel();
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount();
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField();
            model.Teachers = TeachersServices.Instance.GetTeachers();

            return View(model);
        }

        public ActionResult _TeacherData(string Search, int? pageNo,string subject, string timeperiod)
        {
            ListViewModel model = new ListViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.Teachers = TeachersServices.Instance.GetTeachers(Search, pageNo.Value,subject, timeperiod);
            model.TeacherCount = TeachersServices.Instance.GetTeachersCount(Search, subject);
            if (model.Teachers != null)
            {
                model.Pager = new Pager(model.TeacherCount, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult TeacherDetails(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.Teacher = TeachersServices.Instance.GetTeacher(ID);
            model.Courses = CourseServices.Instance.GetCourses();
            model.CourseField = CoursesFieldServices.Instance.GetCoursesField();
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            var teach = TeachersServices.Instance.GetTeachers().Where(x=>x.Email.Equals(username) || x.Name.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            var student=StudentServices.Instance.GetStudents().Where(x => x.Email.Equals(username) || x.Name.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            if (teach != null && student==null)
            {
                Session["teacher"] = username;
                Session["teacherpass"] = password;
                Session["teacherID"] = teach.ID;
                return RedirectToAction("TeacherProfile");
            }
            if(teach == null && student != null)
            {
                Session["student"] = username;
                Session["studentpass"] = password;
                Session["studentID"] = student.ID;
                return RedirectToAction("StudentProfile", new { ID = student.ID });
            }
            else { 
                return View();
            }
        }

        public ActionResult Accounttype()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Students student)
        {
            StudentServices.Instance.SaveStudents(student);
            return View();
        }

        [HttpGet]
        public ActionResult TeacherRegister()
        {
            var model = new ListViewModel
            {
                CourseField = CoursesFieldServices.Instance.GetCoursesField(),

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult TeacherRegister(NewTeacherViewModels model)
        {
            model.IsTeacher = Convert.ToBoolean(1);
            var newTeacher = new Teachers
            {
                Name = model.Name,
                LName = model.LName,
                Email = model.Email,
                Password = model.Password,

                IsTeacher = model.IsTeacher,
                Experience = model.Experience,
                StudentType = model.StudentType,
                LessonLocation = model.LessonLocation,
                AvailableHours = model.AvailableHours,

                Gender = model.Gender,
                DOB = model.DOB,
                UndergraduateCollage = model.UndergraduateCollage,
                UndergraduateMajor = model.UndergraduateMajor,
                GraduateCollage = model.GraduateCollage,
                GraduateDegree = model.GraduateDegree,
                GraduateCollage2 = model.GraduateCollage2,
                GraduateDegree2 = model.GraduateDegree2,
                HoulryRate = model.HoulryRate,

                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                State = model.State,
                Country = model.Country,

                ZipCode = model.ZipCode,
                Bio = model.Bio,
                Facebook = model.Facebook,
                Twitter = model.Twitter,
                Google = model.Google,
                Linkedin = model.Linkedin,
                ImageUrl = model.ImageUrl,

                TeachingSubjects = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubjectID),
                TeachingSubjects2 = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubject2ID),
                TeachingSubjects3 = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubject3ID),
                TeachingSubjects4 = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubject4ID),
                TeachingSubjects5 = CoursesFieldServices.Instance.GetCourseField(model.TeachingSubject5ID)

            };
            TeachersServices.Instance.SaveTeachers(newTeacher);
            return View();
        }

        [HttpGet]
        public ActionResult TeacherProfile()
        {
            if (Session["teacherID"] != null)
            {
                ListViewModel model = new ListViewModel();
                model.Teacher = TeachersServices.Instance.GetTeacher(Convert.ToInt32(Session["teacherID"]));
                model.Videos = VideosServices.Instance.GetVideos().Where(x => x.Writer.ID == (Convert.ToInt32(Session["teacherID"]))).OrderBy(x=>x.Date).ToList();
                model.Files=FilesServices.Instance.GetFiles().Where(x => x.Writer.ID == (Convert.ToInt32(Session["teacherID"]))).OrderBy(x => x.Date).ToList();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult StudentProfile()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TutoringJobs()
        {
            ListViewModel model = new ListViewModel();
            model.Courses = CourseServices.Instance.GetCourses();
            return View(model);
        }
        [HttpPost]
        public ActionResult TutoringJobs(NewJobViewModels model,string username,string password)
        {
            if (Session["student"] != null && username == null && password == null) {
                var check = StudentServices.Instance.GetStudents().Where(x => x.Email.Equals(Session["student"].ToString()) || x.Name.Equals(Session["student"].ToString()) && x.Password.Equals(Session["studentpass"].ToString())).FirstOrDefault();
                if (check != null)
                {
                    var newJob = new Jobs
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Date = model.Date,
                        Availability = model.Availability,
                        Location = model.Location,
                        LessonBegins = model.LessonBegins,
                        GradingLevel = model.GradingLevel,
                        Course = CourseServices.Instance.GetCourse(model.CourseID),
                        ZipCode = model.ZipCode,
                        City = model.City,
                        Student = StudentServices.Instance.GetStudent(check.ID)
                    };
                    JobsServices.Instance.SaveJobs(newJob);

                    return RedirectToAction("Messagepage", "Home", new { message = "Tutoring Request has been posted to our Teaching faculty." });
                }

                else
                {
                    return View();
                }
            }
            else {
                var check = StudentServices.Instance.GetStudents().Where(x => x.Email.Equals(username) || x.Name.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
                if (check != null)
                {
                    var newJob = new Jobs
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Date = model.Date,
                        Availability = model.Availability,
                        Location = model.Location,
                        LessonBegins = model.LessonBegins,
                        GradingLevel = model.GradingLevel,
                        Course = CourseServices.Instance.GetCourse(model.CourseID),
                        ZipCode = model.ZipCode,
                        City = model.City,
                        Student = StudentServices.Instance.GetStudent(check.ID)
                    };
                    JobsServices.Instance.SaveJobs(newJob);

                    return RedirectToAction("Messagepage", "Home", new { message = "Tutoring Request has been posted to our Teaching faculty." });
                }

                else
                {
                    return View();
                }
            }
            
        }

        public ActionResult TutoringJobsView()
        {
            ListViewModel model = new ListViewModel();
            model.Job = JobsServices.Instance.GetJobs();
            model.Student = StudentServices.Instance.GetStudents();
            model.Courses = CourseServices.Instance.GetCourses();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

            return View(model);
        }

        public ActionResult _JobsData(string Search, int? pageNo,  string Category, string timeperiod)
        {
            ListViewModel model = new ListViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.Job = JobsServices.Instance.GetJobs(Search, pageNo.Value, Category, timeperiod);
            model.JobsCount = JobsServices.Instance.GetJobsCount(Search, Category);
            if (model.Job != null)
            {
                model.Pager = new Pager(model.JobsCount, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult AboutTutoringJobs()
        {
            ListViewModel model = new ListViewModel();
            model.Job = JobsServices.Instance.GetJobs();
            return View(model);
        }

        [HttpGet]
        public ActionResult VideoUpload(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.VideoCategory = VideoCategServices.Instance.GetVideosCategory();
            model.Teacher = TeachersServices.Instance.GetTeacher(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult VideoUpload(NewVideoViewModels model)
        {

            var newVideo = new Videos
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                FilePath = model.FilePath,
                ImageUrl = model.ImageUrl,
                Likes = model.Likes,
                Category = VideoCategServices.Instance.GetVideoCateg(model.CategoryID),
                Writer = TeachersServices.Instance.GetTeacher(model.WriterID)
            };
            VideosServices.Instance.SaveVideos(newVideo);
            return RedirectToAction("TeacherProfile");
        }

        [HttpGet]
        public ActionResult FileUpload(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.FileCategory = FileCategServices.Instance.GetFilesCategory();
            model.Teacher = TeachersServices.Instance.GetTeacher(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult FileUpload(NewFileViewModels model)
        {

            var newFile = new Files
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                FilePath = model.FilePath,
                Category = FileCategServices.Instance.GetFileCateg(model.CategoryID),
                Writer = TeachersServices.Instance.GetTeacher(model.WriterID)
            };
            FilesServices.Instance.SaveFiles(newFile);
            return RedirectToAction("TeacherProfile");
        }

        [HttpGet]
        public ActionResult AskQuestion(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.SingleStudent = StudentServices.Instance.GetStudent(ID);
            model.Courses = CourseServices.Instance.GetCourses();
            model.Question = QuestionsServices.Instance.GetQuestions();
            return View(model);
        }
        [HttpPost]
        public ActionResult AskQuestion(NewQuestionViewModels model)
        {
            var newQuestion = new Questions
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                Subject = CourseServices.Instance.GetCourse(model.SubjectID),
                Askedby = StudentServices.Instance.GetStudent(model.StudentID)
            };
            QuestionsServices.Instance.SaveQuestions(newQuestion);
            return View();
        }


        public ActionResult QuestionView()
        {
            ListViewModel model = new ListViewModel();
            model.Question = QuestionsServices.Instance.GetQuestions();
            model.Student = StudentServices.Instance.GetStudents();
            model.Courses = CourseServices.Instance.GetCourses();
            model.CompanyDetail = CompanyDetailServices.Instance.GetCompanyDetails();

            return View(model);
        }

        public ActionResult _QuestionData(string Search, int? pageNo, string Category, string timeperiod)
        {
            ListViewModel model = new ListViewModel
            {
                Search = Search
            };
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.Question = QuestionsServices.Instance.GetQuestions(Search, pageNo.Value, Category, timeperiod);
            model.QuestionCount = QuestionsServices.Instance.GetQuestionsCount(Search, Category);
            if (model.Question != null)
            {
                model.Pager = new Pager(model.QuestionCount, pageNo, items);

                return PartialView(model);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult QuestionDetail(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.Question = QuestionsServices.Instance.GetQuestions();
            model.SingleQuestion = QuestionsServices.Instance.GetQuestion(ID);
            model.Answer = AnswersServices.Instance.GetAnswers().Where(x => x.Question.ID == ID).OrderBy(x=>x.Date).ToList();
            return View(model);
        }
        
        public ActionResult _AnswerSection(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.Answer = AnswersServices.Instance.GetAnswers().Where(x => x.Question.ID == ID).OrderBy(x => x.Date).ToList();
            model.SingleQuestion = QuestionsServices.Instance.GetQuestion(ID);

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult _AnswerQuestion(int ID)
        {
            ListViewModel model = new ListViewModel();
            model.SingleQuestion = QuestionsServices.Instance.GetQuestion(ID);
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult _AnswerQuestion(NewAnswerViewModels model)
        {
            var teach = TeachersServices.Instance.GetTeachers().Where(x => x.Email.Equals(Session["teacher"]) || x.Name.Equals(Session["teacher"]) && x.Password.Equals(Session["teacherpass"])).FirstOrDefault();
            var newAnswer = new Answers
            {
                Name = model.Name,
                Description = model.Description,
                Date = model.Date,
                Upvote = model.Upvote,
                Downvote = model.Downvote,
                AnsweredBy = TeachersServices.Instance.GetTeacher(teach.ID),
                Question = QuestionsServices.Instance.GetQuestion(model.QuestionID)
            };
            AnswersServices.Instance.SaveAnswers(newAnswer);
            return RedirectToAction("QuestionDetail",new { ID = model.QuestionID});
        }

        public ActionResult VoteChanging(int ID,string vote)
        {
            
            var Answer = AnswersServices.Instance.GetAnswerdispose(ID);

            Answer.Name = Answer.Name;
            Answer.Description = Answer.Description;

            Answer.Date = Answer.Date;
            if (vote == "up") {
                Answer.Upvote = (Convert.ToInt16(Answer.Upvote) + 1).ToString();
            }
            if(vote == "down") { Answer.Downvote = (Convert.ToInt16(Answer.Downvote) + 1).ToString(); }
            else { Answer.Upvote = Answer.Upvote;
                Answer.Downvote = Answer.Downvote;
            }

            Answer.AnsweredBy = Answer.AnsweredBy;
            Answer.Question = Answer.Question;


            AnswersServices.Instance.UpdateAnswer(Answer);
            return PartialView();
        }

        public ActionResult Messagepage(string message)
        {
            ListViewModel model = new ListViewModel();
            model.Message = message.ToString();
            return View(model);
        }
    }
}