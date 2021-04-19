using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using DebtBook.Data;
using Prism.Commands;
using DebtBook.Models;
using DebtBook.Services;
using DebtBook.Views;
using Microsoft.Win32;
using Prism.Mvvm;

namespace DebtBook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IWindowFactory _editDebtorWindowFactory;
        private readonly IWindowFactory _addDebtorsWindowFactory;
        private string _filePath = "";
        private readonly string _appTitle = "DebtBook Mandatory Assignment";
        private string _filename ="";
        private Debtor _selectedDebtor = null;
        private int _currentIndex = -1;
        private ObservableCollection<Debtor> _debtors;
        private double _sumOfTotalDebt;

        public MainWindowViewModel(Services.IDebtorService debtorService)
        {
            Title = _appTitle;
            Debtors = debtorService.AllDebtors();
            CommandAddDebtor = new DelegateCommand(CommandAddDebtorExecute);
            CommandAddDebts = new DelegateCommand(CommandAddDebtsExecute);
            CommandUpdateTotalDebt = new DelegateCommand(CommandUpdateTotalDebtExecute,CommandUpdateTotalDebtCanExecute).ObservesProperty((() => SelectedDebtor.TotalDebt)).ObservesProperty((() => Debtors.Count));
            _addDebtorsWindowFactory = new AddDebtorWindowFactory();
            _editDebtorWindowFactory = new EditDebtorWindowFactory();
            CalcSumOfTotalDebt();
        }

        private bool CommandUpdateTotalDebtCanExecute()
        {
            CalcSumOfTotalDebt();
            return true;
        }

        private void CommandUpdateTotalDebtExecute()
        {
        }

        public ICommand CommandUpdateTotalDebt { get; private set; }

        private void CalcSumOfTotalDebt()
        {
            double sum = 0;
            foreach (var debtor in Debtors)
            {
                sum += debtor.TotalDebt;
            }

            SumOfTotalDebt = sum;
        }

        public double SumOfTotalDebt
        {
            get => _sumOfTotalDebt;
            set => SetProperty(ref _sumOfTotalDebt, value);
        }

        #region Properties

        public string Filename
        {
            get => _filename;
            set => SetProperty(ref _filename, value);
        }


        public ObservableCollection<Debtor> Debtors
        {
            get => _debtors;
            set => SetProperty(ref _debtors, value);
        }

        public Debtor SelectedDebtor
        {
            get => _selectedDebtor;
            set => SetProperty<Debtor>(ref _selectedDebtor, value);
        }

        public int CurrentIndex
        {
            get => _currentIndex;
            set => SetProperty(ref _currentIndex, value);
        }

        public string Title { get; set; }

        #endregion

        #region Commands

        ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand ??= new DelegateCommand(() =>
                {
                    Application.Current.MainWindow.Close();
                });
            }
        }

        //Method borrowed from Lab Exercise 11 Agent Assignment
        private void SaveFile()
        {
            try
            {
                Repository.SaveDebtorFile(_filePath, Debtors);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ICommand _saveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _saveAsCommand ??= new DelegateCommand<string>(SaveAsCommand_Execute); }
        }

        //Method borrowed from Lab Exercise 11 Agent Assignment
        private void SaveAsCommand_Execute(string argFilename)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Debt book documents|*.txt|All Files|*.*",
                DefaultExt = "txt"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                _filePath = dialog.FileName;
                Filename = Path.GetFileName(_filePath);
                SaveFile();
            }
        }
        //Method borrowed from Lab Exercise 11 Agent Assignment
        ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ??= new DelegateCommand(SaveFileCommandExecute, SaveFileCommandCanExecute)
                    .ObservesProperty(() => Debtors.Count);
            }
        }
        //Method borrowed from Lab Exercise 11 Agent Assignment


        private void SaveFileCommandExecute()
        {
            SaveFile();
        }
        //Method borrowed from Lab Exercise 11 Agent Assignment
        private bool SaveFileCommandCanExecute()
        {
            return (_filename != "") && (Debtors.Count > 0);
        }


        public ICommand CommandAddDebtor { get; private set; }

        private void CommandAddDebtorExecute()
        {
            var debtor = new Debtor();

            if (_addDebtorsWindowFactory.CreateNewWindow("Add new Debtor", debtor))
            {
                Debtors.Add(debtor);
                _selectedDebtor = debtor;
            }
        }

        public ICommand CommandAddDebts { get; private set; }

        private void CommandAddDebtsExecute()
        {
            var debtor = new Debtor(_selectedDebtor.Name, _selectedDebtor.TotalDebt);
            debtor.Debts.Clear();
            foreach (var debt in _selectedDebtor.Debts)
            {
                debtor.Debts.Add(debt);
            }
            //open editdebtorWindow
            if (_editDebtorWindowFactory.CreateNewWindow("Edit Debts for " + debtor.Name, debtor))
            {
                if (string.IsNullOrWhiteSpace(debtor.Name))
                {
                    try
                    {
                        Debtors.RemoveAt(CurrentIndex);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }

                }
                else
                {
                    SelectedDebtor.Debts.Clear();
                    foreach (var debt in debtor.Debts)
                    {
                        SelectedDebtor.Debts.Add(debt);
                    }
                    SelectedDebtor.CalcTotalDebt();
                }
            }
        }

        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get { return _NewFileCommand ??= new DelegateCommand(NewFileCommand_Execute); }
        }
        //Method borrowed from Lab Exercise 11 Agent Assignment
        private void NewFileCommand_Execute()
        {
            MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.Yes)
            {
                Debtors.Clear();
                Filename = "";
            }
        }

        //Method borrowed from Lab Exercise 11 Agent Assignment
        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ??= new DelegateCommand<string>(OpenFileCommand_Execute); }
        }
        //Method borrowed from Lab Exercise 11 Agent Assignment
        private void OpenFileCommand_Execute(string argFilename)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Debt book documents|*.txt|All Files|*.*",
                DefaultExt = "txt"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                _filePath = dialog.FileName;
                Filename = Path.GetFileName(_filePath);
                try
                {
                    Repository.ReadDebtorFile(_filePath, out ObservableCollection<Debtor> tempDebtors);
                    Debtors = tempDebtors;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        //Method borrowed from Lab Exercise 11 Agent Assignment
        ICommand _closingCommand;


        public ICommand ClosingCommand
        {
            get
            {
                return _closingCommand ??= new
                    DelegateCommand<CancelEventArgs>(ClosingCommand_Execute);
            }
        }

        //Method borrowed from Lab Exercise 11 Agent Assignment
        private void ClosingCommand_Execute(CancelEventArgs arg)
        {
            arg.Cancel = UserRegrets();
        }




        //Method borrowed from Lab Exercise 11 Agent Assignment
        private bool UserRegrets()
        {
            var regret = false;
            MessageBoxResult res = MessageBox.Show("You have unsaved data. Are you sure you want to close the application without saving data first?",
                            "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.No)
            {
                regret = true;
            }
            return regret;
        }
        #endregion
    }


}