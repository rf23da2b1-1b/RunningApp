using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;
using RunLib.repository;
using System.ComponentModel.DataAnnotations;

namespace RunningRazor.Pages.members
{
    public class CreateMemberModel : PageModel
    {

        private readonly IMemberEnumRepository _repo;

        public CreateMemberModel(IMemberEnumRepository repo)
        {
            _repo = repo;
        }

        /*
         * properties til view
         */
        [BindProperty]
        [Required(ErrorMessage ="Du skal indtaste et navn")]
        [StringLength(1000,MinimumLength =3,ErrorMessage ="Navnet skal være mindst 3 tegn")]
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


        public void OnGet()
        {
            Teams = Enum.GetValues<TeamColorType>().ToList();
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                Teams = Enum.GetValues<TeamColorType>().ToList();
                return Page();
            }

            MemberEnum member = new MemberEnum(NewName, NewMobile, NewTeam, NewPrice);
            _repo.Add(member);

            return RedirectToPage(nameof(Index));
        }
    }
}
