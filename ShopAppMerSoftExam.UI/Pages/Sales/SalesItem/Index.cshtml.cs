using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Sales.SalesItem
{
    public class IndexModel : PageModel
    {
        private readonly ISaleItemRepasitory _saleItemRepasitory;
        private readonly IProductRepasitory _productRepasitory;
        public IndexModel(ISaleItemRepasitory saleItemRepasitory,
                          IProductRepasitory productRepasitory)

        {
            _saleItemRepasitory = saleItemRepasitory;
            _productRepasitory = productRepasitory;
            InputList = new List<InputModel>();
            Products = new List<SelectListItem>();
        }

        public List<SelectListItem> Products { get; set; }

        [BindProperty]
        public int SaleId { get; set; }
        public List<InputModel> InputList = new List<InputModel>();
        public List<SaleItem> OrderItemList { get; set; }
        public class InputModel : SaleItem
        {
            public string ClientName { get; set; }
            public string ProductName { get; set; }
        }



        protected void PrepareData(int id)
        {
            var saleItemList = _saleItemRepasitory.GetAll().ToList();



            InputList = saleItemList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    SaleId = id,
                    ProductId = p.ProductId,
                    ProductName = GetProductName(p.ProductId),
                    Count = p.Count,
                    DiscountedPrice = p.DiscountedPrice,
                    SalePrice = p.SalePrice,
                    Price = p.Price,
                };
            }).ToList();
        }
        public void OnGet(int id)
        {
            SaleId = id;
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
