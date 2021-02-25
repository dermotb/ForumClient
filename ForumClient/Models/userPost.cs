using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class userPost
    {
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }

        [MinLength(1)]
        [MaxLength(25)]
        public string Subject { get; set; }
        [MinLength(1)]
        [MaxLength(100)]
        public string Message { get; set; }

        public override string ToString()
        {
            return String.Format("Time: {0} | ID: {1} | Subject: {2} | Message: {3}", TimeStamp.TimeOfDay, ID, Subject, Message);
        }

    }
}
