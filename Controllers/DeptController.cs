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
            var viewModel = new DebtMangmentModelView()
            { 
                DebtCalc = new List<DebtCalculationModelView> {new DebtCalculationModelView() },
            
        };
             
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SaveData([FromBody]DebtMangmentModelView obj)
        {
            
            if (obj != null)
            {
                DebtMangment debtman = new DebtMangment()
                {
                    DateNow = DateTime.Now,
                    TotalDebtValue = obj.TotalDebtValue,
                    Date = obj.Date,
                    PaidForWho = obj.PaidForWho,
                    TypeOfDept = obj.TypeOfDept,
                    TypeOfEvd = obj.TypeOfEvd,
                    Location = obj.Location,
                    NumberOfDebt = obj.NumberOfDebt,
                    AcountantName = obj.AcountantName
                };
                int ID = debtMangmentRepostirycs.postdebt(debtman);
                foreach (var item in obj.DebtCalc)
                {
                    DebtCalculation debtcalc = new DebtCalculation()
                    {
                        Cause = item.Cause,
                        Value = item.Value,
                        Notes = item.Notes,
                        DebtID = ID,
                        AccountName = item.AccountName
                    };
                    debtCalculationRepository.postdebt(debtcalc);
                }
                
            }
            return RedirectToAction("SaveData");
        }
        [HttpGet]
        public IActionResult GetAllData()
        {
          List<DebtMangment> debt =  debtMangmentRepostirycs.getall();
            List<DebtMangmentModelView> viewmodel = new List<DebtMangmentModelView>();
            foreach (var item in debt)
            {
                DebtMangmentModelView debtParent = new DebtMangmentModelView()
                {
                    DebtNumber= item.DebtNumber,
                    DateNow = DateTime.Now,
                    TotalDebtValue = item.TotalDebtValue,
                    Date = item.Date,
                    PaidForWho = item.PaidForWho,
                    TypeOfDept = item.TypeOfDept,
                    TypeOfEvd = item.TypeOfEvd,
                    Location = item.Location,
                    NumberOfDebt = item.NumberOfDebt,
                    AcountantName = item.AcountantName,
                    DebtCalc = new List<DebtCalculationModelView>()
                   
                };
                
                
                foreach (var item2 in item.DebtCalc)
                {
                    DebtCalculationModelView REadData = new DebtCalculationModelView()
                    {
                        DebtCalulationId = item2.DebtCalulationId ,
                        AccountName = item2.AccountName ,
                        Cause = item2.Cause ,
                        Value = item2.Value ,
                        Notes = item2.Notes
                    };
                    debtParent.DebtCalc.Add(REadData);
                    
                }
                viewmodel.Add(debtParent);
            }

            
            return View("ShowData",viewmodel);
        }
        public IActionResult DeleteParent(int Id)
        {
            debtMangmentRepostirycs.delete(Id);
            
            return RedirectToAction("GetAllData");
            

        }
        public IActionResult DeleteChild(int Id)
        {
            debtCalculationRepository.delete(Id);

            return RedirectToAction("GetAllData");


        }
    }
    
    
}
