using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DebtBook.ViewModels
{
    class AddDebtorViewModel : BindableBase
    {
        private Debtor _debtor;
        private string _title;
        private DateTime _initDate = DateTime.Today;

        public AddDebtorViewModel(string title, Debtor debtor)
        {
            _title = title;
            _debtor = debtor;
            CommandSaveDebtor = new DelegateCommand(CommandSaveDebtorExecute,CommandSaveDebtorCanExecute).ObservesProperty((() => NewDebtor.Name)).ObservesProperty((() => NewDebtor.TotalDebt));
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public Debtor NewDebtor
        {
            get => _debtor;
            set => SetProperty(ref _debtor, value);
        }

        public DateTime InitDate
        {
            get => _initDate;
            set => SetProperty(ref _initDate, value);
        }

        public ICommand CommandSaveDebtor { get; private set; }

        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(NewDebtor.Name))
                    isValid = false;

                return isValid;
            }
        }

        private void CommandSaveDebtorExecute()
        {
            NewDebtor.Debts.Add(new Debt(){DebtAmount = _debtor.TotalDebt,DebtDate = InitDate});
        }
        private bool CommandSaveDebtorCanExecute()
        {
            return IsValid;
        }
    }
}