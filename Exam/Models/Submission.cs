using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Submission
    {
        public int Id { get; set; }

        [Column("exam_id")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = null!;

        [Column("student_id")]
        public int StudentId { get; set; }
        public User Student { get; set; } = null!;

        [Column("submitted_at")]
        public DateTime SubmittedAt { get; set; } = DateTime.Now;

        [Column("total_score")]
        public float TotalScore { get; set; } = 0;

        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new List<SubmissionAnswer>();
    }
}
