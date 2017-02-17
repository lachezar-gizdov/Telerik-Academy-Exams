namespace Academy.Models
{
    using Academy.Models.Contracts;
    using System;
    using System.Collections.Generic;

    public class Trainer : ITrainer
    {
        private string userName;
        private IList<string> technologies;

        public Trainer(string userName, IList<string> technologies )
        {
            this.Username = userName;
            this.Technologies = technologies;
        }

        public IList<string> Technologies
        {
            get
            {
                return this.technologies;
            }

            set
            {
                this.technologies = value;
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
            string technologiesToString = string.Join("; ", technologies);
            Console.WriteLine("* Trainer:");
            Console.WriteLine(" - Username: {0}", this.userName);
            Console.WriteLine(" - Technologies: {0}", technologiesToString);
        }
    }
}
