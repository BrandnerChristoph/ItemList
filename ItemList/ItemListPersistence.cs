using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ItemList
{

    public class ItemListPersistence
    {
        public List<Item> Items;

        public ItemListPersistence()
        {
            this.Items = new List<Item>();
        }

        public int GetNewId()
        {
            if (Items.Count == 0) return 1;

            int newId = 0;
            foreach (Item i in Items)
            {
                if(newId < i.Id)
                    newId = i.Id;
            }
            return newId++;
        }

        public bool AddItem(Item i)
        {
            try
            {
                i.Id = GetNewId();
                Items.Add(i);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return true;
        }

    }
}
