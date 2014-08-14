using hatfield.Data;
using hatfield.Models;
using hatfield.Util;
using hatfield.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace hatfield.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IDataProvider peopleDataProvider;
        private const string DATA_FILE_NAME = "people.txt";

        public PeopleController(IDataProvider dataProvider) 
        {
            peopleDataProvider = dataProvider;
        }

        public async Task<ActionResult> Index(string selectedName)
        {
            return View(await GetViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(PeopleViewModel peopleViewModel)
        {
            return View(await GetViewModel(peopleViewModel.SelectedName));
        }


        public async Task<PeopleViewModel> GetViewModel(string selectedName="Name")
        {
            var peopleDataFilePath = System.Web.HttpContext.Current.Server.MapPath(@"App_Data") + "\\" + DATA_FILE_NAME;
            var viewData = await peopleDataProvider.GetPeople(peopleDataFilePath);
            var peopleNames = PeopleModelMapper.MapToPeopleSelectItems(viewData);
            PeopleModel selectedPerson = !string.IsNullOrEmpty(selectedName) ?
                viewData.FirstOrDefault(d => d.Name.Trim().ToUpper() == selectedName.Trim().ToUpper())
                : new PeopleModel() { Name = string.Empty, BirthPlace = string.Empty, DateOfBirth = string.Empty, Height = string.Empty, Weight = string.Empty };
            selectedPerson.Age = !string.IsNullOrEmpty(selectedName) ? AgeCalculator.CalculateAge(selectedPerson.DateOfBirth) : 0;
            return new PeopleViewModel() { People = selectedPerson, PeopleNames = peopleNames, SelectedName = selectedName };
            
        }

    }
}
