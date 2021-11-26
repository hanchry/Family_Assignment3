using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging.Abstractions;
using Model;

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

        private string filterBy;

        private string? filterArgument;

        public Family updateFamily;

        protected override async Task OnInitializedAsync()
        {
            updateFamily = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            allAdults = updateFamily.Adults;
            allChildren = updateFamily.Children;
            allPets = updateFamily.Pets;
            toShowAdults = allAdults;
            toShowChildren = allChildren;
        }

        private void FilterBy(ChangeEventArgs eventArgs)
        {
            filterBy = eventArgs.Value.ToString();
        }

        private void FilterArg(ChangeEventArgs eventArgs, String typeOfObject)
        {
            filterArgument = eventArgs.Value.ToString();


            if (typeOfObject.Equals("Adult"))
            {
                ExecuteFilteringAdults();
            }
            else if (typeOfObject.Equals("Child"))
            {
                ExecuteFilteringChildren();
            }
        }

        private void ExecuteFilteringAdults()
        {
            switch (filterBy)
            {
                case "Id":
                    toShowAdults = allAdults.Where(t => t.Id.ToString().Contains(filterArgument)).ToList();
                    break;
                case "FirstName":
                    toShowAdults = allAdults.Where(t => t.FirstName.Contains(filterArgument)).ToList();
                    break;
                case "LastName":
                    toShowAdults = allAdults.Where(t => t.LastName.Contains(filterArgument)).ToList();
                    break;
            }
        }

        private void ExecuteFilteringChildren()
        {
            switch (filterBy)
            {
                case "Id":
                    toShowChildren = allChildren.Where(t => t.Id.ToString().Contains(filterArgument)).ToList();
                    break;
                case "FirstName":
                    toShowChildren = allChildren.Where(t => t.FirstName.Contains(filterArgument)).ToList();
                    break;
                case "LastName":
                    toShowChildren = allChildren.Where(t => t.LastName.Contains(filterArgument)).ToList();
                    break;
            }
        }


        private async Task DeleteAdult(int Id)
        {
            updateFamily.Adults.Remove(allAdults.First(t => t.Id == Id));
            await fileReader.RemoveAdultAsync(Id);
        }

        private async Task DeleteChildren(int Id)
        {
            updateFamily.Children.Remove(allChildren.First(t => t.Id == Id));
            await fileReader.RemoveChildAsync(Id);
        }

        private async Task DeletePet(int Id)
        {
            updateFamily.Pets.Remove(allPets.First(t => t.Id == Id));
            await fileReader.RemovePetAsync(Id);
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