using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AddAdult : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Adult adultToAdd;
        private IList<Adult> allAdults;

        protected override async Task OnInitializedAsync()
        {
            adultToAdd = new Adult();
            Family family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            allAdults = family.Adults;
        }

        private async Task AddNewAdult()
        {
            Family forUpdate = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            forUpdate.Adults.Add(adultToAdd);
            await fileReader.UpdateFamilyAsync(forUpdate);
            await adultController.AddAdultAsync(StreetName, HouseNumber, adultToAdd);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
        
    }
}