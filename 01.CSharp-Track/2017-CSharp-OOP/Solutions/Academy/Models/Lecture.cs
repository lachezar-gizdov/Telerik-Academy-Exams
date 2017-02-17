namespace Academy.Models
{
    using Academy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Lecture : ILecture
    {
        private string name;
        private DateTime date;
        private IList<ILectureResouce> resouces;
        private ITrainer traner;

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
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
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        } //DONE

        public IList<ILectureResouce> Resouces
        {
            get
            {
                return this.resouces;
            }
            set
            {
                this.resouces = value;
            }
        } //DONE

        public ITrainer Trainer
        {
            get
            {
                return this.traner;
            }

            set
            {
                this.traner = value;
            }
        } //DONE

        public void Print()
        {
            Console.WriteLine(" * Lecture:");
            Console.WriteLine("   - Name: {0}", this.name);
            Console.WriteLine("   - Date: {0}", this.date);
            Console.WriteLine("   - Trainer username: {0}", this.traner);
            Console.WriteLine("   - Resources:");
            Console.WriteLine("    * There are no resources in this lecture.");
        }
    }
}
