using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UseXPagedListMVC.Utils
{
    public class DefaultValuesForPaging
    {
        public static SelectList ItemsPerPageList
        {
            get
            {
                return (new SelectList(new int[] { 10, 20, 35, 50, 75, 100 }, selectedValue: 10));
            }
        }
    }
}