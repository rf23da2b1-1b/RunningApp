using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;
using RunLib.repository;

namespace RunningRazor.Pages.members
{
    public class DeleteMemberModel : PageModel
    {
        private readonly IMemberEnumRepository _repo;

        public DeleteMemberModel(IMemberEnumRepository repo)
        {
            _repo = repo;
        }

        /*
         * properties til view
         */
        public MemberEnum DeleteMember { get; set; }


        public IActionResult OnGet(int id)
        {
            try
            {
                DeleteMember = _repo.GetById(id);
                return Page();
            }
            catch 
            {
                // no id - dialog
                return RedirectToPage(nameof(Index));
            }
        }

        public IActionResult OnPost(int id)
        {

            _repo.Delete(id);


            return RedirectToPage(nameof(Index));
        }
    }
}
