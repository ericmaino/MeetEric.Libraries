using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeetEric.Input
{
    public abstract class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync();
        }

        protected abstract Task ExecuteAsync();
    }
}