using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual Quiz Quiz { get; set; }
        [ForeignKey("Quiz")]
        public int? QuizId { get; set; }

    }
}
