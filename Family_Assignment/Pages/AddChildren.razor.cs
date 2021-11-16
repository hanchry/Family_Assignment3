using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AddChildren : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Child childToAdd;
        private IList<Child> allChildren;

        protected override async Task OnInitializedAsync()
        {
            childToAdd = new Child();
            Family family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            allChildren = family.Children;
        }

        private async Task AddNewChild()
        {
            childToAdd.Interests = new List<Interest>();
            childToAdd.Pets = new List<Pet>();
            childToAdd.Id = GetNewId();
            Family forUpdate = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            forUpdate.Children.Add(childToAdd);
            await fileReader.UpdateFamilyAsync(forUpdate);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }

        private int GetNewId()
        {
            int result = allChildren.Count + 1;
            int check = 1;
            foreach (Child x in allChildren)
            {
                if (check == x.Id)
                {
                    check++;
                }
                else
                {
                    result = check;
                    check++;
                }
            }

            return result;
        }
    }
}