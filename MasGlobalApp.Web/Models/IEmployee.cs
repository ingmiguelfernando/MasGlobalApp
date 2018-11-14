namespace MasGlobalApp.Web.Models
{
    public interface IEmployee
    {
        int? Id { get; set; }
        string Name { get; set; }
        string ContractTypeName { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        double HourlySalary { get; set; }
        double MonthlySalary { get; set; }
        double AnnualSalary { get; set; }
    }
}
