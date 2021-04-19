using System;
using Prism.Mvvm;

namespace DebtBook.Models
{
    public class Debt : BindableBase
    {
        public DateTime DebtDate     { get; set; } = DateTime.Today;
        public double DebtAmount { get; set; } = 0;
    }
}