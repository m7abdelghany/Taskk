using System.ComponentModel.DataAnnotations;

namespace Taskk.Models
{
    public class DebtMangment
    {
        [Key]
        public int DebtNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateNow { get; set; }
        public int TotalDebtValue { get; set; }
        public string PaidForWho { get; set; }
        public string TypeOfEvd { get; set; }
        public string Location { get; set; }
        public string TypeOfDept { get; set; }
        public int NumberOfDebt { get; set; }
        public string AcountantName { get; set; }

        public ICollection< DebtCalculation> DebtCalc { get; set; }
    }
}
