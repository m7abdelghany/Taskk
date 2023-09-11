using Taskk.Models;

namespace Taskk.Repositry
{
    public interface IDebtMangmentRepostirycs
    {
        List<DebtMangment> getall();
        DebtMangment getbyid(int id);
        int postdebt(DebtMangment debtMangment);
        void delete(int Id);
    }
}
