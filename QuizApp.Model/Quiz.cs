using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<Grade> Grades { get; set; }
    }
}
