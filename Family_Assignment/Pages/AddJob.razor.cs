using System.Threading.Tasks;
using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AddJob : ComponentBase
    {
        [Parameter] public int IdOfAdult { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        
       // [CascadingParameter] private BlazoredModalInstance ModalInstance { get; set; }

        private Job jobToUpdate;
        private Family family;

        protected override async Task OnInitializedAsync()
        {
            jobToUpdate = new Job();
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
           // IdOfAdult = jobController.Load(IdOfAdult);
        }

        private async Task AddJobAsync()
        {
            family.Adults.Find(t => t.Id == IdOfAdult).JobTittle = jobToUpdate;
            await jobController.AddJobAsync(IdOfAdult, jobToUpdate);
            NavMgr.NavigateTo($"AdultView/{StreetName}/{HouseNumber}/{IdOfAdult}");
        }
    }
}