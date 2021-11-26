using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Model;

namespace Family_Assignment.Pages
{
    public partial class AddInterest : ComponentBase
    {
        [Parameter] public string StreetName { get; set; }
        [Parameter] public int HouseNumber { get; set; }
        [Parameter] public int IdOfChild { get; set; }

        private Interest interestToAdd;
        private Family family;

        protected override async Task OnInitializedAsync()
        {
            interestToAdd = new Interest();
            family = await fileReader.GetFamilyAsync(StreetName, HouseNumber);
        }

        private async Task AddNewInterest()
        {
            family.Children.Find(t => t.Id == IdOfChild).Interests.Add(interestToAdd);
            await fileReader.AddChildInterestAsync(interestToAdd.Id, interestToAdd);
            NavMgr.NavigateTo($"ChildView/{StreetName}/{HouseNumber}/{IdOfChild}");
        }
    }
}