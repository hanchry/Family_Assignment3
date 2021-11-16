using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AdultView : ComponentBase
    {
        [Parameter] public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToView;
        private Job jobToView;
        private Job newJob;
        private Family family;

        protected override async Task OnInitializedAsync()
        {
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            adultToView = family.Adults.Find(t => t.Id == Id);
            newJob = new Job();
            jobToView = adultToView.JobTittle;
        }

        private async Task AddJob()
        {
            jobToView = newJob;
            Family theFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            theFamily.Adults.Find(t => t.Id == Id).JobTittle = newJob;
            await fileReader.UpdateFamilyAsync(theFamily);
        }

        private async Task DeleteJob()
        {
            Family theFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            theFamily.Adults.Find(t => t.Id == Id).JobTittle = jobToView = new Job();
            await fileReader.UpdateFamilyAsync(theFamily);
        }
    }
}