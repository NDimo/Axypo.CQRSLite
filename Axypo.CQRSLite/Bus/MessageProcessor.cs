using System;
using System.Threading;
using System.Threading.Tasks;
using Axypo.CQRSLite.MessageHandlers;
using Axypo.CQRSLite.Messages;

namespace Axypo.CQRSLite.Bus
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IServiceProvider serviceProvider;

        public MessageProcessor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        private async Task<TResult> ProcessAsync<TResult>(IMessage<TResult> message, Type messageHandlerType, CancellationToken cancellationToken)
        {
            var handlerType = messageHandlerType.MakeGenericType(message.GetType(), typeof(TResult));

            dynamic handler = this.serviceProvider.GetService(handlerType);

            return await handler.HandleAsync((dynamic)message, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TResult> ProcessAsync<TResult>(ICommand<TResult> message, CancellationToken cancellationToken)
        {
            return await this.ProcessAsync(message, typeof(ICommandHandler<,>), cancellationToken).ConfigureAwait(false);
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> message, CancellationToken cancellationToken)
        {
            return await this.ProcessAsync(message, typeof(IQueryHandler<,>), cancellationToken).ConfigureAwait(false);
        }
    }
}
