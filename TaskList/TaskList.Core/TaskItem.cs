using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskList.Core
{
    public class TaskItem
    {

        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string Title { get; set; }

        [Required, Range(1, 500)]
        public int? Priority { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Completed { get; set; }

    }
}
