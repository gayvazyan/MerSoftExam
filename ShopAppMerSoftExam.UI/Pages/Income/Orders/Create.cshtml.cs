using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Income.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrderRepasitory _orderRepasitory;
        public CreateModel(IOrderRepasitory orderRepasitory)
        {
            _orderRepasitory = orderRepasitory;
            Create = new CreateOrderModel();
        }

        public class CreateOrderModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Համարը պարտադիր է")]
            public string Number { get; set; }

            [Required(ErrorMessage = "Անվանումը պարտադիր է")]
            public string Name { get; set; }

        }

        [BindProperty]
        public CreateOrderModel Create { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var order = new Order
                    {
                        Number = Create.Number,
                        Name = Create.Name

                    };

                    var result = _orderRepasitory.Insert(order);

                    if (result != null)
                        return RedirectToPage("/Income/Orders/Index");

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
