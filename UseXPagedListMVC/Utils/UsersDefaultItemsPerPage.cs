using System.Collections.Generic;
using System.Web.Mvc;

namespace UseXPagedListMVC.Utils
{
    public class UsersDefaultItemsPerPage
    {
        public static int SelectedValue { get => 10; }
        public static int[] SelectionItems { get => new int[] { 10, 20, 35, 50, 75, 100 }; }

        public static SelectList ItemsPerPageList { get => new SelectList(SelectionItems, selectedValue: SelectedValue); }

        

}
}