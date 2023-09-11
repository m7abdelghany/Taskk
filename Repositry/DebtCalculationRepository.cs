using Microsoft.EntityFrameworkCore;
using Taskk.Data;
using Taskk.Models;

namespace Taskk.Repositry
{
    public class DebtCalculationRepository : IDebtCalculationRepository
    {
        private readonly ApplicationDbContext Db;
        public DebtCalculationRepository(ApplicationDbContext _Db)
        {
            Db = _Db;
        }
        public List<DebtCalculation> getall()
        {
            List<DebtCalculation> debtMangments = Db.debtCalculations.ToList();
            return debtMangments;
        }
        public DebtCalculation getbyid(int id)
        {
            DebtCalculation DebtCalculation = Db.debtCalculations.Include(a=>a.Mangments).FirstOrDefault(a => a.DebtID == id);
            return DebtCalculation;
        }


        public DebtCalculation postdebt(DebtCalculation DebtCalculation)
        {
            DebtCalculation newDebtCalculation = new DebtCalculation()
            {
               Cause = DebtCalculation.Cause ,
               Value= DebtCalculation.Value ,
               Notes= DebtCalculation.Notes ,
               DebtID = DebtCalculation.DebtID ,
               AccountName= DebtCalculation.AccountName 
            };
            Db.debtCalculations.Add(DebtCalculation);
            Db.SaveChanges();
            return newDebtCalculation;
        }
        public void delete(int Id)
        {
            DebtCalculation debtCalculation = Db.debtCalculations.Find(Id);
            Db.debtCalculations.Remove(debtCalculation);
            Db.SaveChanges();
        }
    }
}
