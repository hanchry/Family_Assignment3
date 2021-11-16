using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Model;
using Syncfusion.Blazor;

namespace Family_Assignment.Pages
{
    public partial class Index : ComponentBase
    {
     //    public class Statistics
     //    {
     //        public string Browser { get; set; }
     //        public int  NoOfIndividuals { get; set; }
     //    }
     //    
     //    public List<Statistics> StatisticsDetails = new List<Statistics>
     //    {
     //        new Statistics { Browser = "Adults", NoOfIndividuals = 37 },
     //        new Statistics { Browser = "Children", NoOfIndividuals = 17 },
     //        new Statistics { Browser = "Pets", NoOfIndividuals = 19 },
     //        
     //    };
     //    private IList<Family> allFamilies;
     //    
     // //  public List<Statistics> StatisticsDetails;
     //    
     //    protected override async Task OnInitializedAsync()
     //    {
     //        allFamilies = await fileReader.GetAllFamiliesAsync();
     //
     //        StatisticsDetails[0].NoOfIndividuals = AdultCount();
     //        StatisticsDetails[1].NoOfIndividuals = ChildrenCount();
     //        StatisticsDetails[2].NoOfIndividuals = PetCount();
     //
     //
     //        // this.StatisticsDetails = new List<Statistics>
     //        // {
     //        //     new Statistics {Adults = "Adults", NoOfIndividuals = AdultCount()},
     //        //     new Statistics {Children = "Children", NoOfIndividuals = ChildrenCount()},
     //        //     new Statistics {Pets = "iPhone", NoOfIndividuals = PetCount()},
     //        // };
     //    }
     //    
     //    public int AdultCount()
     //    {
     //        int adultCount = 0;
     //        for (int i = 0; i < allFamilies.Count; i++)
     //        {
     //            var adultList = allFamilies[i].Adults;
     //            adultCount += adultList.Count;
     //        }
     //    
     //        return adultCount;
     //    }
     //    
     //    public int ChildrenCount()
     //    {
     //        int childCount = 0;
     //        for (int i = 0; i < allFamilies.Count; i++)
     //        {
     //            var childList = allFamilies[i].Children;
     //            childCount += childList.Count;
     //        }
     //    
     //        return childCount;
     //    }
     //    
     //    public int PetCount()
     //    {
     //        int petCount = 0;
     //        for (int i = 0; i < allFamilies.Count; i++)
     //        {
     //            var petlist = allFamilies[i].Pets;
     //            petCount += petlist.Count;
     //        }
     //    
     //        return petCount;
     //    }
    }
}