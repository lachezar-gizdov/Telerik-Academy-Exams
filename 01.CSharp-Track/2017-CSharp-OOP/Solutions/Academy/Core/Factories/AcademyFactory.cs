using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils;
using Academy.Models.Utils.Contracts;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {

        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            return new Student(username, track);

            //throw new NotImplementedException("Student class not attached to factory.");
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            List<string> list = technologies.Split(new char[] { ',' }).ToList();
            return new Trainer(username, list);

            //throw new NotImplementedException("Trainer class not attached to factory.");
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            int count = int.Parse(lecturesPerWeek);
            DateTime start = DateTime.ParseExact(startingDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            return new Course(name, count, start);

            //throw new NotImplementedException("Course class not attached to factory.");
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            DateTime start = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            return new Lecture(name, start, trainer);

            //throw new NotImplementedException("Lecture class not attached to factory.");
        }

        public ILectureResouce CreateLectureResouce(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            switch (type)
            {
                case "video": return new VideoResource(name, url);
                case "presentation": return new PresentationResource(name, url);
                case "demo": return new DemoResource(name, url);
                case "homework": return new HomeworkResource(name, url);
                default: throw new ArgumentException("Invalid lecture resource type");
            }

            //throw new NotImplementedException("LectureResouce classes not attached to factory.");
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            int exPoints = int.Parse(examPoints);
            int crPoints = int.Parse(coursePoints);
            return new CourseResult(course, exPoints, crPoints);

            //throw new NotImplementedException("CourseResult class not attached to factory.");
        }
    }
}
