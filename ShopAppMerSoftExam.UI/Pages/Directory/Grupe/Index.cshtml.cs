using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Directory
{
    public class IndexModel : PageModel
    {
        private readonly IGrupeRepasitory _grupeRepasitory;
        public IndexModel(IGrupeRepasitory grupeRepasitory)

        {
            _grupeRepasitory = grupeRepasitory;
            InputList = new List<InputModel>();
        }


        public List<InputModel> InputList = new List<InputModel>();
        public List<Grup> GrupList { get; set; }
        public class InputModel : Grup { }


        protected void PrepareData()
        {
            var newsList = _grupeRepasitory.GetAll().ToList();

            

            InputList = newsList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Code = p.Code,
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
