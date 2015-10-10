using System;
using System.Threading.Tasks;

namespace MeetEric.Input
{
    public class ActionCommand : AsyncCommand
    {
        private readonly Func<Task> _action;

        public ActionCommand(Func<Task> action)
        {
            _action = action;
        }

        protected override async Task ExecuteAsync()
        {
            await _action();
        }
    }
}