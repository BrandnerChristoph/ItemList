using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItemListPersistence list;
        public MainWindow()
        {
            InitializeComponent();
            list = new ItemListPersistence();
        }

        private void ResetInput()
        {
            name_txtB.Text = "";
            amount_txtB.Text = "";
            quant_txtB.Text = "";
            details_txtB.Text = "";
            name_txtB.Focus();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Item i = new Item(name_txtB.Text.ToString(), 
                                    details_txtB.Text.ToString(), 
                                    double.Parse(amount_txtB.Text.ToString()),
                                    int.Parse(quant_txtB.Text.ToString())
                                );

                list.Items.Add(i);
                //items_lB.Items.Add(i.Name + "(" + i.Quantity.ToString() + ")");
                items_lB.Items.Add(i);
                this.SaveList();
                this.ResetInput();

            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Button_ItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (items_lB.SelectedItem == null) MessageBox.Show("Es wurde kein Artikel gewählt!", "keine Auswahl", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Item iSelected = (Item)items_lB.SelectedItem;
                name_txtB.Text = iSelected.Name;
                details_txtB.Text = iSelected.Details;
                amount_txtB.Text = iSelected.Amount.ToString();                
            }            
        }

        private void Button_ItemDelete_Click(object sender, RoutedEventArgs e)
        {
            if (items_lB.SelectedItem == null) MessageBox.Show("Es wurde kein Artikel gewählt!", "keine Auswahl", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBoxResult result = MessageBox.Show("Soll der Artikel gelöscht werden?", "Artikel löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    items_lB.Items.RemoveAt(items_lB.SelectedIndex);
                }
            }
        }

        /************************************
         * Menü
         ******************************/
        private void MenuItem_Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Shopping List\nVersion: 0.01", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        private bool SaveList(string filepath = "data.xml")
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(ItemListPersistence));

                var path = filepath;
                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, list);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim File speichern", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        }

        public bool LoadList(string filepath = "data.xml")
        {
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(ItemListPersistence));

                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                list = (ItemListPersistence)reader.Deserialize(file);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim File laden", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return true;
        }

    }
}
