using System;

namespace Asteroids
{
    public class Command
    {
        private Func<bool> condition;
        private Action action;

        public Command(Func<bool> condition, Action action)
        {
            this.condition = condition;
            this.action = action;
        }

        public void Execute()
        {
            action();
        }

        public bool CanExecute()
        {
            return condition();
        }
    }
}