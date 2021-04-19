using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using DebtBook.Data;
using DebtBook.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace DebtBook.ViewModels
{
    class EditDebtorViewModel : BindableBase
    {
        private Debtor _debtor;
        private string _title;
        private Debt _selectedDebt;

        public EditDebtorViewModel(string title, Debtor debtor)
        {
            _title = title;
            _debtor = debtor;
            CommandEditDebt = new DelegateCommand(CommandEditDebtExecute).ObservesProperty((() => SelectedDebtor.Debts)).ObservesProperty((() => SelectedDebtor.TotalDebt)); ;
            CommandDeleteDebtor = new DelegateCommand(CommandDeleteDebtorExecute);
        }
        
        public DelegateCommand CommandDeleteDebtor { get; set; }

        private void CommandDeleteDebtorExecute()
        {
            SelectedDebtor.Name = String.Empty;
            SelectedDebtor.Debts.Clear();
        }


        public DelegateCommand CommandEditDebt { get; set; }

        private void CommandEditDebtExecute()
        {
            SelectedDebtor.CalcTotalDebt();
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public Debtor SelectedDebtor
        {
            get => _debtor;
            set => SetProperty(ref _debtor, value);
        }

        public Debt SelectedDebt
        {
            get => _selectedDebt;
            set => SetProperty(ref _selectedDebt, value);
        }

    }
}