using ABS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABS.Data
{
    public class SectionRepository
    {
        public IEnumerable<Section> Retreive()
        {
            using (var context = new ABS())
            {
                return context.Sections.ToList();
            }
        }
    }
}