using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SmartVideo
{
    public class ChangePageButtonCommand : ICommand
    {
        private Action WhattoExecute;
        private Func<bool> WhentoExecute;

        public ChangePageButtonCommand(Action What, Func<bool> When, INotifyPropertyChanged npc)
        {
            WhattoExecute = What;
            WhentoExecute = When;

            if (npc != null)
            {
                npc.PropertyChanged += new PropertyChangedEventHandler(npc_PropertyChanged);
            }
        }

        void npc_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return WhentoExecute();
        }

        public void Execute(object parameter)
        {
            WhattoExecute();
        }

        public event EventHandler CanExecuteChanged;
    }
}