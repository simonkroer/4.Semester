using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using DebtBook.Models;

namespace DebtBook.Data
{
    public class Repository
    {
        internal static void ReadDebtorFile(string fileName, out ObservableCollection<Debtor> Debtors)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextReader reader = new StreamReader(fileName);
            // Deserialize all the Debtors.
            Debtors = (ObservableCollection<Debtor>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveDebtorFile(string fileName, ObservableCollection<Debtor> Debtors)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debtor>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the Debtors.
            serializer.Serialize(writer, Debtors);
            writer.Close();
        }

        internal static void ReadDebtFile(string fileName, out ObservableCollection<Debt> Debts)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debt>));
            TextReader reader = new StreamReader(fileName);
            // Deserialize all the Debts.
            Debts = (ObservableCollection<Debt>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveDebtFile(string fileName, ObservableCollection<Debt> Debts)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debt>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the Debts.
            serializer.Serialize(writer, Debts);
            writer.Close();
        }
    }
}