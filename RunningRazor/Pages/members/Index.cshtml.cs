using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RunLib.model;
using RunLib.repository;

namespace RunningRazor.Pages.members
{
    public class IndexModel : PageModel
    {
        


        private readonly IMemberEnumRepository _repo;

        public IndexModel(IMemberEnumRepository repo)
        {
            _repo = repo;
        }


        /*
         * properties til view
         */
        public List<MemberEnum> Members{ get; set; }
        public List<TeamColorType> Teams { get; set; }
        public String IKKE_VALGT { get { return "Alle"; }  }


        [BindProperty]
        public string SearchStr { get; set; }
        [BindProperty]
        public String? ChoosenTeam { get; set; }



        public void OnGet()
        {
            Members = _repo.GetAll();
            Teams = Enum.GetValues<TeamColorType>().ToList();
        }

        public void OnPost()
        {
            SearchStr = (SearchStr is null) ? string.Empty : SearchStr.Trim();
            Members = _repo.GetAll().FindAll(m=>m.Name.Contains(SearchStr));

            if (ChoosenTeam is not null && ChoosenTeam != IKKE_VALGT)
            {
                Members = Members.FindAll(m => m.Team.ToString().Equals(ChoosenTeam));
            }
            Teams = Enum.GetValues<TeamColorType>().ToList();
        }




        public string ConvertColor(TeamColorType teamColor)
        {
            switch (teamColor)
            {
                case TeamColorType.sort: return "blackTeam";
                case TeamColorType.blå: return "blueTeam";
                case TeamColorType.grøn: return "greenTeam";
                case TeamColorType.gul: return "yellowTeam";
                case TeamColorType.orange: return "orangeTeam";
                case TeamColorType.rød: return "redTeam";
                default:return "blackTeam";                    
            }
        }
    }
}
