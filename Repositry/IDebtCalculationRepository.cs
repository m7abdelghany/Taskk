using Taskk.Models;

namespace Taskk.Repositry
{
    public interface IDebtCalculationRepository
    {
        List<DebtCalculation> getall();
        DebtCalculation getbyid(int id);
        DebtCalculation postdebt(DebtCalculation debtMangment);
        void delete(int Id);
    }
}
