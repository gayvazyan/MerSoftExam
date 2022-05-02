using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Income.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderRepasitory _orderRepasitory;
        public IndexModel(IOrderRepasitory orderRepasitory)

        {
            _orderRepasitory = orderRepasitory;
            InputList = new List<InputModel>();
        }


        public List<InputModel> InputList = new List<InputModel>();
        public List<Order> OrderList { get; set; }
        public class InputModel : Order { }


        protected void PrepareData()
        {
            var orderList = _orderRepasitory.GetAll().ToList();



            InputList = orderList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Number = p.Number,
                    Name = p.Name,
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
    }
}
