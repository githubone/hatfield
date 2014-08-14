using hatfield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hatfield.ViewModels
{
    public class PeopleViewModel
    {
        public PeopleModel People { get; set; }

        public List<SelectListItem> PeopleNames { get; set; }

        public string SelectedName {get;set;}

    }
}