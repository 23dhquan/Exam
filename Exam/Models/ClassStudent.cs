using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    [Table("class_students")]  // ánh xạ đúng tên bảng trong MySQL
    public class ClassStudent
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("class_id")]
        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;

        [Column("student_id")]
        public int StudentId { get; set; }
        public User Student { get; set; } = null!;

        [Column("created_at")]
        public DateTime JoinedAt { get; set; } = DateTime.Now;
    }
}
