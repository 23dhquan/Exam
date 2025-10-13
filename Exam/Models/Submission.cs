using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = null!;
        public int StudentId { get; set; }
        public User Student { get; set; } = null!;
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        public float TotalScore { get; set; } = 0;
        [Column("created_at")]
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new List<SubmissionAnswer>();
    }
}
