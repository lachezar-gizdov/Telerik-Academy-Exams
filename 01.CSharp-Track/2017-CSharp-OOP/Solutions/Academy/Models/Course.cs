namespace Academy.Models
{
    using Academy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        private DateTime endingDate;
        private int lecturesPerWeek;
        private string name;
        private DateTime startingDate;
        private IList<ILecture> lectures;
        private IList<IStudent> onlineStudents;
        private IList<IStudent> onsiteStudents;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.endingDate = startingDate.AddDays(30);
        }

        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }

            set
            {
                this.endingDate = value;
            }
        } //DONE

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                this.lectures = value;
            }
        } //DONE

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }

            set
            {
                if (value < 1 || value > 7)
                {
                    throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
                }
                this.lecturesPerWeek = value;
            }
        } //DONE

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < 3 || value.Length > 45 )
                {
                    throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
                }
                this.name = value;
            }
        } //DONE

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
            set
            {
                this.onlineStudents = value;
            }
        } //DONE

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
            set
            {
                this.onsiteStudents = value;
            }
        } //DONE

        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }

            set
            {
                this.startingDate = value;
            }
        } // DONE

        public void PrintEmpty()
        {
            Console.WriteLine("* Course");
            Console.WriteLine(" - Name: {0}", this.name);
            Console.WriteLine(" - Lectures per week: {0}", this.lecturesPerWeek);
            Console.WriteLine(" - Starting date: {0}", this.startingDate);
            Console.WriteLine(" - Ending date: {0}", this.endingDate);
            Console.WriteLine(" - Lectures:");
            Console.WriteLine("  * There are no lectures in this course!");
        }
    }
}