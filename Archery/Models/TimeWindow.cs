using Archery.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Archery.Models
{
    public class TimeWindow:BaseModel
    {
       
        [DataType(DataType.DateTime)]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndTime { get; set; }
    }
}