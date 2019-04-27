using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Item
    {
        string name;
        int id;
        string description;

        int price;
        int amount;
        int dropChance;

        bool useable;

        public Item(string name = "no item", string description = "", int id = 0, bool useable = false, int price = 0, int amount = 0, int dropChance = 0)
        {
            this.name = name;
            this.id = id;
            this.description = description;
            this.useable = useable;

            this.price = price;
            this.amount = amount;
            this.dropChance = dropChance;
        }

        #region Setter

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public void SetPrice(int amount)
        {
            this.price = amount;
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

        public void SetDropChance(int amount)
        {
            this.dropChance = amount;
        }
        #endregion

        #region Getter

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }

        public int GetItemID()
        {
            return id;
        }

        public int GetPrice()
        {
            return price;
        }

        public int GetAmount()
        {
            return amount;
        }

        public bool GetUseable()
        {
            return useable;
        }

        public int GetDropChance()
        {
            return dropChance;
        }
        #endregion
    }
}
