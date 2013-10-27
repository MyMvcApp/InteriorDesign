using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace InteriorDesign.Context
{
    public class InteriorDesignInitializer : DropCreateDatabaseIfModelChanges<InteriorDesignContext>
    {
        protected override void Seed(InteriorDesignContext context)
        {
            context.SaveChanges();
        }
    }
}
