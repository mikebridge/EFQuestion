using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EFQuestion.Tests
{
    public class QueryServiceTests
    {
        private readonly ParentChildDbContext _ctx;
        //private School _school;

        public QueryServiceTests()
        {
            _ctx = DbFixture.InMemoryContext();
            _ctx.Database.BeginTransaction();
           
            //_ctx.SaveChanges();
           
        }

        public void Dispose()
        {
            _ctx.Database.RollbackTransaction();
            _ctx.Dispose();
        }



        [Fact]
        public async Task It_Should_Return_Some_Data_Inline()
        {
            // Arrange
            var service = new QueryService(_ctx);

            // Act
            var searchResults = (await service.SearchWithInline()).ToList();

            // Assert
            Assert.NotNull(searchResults);

        }

        [Fact]
        public async Task It_Should_Return_Some_Data_Extracted()
        {
            // Arrange
            var service = new QueryService(_ctx);

            // Act
            var searchResults = (await service.SearchWithExtracted()).ToList();

            // Assert
            Assert.NotNull(searchResults);

        }

    }
}
