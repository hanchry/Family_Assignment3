using System;
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
        private Family family;
        private Job newJob;

        protected override async Task OnInitializedAsync()
        {
            // may have some bugs 
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            adultToView = family.Adults.Find(t => t.Id == Id);
            jobToView = adultToView.JobTittle;
            



        }

        private async Task AddJob()
        {
            jobToView = newJob;
            Family theFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            theFamily.Adults.Find(t => t.Id == Id).JobTittle = newJob;
            await jobController.AddJobAsync(adultToView.Id, newJob);
        }

        private async Task DeleteJob()
        {
            //may also have some bugs
            Family theFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            Job job = theFamily.Adults.Find(t => t.Id == Id).JobTittle = jobToView = new Job();
            await jobController.RemoveJobAsync(job.Id);
        }
    }
}