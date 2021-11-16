using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;
using Newtonsoft.Json;

namespace Family_Assignment.Pages
{
    public partial class FamilyList : ComponentBase
    {
        private IList<Family> allFamilies;
        private IList<Family> toShowFamilies;
        private Family familyToAdd;
        private bool ShowPopUpDialog;
        private string filterBy;
       

        private string? filterArgument;

        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        protected override async Task OnInitializedAsync()
        {   familyToAdd = new Family();
            allFamilies = await fileReader.GetAllFamiliesAsync();
            toShowFamilies = allFamilies;
        }

        private void NavigateToFamily(String StreetName, int HouseNumber)
        {
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private async Task DeleteFamily(string streetName, int houseNumber)
        {
            Family family =
                allFamilies.FirstOrDefault(t => t.StreetName.Equals(streetName) && t.HouseNumber == houseNumber);
            await fileReader.RemoveFamilyAsync(family);
            await OnInitializedAsync();
        }

        private async Task AddNewFamily()
        {
            await fileReader.AddFamilyAsync(familyToAdd);
                ShowPopUpDialog = false;
                await OnInitializedAsync();
        }
        private void FilterBy(ChangeEventArgs eventArgs)
        {
            filterBy = eventArgs.Value.ToString();
        }
        
        private void FilterArg(ChangeEventArgs eventArgs, String typeOfObject)
        {
            filterArgument = eventArgs.Value.ToString();
            

            if (typeOfObject.Equals("Family"))
            {
                ExecuteFilteringFamilies();
            }
            
        }
        private void ExecuteFilteringFamilies()
        {
            switch (filterBy)
            {
                case "StreetName":
                    toShowFamilies =  allFamilies.Where(t => t.StreetName.Contains(filterArgument)).ToList();
                    break;
                case "HouseNumber":
                    toShowFamilies = allFamilies.Where(t => t.HouseNumber.ToString().Contains(filterArgument)).ToList();
                    break;
                
            }
        }
    }
}