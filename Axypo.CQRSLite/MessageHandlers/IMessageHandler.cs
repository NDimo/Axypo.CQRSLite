using System.Threading;
using System.Threading.Tasks;
using Axypo.CQRSLite.Messages;

namespace Axypo.CQRSLite.MessageHandlers
{
	public interface IMessageHandler<in TMessage, TResult> where TMessage : IMessage<TResult>
	{
		Task<TResult> HandleAsync(TMessage message, CancellationToken cancellationToken);
	}
}
