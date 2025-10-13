using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Column("class_id")]
        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        public User Teacher { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        [Column("start_time")]
        public DateTime? StartTime { get; set; }

        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        [Column("is_active")]
        public int is_active { get; set; }

        [Column("duration_minutes")]
        public int? Duration { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
