using System.Threading;
using System.Threading.Tasks;

namespace Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface ICalc
    {
        decimal Calculate(string expr);

        Task<decimal> CalculateAsync(string expr, CancellationToken cancellationToken);
    }
}
