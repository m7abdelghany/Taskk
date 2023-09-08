using Microsoft.AspNetCore.Mvc;
using Taskk.Models;
using Taskk.modelview;
using Taskk.Repositry;

namespace Taskk.Controllers
{
    public class DeptController : Controller
    {
        private readonly IDebtCalculationRepository debtCalculationRepository;
        private readonly IDebtMangmentRepostirycs debtMangmentRepostirycs;
        public DeptController(IDebtCalculationRepository _debtCalculationRepository, IDebtMangmentRepostirycs _debtMangmentRepostirycs)
        {
            debtCalculationRepository = _debtCalculationRepository;
            debtMangmentRepostirycs = _debtMangmentRepostirycs;
        }

        [HttpGet]
        public IActionResult SaveData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveData(debtmodelView debt)
        {
            
            if (debt != null)
            {
                DebtMangment debtman = new DebtMangment()
                {
                    DateNow = DateTime.Now,
                    TotalDebtValue = debt.TotalDebtValue,
                    Date = debt.Date,
                    PaidForWho = debt.PaidForWho,
                    TypeOfDept = debt.TypeOfDept,
                    TypeOfEvd = debt.TypeOfEvd,
                    Location = debt.Location,
                    NumberOfDebt = debt.NumberOfDebt,
                    AcountantName = debt.AcountantName
                };
               int ID = debtMangmentRepostirycs.postdebt(debtman);
                DebtCalculation debtcalc = new DebtCalculation()
                {
                    Cause = debt.Cause,
                    Value = debt.Value,
                    Notes = debt.Notes,
                    DebtID = ID,
                    AccountName = debt.AccountName
                };
                debtCalculationRepository.postdebt(debtcalc);
            }
            return View("Index");
        }
    }
}
