using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class EditChildren : ComponentBase
    {
        [Parameter] public int IdOfChild { set; get; }
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }

        private Child childToEdit;
        private Family familyToEdit;

        protected override async Task OnInitializedAsync()
        {
            familyToEdit = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
            childToEdit = familyToEdit.Children.Find(t => t.Id == IdOfChild);
        }

        private async Task Update()
        {
            Child update = familyToEdit.Children.Find(t => t.Id == IdOfChild);
            update = childToEdit;
            await fileReader.UpdateFamilyAsync(familyToEdit);
            NavMgr.NavigateTo($"FamilyView/{StreetName}/{HouseNumber}");
        }
    }
}