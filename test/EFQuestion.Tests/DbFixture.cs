using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EFQuestion;
using Microsoft.Data.Sqlite;

//using Microsoft.Data.Sqlite;
//using Microsoft.EntityFrameworkCore;

namespace EFQuestion.Tests
{
    public static class DbFixture
    {
        public static ParentChildDbContext InMemoryContext()
        {
            // SEE: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/sqlite
            var connection = new SqliteConnection("Data Source=:memory:");
            var options = new DbContextOptionsBuilder<ParentChildDbContext>()
                .UseSqlite(connection)
                .Options;
            connection.Open();
            // create the schema
            using (var context = new ParentChildDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            return new ParentChildDbContext(options);

        }
    }


}
