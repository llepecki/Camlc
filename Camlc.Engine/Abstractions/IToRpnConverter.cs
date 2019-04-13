using System.Threading;
using System.Threading.Tasks;

namespace Com.Lepecki.Playground.Camlc.Engine.Abstractions
{
    public interface IToRpnConverter
    {
        RpnExpr Convert(string expr);

        Task<RpnExpr> ConvertAsync(string expr, CancellationToken cancellationToken);
    }
}
