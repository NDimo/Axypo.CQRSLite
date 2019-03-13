using Axypo.CQRSLite.Messages;

namespace Axypo.CQRSLite.MessageHandlers
{
	public interface ICommandHandler<in TCommand, TResult> : IMessageHandler<TCommand, TResult> where TCommand : ICommand<TResult>
	{

	}
}
