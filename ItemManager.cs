using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class ItemManager
    {
        EffectManager em = new EffectManager();
        List<Item> itemList = new List<Item>();

        #region Getter

        public List<Item> GetItemList()
        {
            return itemList;
        }

        public Item GetItem(int id)
        {
            Item item = new Item();
            for (int i = 0; i < itemList.Count; i++)
            {
                if(itemList[i].GetItemID() == id)
                {
                    item = itemList[i];
                }
            }

            return item;
        }

        #endregion

        #region Public Methods

        public void LoadItems()
        {
            itemList.Clear();

            #region Consumables
            //Consumables
            Item healthPotionS = new Item(
                "Small Health Potion",  // Name
                "Recovers 100 Health",  // Description
                1,    // ItemID
                true, //Usable?
                10,   // Price
                1);   // Amount

            itemList.Add(healthPotionS);
            //-------------------------------------------------------
            Item manaPotionS = new Item(
                "Small Mana Potion",  // Name
                "Recovers 30 Mana",  // Description
                2,   // ItemID
                true, //Useable?
                15,  // Price
                1);  // Amount

            itemList.Add(manaPotionS);
            //-------------------------------------------------------
            Item healthPotionM = new Item(
                "Medium Health Potion",  // Name
                "Recovers 250 Health",  // Description
                3,    // ItemID
                true, //Usable?
                50,   // Price
                1);   // Amount

            itemList.Add(healthPotionM);
            //-------------------------------------------------------
            Item manaPotionM = new Item(
                "Medium Mana Potion",  // Name
                "Recovers 70 Mana",  // Description
                4,   // ItemID
                true, //Usable?
                65,  // Price  
                1);  // Amount

            itemList.Add(manaPotionM);
            //-------------------------------------------------------
            #endregion

            #region Materials
            Item runeStone = new Item(
               "Rune Stone",  // Name
               "Used for upgrading Equipment",  // Description
               101,   // ItemID
               false, //Usable?
               30,  // Price  
               1);  // Amount

            itemList.Add(runeStone);
            //-------------------------------------------------------
            Item runicDust = new Item(
               "Runic Dust",  // Name
               "Used for upgrading Equipment",  // Description
               102,   // ItemID
               false, //Usable?
               15,  // Price  
               1);  // Amount

            itemList.Add(runicDust);
            //-------------------------------------------------------
            Item whiteDust = new Item(
               "White Dust",  // Name
               "Used for upgrading Equipment",  // Description
               103,   // ItemID
               false, // Usable?
               50,    // Price  
               1,     // Amount
               50);   // DropChance

            itemList.Add(whiteDust);
            //-------------------------------------------------------
            Item redDust = new Item(
               "Red Dust",  // Name
               "Used for upgrading Equipment",  // Description
               104,   // ItemID
               false, // Usable?
               50,    // Price  
               1,     // Amount
               50);   // DropChance

            itemList.Add(redDust);
            //-------------------------------------------------------
            Item blueDust = new Item(
               "Blue Dust",  // Name
               "Used for upgrading Equipment",  // Description
               105,   // ItemID
               false, // Usable?
               50,    // Price  
               1,     // Amount
               50);   // DropChance

            itemList.Add(blueDust);
            //-------------------------------------------------------
            Item yellowDust = new Item(
               "Yellow Dust",  // Name
               "Used for upgrading Equipment",  // Description
               106,   // ItemID
               false, // Usable?
               50,    // Price  
               1,     // Amount
               50);   // DropChance

            itemList.Add(yellowDust);
            //-------------------------------------------------------
            Item blackDust = new Item(
               "Black Dust",  // Name
               "Used for upgrading Equipment",  // Description
               107,   // ItemID
               false, // Usable?
               50,    // Price  
               1,     // Amount
               50);   // DropChance

            itemList.Add(blackDust);
            //-------------------------------------------------------
            Item holyStone = new Item(
               "Holy Stone",  // Name
               "Used for upgrading Excalibur",  // Description
               108,   // ItemID
               false, // Usable?
               5000,  // Price  
               1,     // Amount
               100);   // DropChance

            itemList.Add(holyStone);
            //-------------------------------------------------------
            #endregion


        }

        public void UseItem(Item item, Player player)
        {
            em.LoadEffects();
            switch (item.GetItemID())
            {
                //Small Health Potion
                case 1:
                    if (player.GetHealth() >= player.GetMaxHealth())
                    {
                        Console.WriteLine("|| Already Max Health!");
                    }
                    else
                    {
                        player.AddHealth(100);
                        item.SetAmount(item.GetAmount() - 1);

                        Console.WriteLine("|| Used 1 {0}!", item.GetName());
                        Console.WriteLine("|| Recovered 100 Health!");
                    }
                    break;
                //Small Mana Potion
                case 2:
                    if (player.GetMana() >= player.GetMaxMana())
                    {
                        Console.WriteLine("|| Already Max Mana!");
                    }
                    else
                    {
                        player.AddMana(30);
                        item.SetAmount(item.GetAmount() - 1);

                        Console.WriteLine("|| Used 1 {0}!", item.GetName());
                        Console.WriteLine("|| Recovered 30 Mana!");
                    }
                    break;
                //Medium Health Potion
                case 3:
                    if (player.GetHealth() >= player.GetMaxHealth())
                    {
                        Console.WriteLine("|| Already Max Health!");
                    }
                    else
                    {
                        player.AddHealth(250);
                        item.SetAmount(item.GetAmount() - 1);

                        Console.WriteLine("|| Used 1 {0}!", item.GetName());
                        Console.WriteLine("|| Recovered 250 Health!");
                    }
                    break;
                //Medium Mana Potion
                case 4:
                    if (player.GetMana() >= player.GetMaxMana())
                    {
                        Console.WriteLine("|| Already Max Mana!");
                    }
                    else
                    {
                        player.AddMana(70);
                        item.SetAmount(item.GetAmount() - 1);

                        Console.WriteLine("|| Used 1 {0}!", item.GetName());
                        Console.WriteLine("|| Recovered 70 Mana!");
                    }
                    break;

                default:
                    Console.WriteLine("|| No item found");
                    break;

            }

            player.RefreshInventory();
        }
        #endregion
    }
}
