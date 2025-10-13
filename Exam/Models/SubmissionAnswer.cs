using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class SubmissionAnswer
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; } = null!;
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        [Column("created_at")]
        public string? ChosenOption { get; set; } // "A","B","C","D"
        public bool IsCorrect { get; set; } = false;
    }
}
