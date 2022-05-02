using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Sales.Sales
{
    public class IndexModel : PageModel
    {
        private readonly ISaleRepasitory _saleRepasitory;
        private readonly IClientRepasitory _clientRepasitory;
        public IndexModel(ISaleRepasitory saleRepasitory,IClientRepasitory clientRepasitory)

        {
            _saleRepasitory = saleRepasitory;
            _clientRepasitory = clientRepasitory;
            InputList = new List<InputModel>();
        }


        public List<InputModel> InputList = new List<InputModel>();
        public List<Sale> OrderList { get; set; }
        public class InputModel : Sale
        {
            public string FullName { get; set; }
        }


        protected void PrepareData()
        {
            var saleList = _saleRepasitory.GetAll().ToList();



            InputList = saleList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    FullName = GetFullName(p.ClientId),
                    ChekNumber = p.ChekNumber,
                    ClientDiscounte = p.ClientDiscounte,
                };
            }).ToList();
        }
        public void OnGet()
        {
            PrepareData();
        }

        public ActionResult OnPost()
        {
            PrepareData();
            return Page();
        }

        private string GetFullName(int id)
        {
            return _clientRepasitory.GetByID(id).FirstName + " " + _clientRepasitory.GetByID(id).LastName;
        }
    }
}
