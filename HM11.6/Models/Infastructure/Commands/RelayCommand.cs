using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Infastructure.Commands
{
    /// <summary>
    /// Для воспроизведение комманд привязаных к интерфейсу
    /// </summary>
    internal class RelayCommand : CommandBase
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._Execute = execute ?? throw new ArgumentException(nameof(execute));
            this._CanExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return this._CanExecute == null || this._CanExecute(parameter);
        }

        public override void Execute(object parameter)
        { 
            this._Execute(parameter);
        }
    }
}
