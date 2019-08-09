﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExtendedMVVM.ViewModels
{
    public class InterfaceCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if (execute != null)
                execute(parameter);
        }

        public InterfaceCommand(Action<object> executeAction) : this(executeAction, null)
        {
        }
        public InterfaceCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            canExecute = canExecuteFunc;
            execute = executeAction;
        }



    }
}
