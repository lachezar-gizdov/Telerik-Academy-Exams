using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models.Enums;

namespace Academy.Models.Utils
{
    class CourseResult : ICourseResult
    {
        private ICourse course;
        private float coursePoints;
        private float examPoints;
        private Grade grade;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            this.Course = course;
            this.ExamPoints = examPoints;
            this.CoursePoints = coursePoints;
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                if (value < 1 || value > 125)
                {
                    throw new ArgumentException("Course result's course points should be between 0 and 125!");
                }
                this.coursePoints = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentException("Course result's exam points should be between 0 and 1000!");
                }
                this.examPoints = value;
            }
        } //DONE

        public Grade Grade
        {
            get
            {
                return CalculateGrade();
            }
            set
            {
                this.grade = value;
            }
        }

        private Grade CalculateGrade()
        {
            string grade = string.Empty;
            if (examPoints >= 65 || coursePoints >= 75)
            {
                return Grade.Excellent;
            }
            else if (examPoints >= 30 || coursePoints >= 45)
            {
                return Grade.Passed;
            }
            return Grade.Failed;
        }
    }
}
