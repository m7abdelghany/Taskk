using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taskk.Data;
using Taskk.Models;

namespace Taskk.Repositry
{
    
    public class DebtMangmentReporisty : IDebtMangmentRepostirycs
    {
        private readonly ApplicationDbContext Db ;
            public DebtMangmentReporisty(ApplicationDbContext _Db)
        {
            Db= _Db;
        }
        public List<DebtMangment> getall()
        {
            List<DebtMangment> debtMangments = Db.debtMangments.ToList();
            return debtMangments;
        }
        public DebtMangment getbyid(int id)
        {
            DebtMangment debtMangment = Db.debtMangments.FirstOrDefault(a=>a.DebtNumber== id);
            return debtMangment;
        }


        public int postdebt(DebtMangment debtMangment)
        {
            
            DebtMangment newdebtmangment = new DebtMangment()
            {
                
                DateNow= DateTime.Now,
                TotalDebtValue=debtMangment.TotalDebtValue,
                Date = debtMangment.Date,
                PaidForWho = debtMangment.PaidForWho ,
                TypeOfDept = debtMangment.TypeOfDept,
                TypeOfEvd = debtMangment.TypeOfEvd,
                Location= debtMangment.Location,
                NumberOfDebt = debtMangment.NumberOfDebt,
                AcountantName = debtMangment.AcountantName
            };
            Db.debtMangments.Add(newdebtmangment);
            Db.SaveChanges();
            
            return newdebtmangment.DebtNumber;
        }
        public void delete(DebtMangment debtMangment)
        {
            Db.debtMangments.Remove(debtMangment);
            Db.SaveChanges();
        }
    }
}
