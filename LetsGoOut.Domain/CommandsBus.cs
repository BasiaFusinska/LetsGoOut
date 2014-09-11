using System.Web.Mvc;

namespace LetsGoOut.Domain
{
    public interface IRequest
    { }
    public interface ICommand
    { }

    public interface IRequestHandler<T, U> 
        where T : IRequest
        where U : ICommand
    {
        U Handle(T request);
    }

    public interface IHandler<T> where T : ICommand
    {
        void Handle(T command);
    }

    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;

        U GetModel4Request<T, U>(T request)
            where T : IRequest
            where U : ICommand;
    }
    public class CommandsBus : ICommandBus
    {
        public void Send<T>(T command) where T : ICommand
        {
            var handler = DependencyResolver.Current.GetService<IHandler<T>>();
            handler.Handle(command);
        }

        public U GetModel4Request<T, U>(T request) 
            where T: IRequest 
            where U : ICommand
        {
            var requestHandler = DependencyResolver.Current.GetService<IRequestHandler<T, U>>();
            return requestHandler.Handle(request);
        }
    }
}
