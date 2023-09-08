using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Taskk.Models
{
    public class DebtCalculation
    {
        [Key]
        public int DebtCalulationId { get; set; }
        public string Cause { get; set; }
        public int Value { get; set; }
        public string Notes { get; set; }
        public int DebtID { get; set; }
        public string AccountName { get; set; }
       public DebtMangment Mangments { get; set; }
    }
}
