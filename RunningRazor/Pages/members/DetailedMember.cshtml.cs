using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;
using RunLib.repository;
using System.ComponentModel.DataAnnotations;

namespace RunningRazor.Pages.members
{
    public class DetailedMemberModel : PageModel
    {
        private readonly IMemberEnumRepository _repo;

        public DetailedMemberModel(IMemberEnumRepository repo)
        {
            _repo = repo;
        }

        /*
         * properties til view
         */
        public MemberEnum MemberData { get; set; }
        
        public bool IsEdit { get; set; }

        //
        //  Edit
        //
        [BindProperty]
        public int NewId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste et navn")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Navnet skal være mindst 3 tegn")]
        public string NewName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste et telefon nummer")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Mobil nummer skal være mellem 8-12 tegn")]
        public string NewMobile { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste en pris")]
        [Range(50, 2000, ErrorMessage = "Prisen skal være over 50,00 kr")]
        public double NewPrice { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste en farve på et team")]
        public TeamColorType NewTeam { get; set; }

        public List<TeamColorType> Teams { get; set; }



        public IActionResult OnGet(int id)
        {
            try
            {
                MemberData = _repo.GetById(id);
                IsEdit = false;
                Teams = Enum.GetValues<TeamColorType>().ToList();
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
            IsEdit = true;
            MemberData = _repo.GetById(id);
            NewId = MemberData.Id;
            NewName = MemberData.Name;
            NewMobile = MemberData.Mobile;
            NewTeam = MemberData.Team;
            NewPrice = MemberData.Price;
            Teams = Enum.GetValues<TeamColorType>().ToList();
            return Page();
        }

        public IActionResult OnPostOK(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MemberEnum updateMember = new MemberEnum(NewId, NewName, NewMobile, NewTeam, NewPrice);
            _repo.Update(id, updateMember);
            return RedirectToPage(nameof(Index));
        }
    }
}
