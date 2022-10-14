using AzureWebappServiceSqlSample.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureWebappServiceSqlSample.Pages
{
    public class IndexModel : PageModel
    {

        public List<Employee>? Employees;
      

        public void OnGet()
        {
          EmployeeContext context = new EmployeeContext();
            Employees = context.GetEmployees();
        }
    }
}