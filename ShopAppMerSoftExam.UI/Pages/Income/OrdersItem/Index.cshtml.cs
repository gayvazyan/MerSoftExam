using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Income.OrdersItem
{
    public class IndexModel : PageModel
    {
        private readonly IOrderItemRepasitory _orderItemRepasitory;
        private readonly IProductRepasitory _productRepasitory;
        public IndexModel(IOrderItemRepasitory orderItemRepasitory, IProductRepasitory productRepasitory)

        {
            _orderItemRepasitory = orderItemRepasitory;
            _productRepasitory = productRepasitory;
            InputList = new List<InputModel>();
            Products = new List<SelectListItem>();
        }

        public List<SelectListItem> Products { get; set; }
        [BindProperty]
        public int OrderId { get; set; }
        public List<InputModel> InputList = new List<InputModel>();
        public List<OrderItem> OrderItemList { get; set; }
        public class InputModel : OrderItem 
        {
            public int Sum { get; set; }
            public string ProductName { get; set; }
        }

        

        protected void PrepareData(int id)
        {
            var orderItemList = _orderItemRepasitory.GetAll().ToList();



            InputList = orderItemList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    OrderId = id,
                    ProductId = p.ProductId,
                    ProductName = GetProductName(p.ProductId),
                    Count = p.Count,    
                    Price = p.Price,
                    Sum = p.Count* p.Price,
                    Overhead = p.Overhead,
                    SalePrice  = p.SalePrice,
                    ValideDate = p.ValideDate,
                };
            }).ToList();
        }
        public void OnGet(int id)
        {
            OrderId = id;
            PrepareData(id);
        }

        public ActionResult OnPost()
        {
           // PrepareData();
            return Page();
        }

        private string GetProductName(int id)
        {
            return _productRepasitory.GetByID(id).Name;
        }
    }
}

