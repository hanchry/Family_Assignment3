﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging.Abstractions;
using Models;

namespace Family_Assignment.Pages
{
    public partial class FamilyView : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private IList<Adult> allAdults;
        private IList<Child> allChildren;
        private IList<Pet> allPets;
        private IList<Adult> toShowAdults;
        private IList<Child> toShowChildren;
        private IList<Pet> toShowPets;
        

        private string filterBy;

        private string? filterByIdArg;
        private string? filterByFirstNameArg;
        private string? filterByLastNameArg;
        private string? filterByAgeArg;
        

        public Family updateFamily;

        protected override async Task OnInitializedAsync()
        {
            updateFamily = fileReader.GetFamily(StreetName, HouseNumber);
            allAdults = fileReader.GetFamily(StreetName, HouseNumber).Adults;
            allChildren = fileReader.GetFamily(StreetName, HouseNumber).Children;
            allPets = fileReader.GetFamily(StreetName, HouseNumber).Pets;
            toShowAdults = allAdults;
            toShowChildren = allChildren;
            toShowPets = allPets;
        }
        
        public void FilterBy(ChangeEventArgs eventArgs)
        {
            filterBy = eventArgs.Value.ToString();
        }
        
        public void FilterArg(ChangeEventArgs eventArgs, String typeOfObject)
        {
            switch (filterBy)
            {
                case "Id":
                    filterByIdArg = eventArgs.Value.ToString();
                    break;
                case "FirstName":
                    filterByFirstNameArg = eventArgs.Value.ToString();
                    break;
                case "LastName":
                    filterByLastNameArg = eventArgs.Value.ToString();
                    break;
            }

            if (typeOfObject.Equals("Adult"))
            {
                ExecuteFilteringAdults();
            }
            else if (typeOfObject.Equals("Child"))
            {
                ExecuteFilteringChildren();
            }
            
        }

        public void ExecuteFilteringAdults()
        {
            switch (filterBy)
            {
                case "Id":
                    toShowAdults = allAdults.Where(t => t.Id.ToString().Contains(filterByIdArg.ToString())).ToList();
                    break;
                case "FirstName":
                    toShowAdults = allAdults.Where(t => t.FirstName.Contains(filterByFirstNameArg)).ToList();
                    break;
                case "LastName":
                    toShowAdults = allAdults.Where(t => t.LastName.Contains(filterByLastNameArg)).ToList();
                    break;
                
            }
        }
        public void ExecuteFilteringChildren()
        {
            switch (filterBy)
            {
                case "Id":
                    toShowChildren = allChildren.Where(t => t.Id.ToString().Contains(filterByIdArg.ToString())).ToList();
                    break;
                case "FirstName":
                    toShowChildren = allChildren.Where(t => t.FirstName.Contains(filterByFirstNameArg)).ToList();
                    break;
                case "LastName":
                    toShowChildren = allChildren.Where(t => t.LastName.Contains(filterByLastNameArg)).ToList();
                    break;
                
            }
        }
        

        private void DeleteAdult(int Id)
        {
            updateFamily.Adults.Remove(allAdults.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }

        private void DeleteChildren(int Id)
        {
            updateFamily.Children.Remove(allChildren.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }

        private void DeletePet(int Id)
        {
            updateFamily.Pets.Remove(allPets.First(t => t.Id == Id));
            fileReader.UpdateFamily(updateFamily);
        }

        private void NavigateToAddAdult()
        {
            NavMgr.NavigateTo($"AddAdult/{StreetName}/{HouseNumber}");
        }

        private void NavigateToAddChildren()
        {
            NavMgr.NavigateTo($"AddChildren/{StreetName}/{HouseNumber}");
        }

        private void NavigateToAddPet()
        {
            NavMgr.NavigateTo($"AddPet/{StreetName}/{HouseNumber}/{0}");
        }

        private void NavigateToAdultView(int id)
        {
            NavMgr.NavigateTo($"AdultView/{StreetName}/{HouseNumber}/{id}");
        }

        private void NavigateToChildView(int id)
        {
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{id}");
        }

        private void NavigateToEditAdult(int id)
        {
            NavMgr.NavigateTo($"EditAdult/{StreetName}/{HouseNumber}/{id}");
        }

        private void NavigateToEditChildren(int id)
        {
            NavMgr.NavigateTo($"EditChildren/{StreetName}/{HouseNumber}/{id}");
        }
    }
}