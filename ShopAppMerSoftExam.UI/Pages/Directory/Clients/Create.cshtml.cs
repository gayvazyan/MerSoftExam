using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Clients
{
    public class CreateModel : PageModel
    {
        private readonly IClientRepasitory _clientRepasitory;
        public CreateModel(IClientRepasitory clientRepasitory)
        {
            _clientRepasitory = clientRepasitory;
            Create = new CreateClientModel();
        }

        public class CreateClientModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Կոդը պարտադիր է")]
            public string Code { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Phone { get; set; }

            public decimal? Discount { get; set; }
        }

        [BindProperty]
        public CreateClientModel Create { get; set; }


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
                    var client = new Client
                    {
                        Code = Create.Code,
                        FirstName = Create.FirstName,
                        LastName = Create.LastName,
                        Phone = Create.Phone,
                        Discount = Create.Discount,

                    };

                    var result = _clientRepasitory.Insert(client);

                    if (result != null)
                        return RedirectToPage("/Directory/Clients/Index");

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
