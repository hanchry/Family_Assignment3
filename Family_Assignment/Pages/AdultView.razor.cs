using System;
using System.Threading.Tasks;
using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AdultView : ComponentBase
    {
        [Parameter] public int IdOfAdult { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToView;
        private Family family;
       // private Job jobToUpdate;

        protected override async Task OnInitializedAsync()
        {
           // jobToUpdate = new Job();
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            adultToView = family.Adults.Find(t => t.Id == IdOfAdult);
        }

        // private async Task AddJob()
        // {
        //     family.Adults.Find(t => t.Id == IdOfAdult).JobTittle = jobToUpdate;
        //     await jobController.AddJobAsync(adultToView.Id, jobToUpdate);
        // }

        private async Task DeleteJob()
        {
              Job job = family.Adults.Find(t => t.Id == IdOfAdult).JobTittle = adultToView.JobTittle = new Job();
            await jobController.RemoveJobAsync(job.Id);
        }
        public void NavigateToAddJob()
        {
            NavMgr.NavigateTo($"AddJob/{StreetName}/{HouseNumber}/{IdOfAdult}");
        }
        // For later use
        // public void ShowAddJob(int adultId)
        // {
        //     var parameters = new ModalParameters();
        //     parameters.Add(nameof(IdOfAdult), adultId);
        //     parameters.Add(nameof(StreetName), StreetName);
        //     parameters.Add(nameof(HouseNumber), HouseNumber);
        //     _modalService.Show<AddJob>("AddJob", parameters);
        //     
        // }
    }
}