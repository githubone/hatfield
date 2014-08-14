using hatfield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hatfield.Util
{
    public static class PeopleModelMapper
    {
        public static List<SelectListItem> MapToPeopleSelectItems(IEnumerable<PeopleModel> peopleModels)
        {
            List<SelectListItem> peopleSelectItems = new List<SelectListItem>();
            peopleModels.ToList().ForEach(p => peopleSelectItems.Add(new SelectListItem() { Text=p.Name, Value= p.Name }));
            return peopleSelectItems;
        }
    }
}