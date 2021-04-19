using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBook.Models;
using DebtBook.ViewModels;
using DebtBook.Views;

namespace DebtBook.Services
{
    public interface IWindowFactory
    {
        public bool CreateNewWindow(string title, object e);
    }

    public class AddDebtorWindowFactory : IWindowFactory
    {

        public bool CreateNewWindow(string title, object e)
        {
            AddDebtorWindow addDebtorWindow = new AddDebtorWindow()
            {
                DataContext = new AddDebtorViewModel(title, (Debtor)e)
            };

            return addDebtorWindow.ShowDialog() == true;

        }
    }

    public class EditDebtorWindowFactory : IWindowFactory
    {

        public bool CreateNewWindow(string title, object e)
        {
            EditDebtorWindow editDebtorWindow = new EditDebtorWindow()
            {
                DataContext = new EditDebtorViewModel(title, (Debtor)e)
            };

            return editDebtorWindow.ShowDialog() == true;

        }
    }
}
