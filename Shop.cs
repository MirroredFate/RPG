using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Shop
    {
        List<Item> shopConsumables = new List<Item>();
        List<Item> shopOther = new List<Item>();
        List<Equipment> shopEquipment = new List<Equipment>();
        
        ItemManager im = new ItemManager();
        EquipmentManager em = new EquipmentManager();

        #region Setter


        #endregion

        #region Getter

        public List<Item> GetShopConsumables()
        {
            return shopConsumables;
        }

        public List<Item> GetShopOther()
        {
            return shopOther;
        }

        public List<Equipment> GetShopEquipment()
        {

            return shopEquipment;
        }

        #endregion

        #region Public Methods

        public void LoadShop()
        {
            im.LoadItems();
            em.LoadEquipment();

            // Adding Items to the Shop

            //Consumables
            shopConsumables.Clear();
            shopConsumables.Add(im.GetItem(1)); 
            shopConsumables.Add(im.GetItem(3)); 
            shopConsumables.Add(im.GetItem(2)); 
            shopConsumables.Add(im.GetItem(4));

            //Equipment
            shopEquipment.Clear();
            shopEquipment.Add(em.GetEquipment(405));
            shopEquipment.Add(em.GetEquipment(406));
            shopEquipment.Add(em.GetEquipment(407));


            //Other Items
            shopOther.Clear();
            shopOther.Add(im.GetItem(101));
            shopOther.Add(im.GetItem(102));


        }


        #endregion


    }
}
