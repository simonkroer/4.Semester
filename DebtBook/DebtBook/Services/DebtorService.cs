using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using DebtBook.Models;

namespace DebtBook.Services
{
    public interface IDebtorService
    {
        public ObservableCollection<Debtor> AllDebtors();
    }
    public class DebtorService: IDebtorService
    {
        public ObservableCollection<Debtor> AllDebtors()
        {
            return new ObservableCollection<Debtor>()
            {
            new Debtor("Henrik Hansen",15000),
            new Debtor("Ole Hansen",10000),
            new Debtor( "Henning Hansen",-5000),
            new Debtor("Svend Hansen",7000),
            new Debtor("Hanne Hansen",-1000) 
            };
        }
    }
}