using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Column("teacher_id")]

        public int TeacherId { get; set; }
        public User Teacher { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Column("created_at")]

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<ClassStudent> ClassStudents { get; set; } = new List<ClassStudent>();

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
         // map đúng tên cột MySQL
    }
}
