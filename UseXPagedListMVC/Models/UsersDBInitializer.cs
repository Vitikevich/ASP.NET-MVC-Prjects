using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UseXPagedListMVC.Utils;

namespace UseXPagedListMVC.Models
{
    public class UsersDBInitializer : DropCreateDatabaseAlways<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            context.Users.AddRange(UserPersonalDataGenerator.GenerateDataSet(972));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}