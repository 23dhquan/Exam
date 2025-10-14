using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Table("submission_answers")]
    public class SubmissionAnswer
    {
        public int Id { get; set; }

        [Column("submission_id")]
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; } = null!;

        [Column("question_id")]
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

        [Column("chosen_option")]
        public string? ChosenOption { get; set; } // "A","B","C","D"

        [Column("is_correct")]
        public bool IsCorrect { get; set; } = false;
    }
}
