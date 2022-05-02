using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Sales.Sales
{
    public class CreateModel : PageModel
    {
        private readonly ISaleRepasitory _saleRepasitory;
        private readonly IClientRepasitory _clientRepasitory;
      
        public CreateModel(ISaleRepasitory saleRepasitory, IClientRepasitory clientRepasitory)
        {
            _saleRepasitory = saleRepasitory;
            _clientRepasitory = clientRepasitory;
            Create = new CreateOrderModel();
           Clients = new List<SelectListItem>();
        }

        public List<SelectListItem> Clients { get; set; }

        public class CreateOrderModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Համարը պարտադիր է")]
            public string ChekNumber { get; set; }

            public int ClientId { get; set; }

            public DateTime ValideDate { get; set; }

            public int ClientDiscounte { get; set; }

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
            var clientList = _clientRepasitory.GetAll();

            foreach (var client in clientList)
            {
                var item = new SelectListItem()
                {
                    Text = client.FirstName + " " + client.LastName,
                    Value = client.Id.ToString()
                };
                Clients.Add(item);
            }
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var sale = new Sale
                    {
                        ChekNumber = Create.ChekNumber,
                        ClientDiscounte = Create.ClientDiscounte,
                        ValideDate = Create.ValideDate,
                        ClientId = Create.ClientId,

                    };

                    var result = _saleRepasitory.Insert(sale);

                    if (result != null)
                        return RedirectToPage("/Sales/Sales/Index");

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
