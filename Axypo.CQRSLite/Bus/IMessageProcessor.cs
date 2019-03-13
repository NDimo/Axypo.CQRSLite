using System.Threading;
using System.Threading.Tasks;
using Axypo.CQRSLite.Messages;

namespace Axypo.CQRSLite.Bus
{
	public interface IMessageProcessor
	{
		Task<TResult> ProcessAsync<TResult>(ICommand<TResult> message, CancellationToken cancellationToken);
		Task<TResult> ProcessAsync<TResult>(IQuery<TResult> message, CancellationToken cancellationToken);
	}
}
