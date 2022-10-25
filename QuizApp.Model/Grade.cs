using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        [Required]
        [Range(1, 100)]
        public int GradeValue { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual LoggedInUser LoggedInUser { get; set; }
        [ForeignKey("LoggedInUser")]
        public int? LoggedInUserId { get; set; }

    }
}
