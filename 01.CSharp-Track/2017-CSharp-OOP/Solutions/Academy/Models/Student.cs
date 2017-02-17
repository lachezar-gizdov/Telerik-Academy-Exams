namespace Academy.Models
{
    using Academy.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using Academy.Models.Enums;
    using Academy.Models.Utils.Contracts;

    public class Student : IStudent
    {
        public IList<IStudent> Students { get; set; }
        private IList<ICourseResult> courseResults;
        private Track track;
        private string userName;

        public Student(string userName, string track)
        {
            this.Username = userName;
            //this.Track = track; FIX me
        }

        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }

            set
            {
                this.courseResults = value;
            }
        } //DONE

        public Track Track
        {
            get
            {
                return this.track;
            }

            set
            {
                if (Enum.IsDefined(typeof(Track), value))
                {
                    this.track = value;
                }
                throw new ArgumentException("The provided track is not valid!");
            }
        } //DONE

        public string Username
        {
            get
            {
                return this.userName;
            }

            set
            {
                if (value.Length < 3 || value.Length > 16)
                {
                    throw new ArgumentException("User's username should be between 3 and 16 symbols long!");
                }
                this.userName = value;
            }
        } //DONE

        public void Print()
        {
            Console.WriteLine("* Student:");
            Console.WriteLine(" - Username: {0}", this.userName);
            Console.WriteLine(" - Track: {0}", this.track);
            Console.WriteLine(" - Course results:");
            Console.WriteLine("  * User has no course results!");
        }
    }
}
