using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Income.OrdersItem
{
    public class CreateModel : PageModel
    {
        private readonly IOrderItemRepasitory _orderItemRepasitory;
        private readonly IProductRepasitory _productRepasitory;
        public CreateModel(IOrderItemRepasitory orderItemRepasitory,
                           IProductRepasitory productRepasitory)
        {
            _orderItemRepasitory = orderItemRepasitory;
            _productRepasitory = productRepasitory;
            Create = new CreateOrderItemModel();
            Products = new List<SelectListItem>();
        }

        public List<SelectListItem> Products { get; set; }
        public class CreateOrderItemModel
        {
            public int Id { get; set; }

            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public int Count { get; set; }
            public int Price { get; set; }
            public int Overhead { get; set; }
            public int SalePrice { get; set; }
            public DateTime ValideDate { get; set; } = DateTime.Now;

        }
        [BindProperty]
        public int OrderId { get; set; }

        [BindProperty]
        public CreateOrderItemModel Create { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        public void OnGet(int id)
        {
            OrderId = id;
            var prodList = _productRepasitory.GetAll();

            foreach (var product in prodList)
            {
                var item = new SelectListItem()
                {
                    Text = product.Name,
                    Value = product.Id.ToString()
                };
                Products.Add(item);
            }
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var orderItem = new OrderItem
                    {
                        OrderId = OrderId,
                        ProductId = Create.ProductId,
                        Count = Create.Count,
                        Price = Create.Price,
                        Overhead = Create.Overhead,
                        SalePrice = Create.SalePrice,
                        ValideDate = Create.ValideDate,

                    };

                    var result = _orderItemRepasitory.Insert(orderItem);

                    if (result != null)
                        return Redirect("/Income/OrdersItem/Index/" + OrderId);

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                }
            }
            return Page();
        }
    }
}
