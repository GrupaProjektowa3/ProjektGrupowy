using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Question Question { get; set; }
        [ForeignKey("Question")]
        public int? QuestionId { get; set; }
    }
}
