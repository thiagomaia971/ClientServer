using System;
using ClientServer.Domain.Commands;

namespace ClientServer.Domain.CommandHandlers
{
    public class SampleCommandHandler : CommandHandler<SampleCommand, int>
    {
        public override int Handle(SampleCommand command) 
            => new Random().Next();
    }
}