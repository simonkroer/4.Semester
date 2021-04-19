using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Navigation;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public interface IDebtor
    {
        public string Name { get; set; }
        public double TotalDebt { get; }
    }
    public class Debtor : BindableBase, IDebtor
    {
        private string _name;
        private ObservableCollection<Debt> _debts;
        private double _totalDebt;

        public Debtor()
        {
            Debts = new ObservableCollection<Debt>();
            CalcTotalDebt();
        }
        public Debtor(string name, double initDebt)
        {
            _name = name;
            Debts = new ObservableCollection<Debt> {new Debt() {DebtAmount = initDebt, DebtDate = DateTime.Today}};
            CalcTotalDebt();
        }

        public Debtor(string name, double initDebt,DateTime initDateTime)
        {
            _name = name;
            Debts = new ObservableCollection<Debt> {new Debt() {DebtAmount = initDebt, DebtDate = initDateTime}};
            CalcTotalDebt();
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<Debt> Debts
        {
            get => _debts;
            set => SetProperty(ref _debts,value);
        }

        public double TotalDebt
        {
            get => _totalDebt;
            set => SetProperty(ref _totalDebt, value);
        }

        public void CalcTotalDebt()
        {
            double totalDebt = 0;

            foreach (var debt in Debts)
            {
                totalDebt += debt.DebtAmount;
            }

            TotalDebt = totalDebt;
        }

    }
}