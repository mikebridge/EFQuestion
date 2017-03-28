using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFQuestion
{
    public class QueryService
    {
        private readonly ParentChildDbContext _ctx;

        public QueryService(ParentChildDbContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<QueryResult> CreateQueryable(
            Expression<Func<Parent, bool>> parentExpression)
        {
            return _ctx.Parent
                .Where(parentExpression)
                .Select(s => new QueryResult
                    {
                        Name = s.Name
                    }
                );
        }

        public async Task<IEnumerable<QueryResult>> SearchWithInline()
        {
            Expression<Func<Parent, bool>> expr = parent => parent.Active &&
                                                            parent.Children.Any(
                                                                program => program.Name.StartsWith("U"));
            return await CreateQueryable(expr).ToListAsync();

        }


        public async Task<IEnumerable<QueryResult>> SearchWithExtracted()
        {
            Func<Child, bool> p = program => program.Name.StartsWith("U");
            Expression<Func<Parent, bool>> expr = parent => parent.Active
                                                            && parent.Children.Any(p);
            return await CreateQueryable(expr).ToListAsync();

        }
    }
}
