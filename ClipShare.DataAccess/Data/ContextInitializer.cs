using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ClipShare.DataAccess.Data
{
    public static class ContextInitializer
    {
        public static void Initialize(Context context)
        {
            // Ensure the database is created. If it already exists, this will do nothing.
            // context.Database.EnsureCreated();

            if(context.Database.GetPendingMigrations().Count() > 0)
            {
                context.Database.Migrate();
            }
        }
    }
}
