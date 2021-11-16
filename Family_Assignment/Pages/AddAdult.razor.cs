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
                adultToAdd.JobTittle = new Job();
                adultToAdd.Id = GetNewId();
                Family forUpdate = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
                forUpdate.Adults.Add(adultToAdd);
                await fileReader.UpdateFamilyAsync(forUpdate);
                NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
                
        }

        private int GetNewId()
        {
            int result = allAdults.Count + 1;
            int check = 1;
            foreach (Adult x in allAdults)
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