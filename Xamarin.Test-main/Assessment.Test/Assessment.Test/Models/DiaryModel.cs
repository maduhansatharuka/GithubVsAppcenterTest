using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Test.Models
{
    public class DiaryModel
    {
        public List<string> Images { get; set; }
        public bool IncludeInGallery { get; set; }
        public string Comments { get; set; }
        public DateTime DiaryDate { get; set; }
        public string Area { get; set; }
        public string TaskCategory { get; set; }
        public string Tags { get; set; }
        public bool LinkToExistingEvent { get; set; }
        public string EventName { get; set; }
    }
}
