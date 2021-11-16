using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class EditAdult : ComponentBase
    {
        [Parameter] public int Id { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToEdit;
        private Family familyToEdit;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                familyToEdit = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
                adultToEdit = familyToEdit.Adults.Find(t => t.Id == Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task Update()
        {
            Adult updateAdult = familyToEdit.Adults.Find(t => t.Id == adultToEdit.Id);
            updateAdult = adultToEdit;
            await fileReader.UpdateFamilyAsync(familyToEdit);
           
           

            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}