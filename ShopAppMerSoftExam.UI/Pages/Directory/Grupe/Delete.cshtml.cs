using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System;
using System.Collections.Generic;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Grupe
{
    public class DeleteModel : PageModel
    {
        private readonly IGrupeRepasitory _grupeRepasitory;
        public DeleteModel(IGrupeRepasitory grupeRepasitory)
        {
            _grupeRepasitory = grupeRepasitory;
            Delete = new DeleteGrupModel();
        }

        public class DeleteGrupModel : Grup { }

        [BindProperty]
        public DeleteGrupModel Delete { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        protected void PrepareData(int id)
        {
            var result = _grupeRepasitory.GetByID(id);

            if (result != null)
            {
                Delete.Code = result.Code;
                Delete.Name = result.Name;
            }
        }

        public void OnGet(int id)
        {
            PrepareData(id);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var grup = _grupeRepasitory.GetByID(Delete.Code);

                    _grupeRepasitory.Delete(grup);

                    return RedirectToPage("/Directory/Grupe/Index");

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Delete.Code);
                }
            }

            return Page();
        }
    }
}
