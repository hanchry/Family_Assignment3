using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family_Assignment.Data;
using Family_Assignment.Data.Implementation;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AddPet : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        [Parameter] public int IdOfChild { get; set; }

        private Pet petToAdd;
        private Family family;
        private IList<Pet> petsInFamily;
        private IList<Pet> petsInChild;

        protected override async Task OnInitializedAsync()
        {
            petToAdd = new Pet();
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            petsInFamily = family.Pets;
            if (IdOfChild > 0)
            {
                petsInChild = family.Children.Find(t => t.Id == IdOfChild).Pets;
            }
        }

        private async Task AddNewPetToChild()
        {
            family.Children.First(t => t.Id == IdOfChild).Pets.Add(petToAdd);
                await petController.AddChildPetAsync(IdOfChild, petToAdd);
                NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{IdOfChild}");
        }

        private async Task AddNewPetToFamily()
        {
            
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            family.Pets.Add(petToAdd);
            await petController.AddFamilyPetAsync(StreetName,HouseNumber,petToAdd);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
        
    }
}