using Axypo.CQRSLite.Messages;

namespace Axypo.CQRSLite.MessageHandlers
{
	public interface IQueryHandler<in TQuery, TResult> : IMessageHandler<TQuery, TResult> where TQuery : IQuery<TResult>
	{

	}
}
