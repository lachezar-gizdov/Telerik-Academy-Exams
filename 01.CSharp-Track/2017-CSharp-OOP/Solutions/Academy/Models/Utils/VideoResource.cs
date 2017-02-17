using Academy.Core.Providers;
using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Utils
{
    class VideoResource : ILectureResouce
    {
        private string name;
        private string url;
        private DateTime uploadedOn;

        public VideoResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;

        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
                }
                this.name = value;
            }
        } //DONE

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (value.Length < 5 || value.Length > 150)
                {
                    throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
                }
                this.url = value;
            }
        } //DONE

        public DateTime UploadedOn
        {
            get
            {
                return this.uploadedOn;
            }
            set
            {
                this.uploadedOn = DateTimeProvider.Now;
            }
        } //DONE
    }
}
