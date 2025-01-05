using System.Linq.Expressions;

namespace Application.Dtos
{
    public static class MyExtensions
    {

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> input,
            bool condition, Expression<Func<T, bool>> expression)
        {
            return condition ? input.Where(expression) : input;
        }
    }
}
