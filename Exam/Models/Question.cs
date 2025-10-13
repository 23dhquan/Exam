using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Column("exam_id")]
        public int ExamId { get; set; }
        public Exam Exam { get; set; } = null!;

        [Column("teacher_id")]
        public int TeacherId { get; set; }
        public User Teacher { get; set; } = null!;

        [Column("content")]
        public string? Content { get; set; }

        [Column("content_image")]
        public string? ContentImage { get; set; }

        [Column("option_a_text")]
        public string? OptionAText { get; set; }

        [Column("option_a_image")]
        public string? OptionAImage { get; set; }

        [Column("option_b_text")]
        public string? OptionBText { get; set; }

        [Column("option_b_image")]
        public string? OptionBImage { get; set; }

        [Column("option_c_text")]
        public string? OptionCText { get; set; }

        [Column("option_c_image")]
        public string? OptionCImage { get; set; }

        [Column("option_d_text")]
        public string? OptionDText { get; set; }

        [Column("option_d_image")]
        public string? OptionDImage { get; set; }

        [Column("correct_option")]
        public string CorrectOption { get; set; } = "A"; // Enum A/B/C/D

        [Column("score")]
        public float Score { get; set; } = 1;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new List<SubmissionAnswer>();
    }
}
