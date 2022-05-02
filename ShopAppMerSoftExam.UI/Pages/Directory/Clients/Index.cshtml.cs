using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopAppMerSoftExam.Core;
using ShopAppMerSoftExam.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAppMerSoftExam.UI.Pages.Directory.Clients
{
    public class IndexModel : PageModel
    {
        private readonly IClientRepasitory _clientRepasitory;
        public IndexModel(IClientRepasitory clientRepasitory)

        {
            _clientRepasitory = clientRepasitory;
            InputList = new List<InputModel>();
        }


        public List<InputModel> InputList = new List<InputModel>();
        public List<Client> ClientList { get; set; }
        public class InputModel : Client { }


        protected void PrepareData()
        {
            var clientList = _clientRepasitory.GetAll().ToList();



            InputList = clientList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Code = p.Code,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Discount = p.Discount,
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
