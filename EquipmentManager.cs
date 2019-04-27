using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class EquipmentManager
    {
        List<Equipment> equipmentList = new List<Equipment>();


        #region Getter

        public List<Equipment> GetEquipmentList()
        {
            return equipmentList;
        }

        public Equipment GetEquipment(int id)
        {
            Equipment eq = new Equipment();
            
            for (int i = 0; i < equipmentList.Count; i++)
            {
                if(equipmentList[i].GetItemID() == id)
                {
                    eq = equipmentList[i];
                }
            }

            return eq;
        }

        #endregion

        #region Public Methods

        public void LoadEquipment()
        {
            equipmentList.Clear();

            LoadHelmet();
            LoadBreastpiece();
            LoadGloves();
            LoadBoots();
            LoadWeapons();
        }

        public void EquipEquipment(Equipment eq, Player player, int slot)
        {
            eq.SetStats();

            if (eq.GetEquipmentType() == 1)
            {
                Equipment equip = player.GetWeapon();
                equip.SetIsEquipped(false);
                player.UpdateStats();
                player.AddToInventory(equip);
                eq.SetIsEquipped(true);
                player.SetWeapon(eq);

                Console.WriteLine("|| Equipped {0}", eq.GetName());

                player.RemoveFromInventory(slot);
            }
            else
            {
                //Helmet
                if (eq.GetArmorType() == 1)
                {
                    Equipment equip = player.GetHelmet();
                    equip.SetIsEquipped(false);
                    player.UpdateStats();
                    player.AddToInventory(equip);
                    eq.SetIsEquipped(true);
                    player.SetHelmet(eq);

                    Console.WriteLine("|| Equipped {0}", eq.GetName());

                    player.RemoveFromInventory(slot);
                }
                //Torso
                else if (eq.GetArmorType() == 2)
                {
                    Equipment equip = player.GetTorso();
                    equip.SetIsEquipped(false);
                    player.UpdateStats();
                    player.AddToInventory(equip);
                    eq.SetIsEquipped(true);
                    player.SetTorso(eq);

                    Console.WriteLine("|| Equipped {0}", eq.GetName());

                    player.RemoveFromInventory(slot);
                }
                //Gloves
                else if (eq.GetArmorType() == 3)
                {
                    Equipment equip = player.GetGloves();
                    equip.SetIsEquipped(false);
                    player.UpdateStats();
                    player.AddToInventory(equip);
                    eq.SetIsEquipped(true);
                    player.SetGloves(eq);

                    Console.WriteLine("|| Equipped {0}", eq.GetName());

                    player.RemoveFromInventory(slot);
                }
                //Boots
                else if (eq.GetArmorType() == 4)
                {
                    Equipment equip = player.GetBoots();
                    equip.SetIsEquipped(false);
                    player.UpdateStats();
                    player.AddToInventory(equip);
                    eq.SetIsEquipped(true);
                    player.SetBoots(eq);

                    Console.WriteLine("|| Equipped {0}", eq.GetName());

                    player.RemoveFromInventory(slot);
                }
            }


        }



        #endregion
        #region Private Methods

        void LoadHelmet()
        {
            #region StartEquipment

            Equipment ironHelmet = new Equipment
                    ("Iron Helmet", //Name
                     "A normal Iron Helmet", //Description
                     1,   //Item ID
                     100, //Price
                     2,   //1 = Weapon, 2 = Armor
                     1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                     0,   //Equipment Tier
                     1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                     0,   //CritBonus
                     5,   //Stamina Stat Bonus
                     8,   //Defense Stat Bonus
                     4,   //Strength Stat Bonus
                     0,   //Intelligence Stat Bonus
                     0,   //Speed Stat Bonus
                     0,   //Fire Resistance Bonus
                     0,   //Water Resistance Bonus
                     0,   //Wind Resistance Bonus
                     0,   //Light Resistance Bonus
                     0,   //Dark Resistance Bonus
                     0);  //Damage

            equipmentList.Add(ironHelmet);
            //--------------------------------------------------------

            Equipment leatherMask = new Equipment
                ("Leather Mask", //Name
                 "A leather Mask often used by Assassins to disguise their face", //Description
                 2,   //Item ID
                 100, //Price
                 2,   //1 = Weapon, 2 = Armor
                 1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Equipment Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 0,   //CritBonus
                 2,   //Stamina Stat Bonus
                 2,   //Defense Stat Bonus
                 7,   //Strength Stat Bonus
                 0,   //Intelligence Stat Bonus
                 2,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 0);  //Damage

            equipmentList.Add(leatherMask);
            //--------------------------------------------------------

            Equipment leatherHood = new Equipment
                ("Leather Hood", //Name
                 "A leather Hood designed for Archers to give them little but effective protection", //Description
                 3,   //Item ID
                 100, //Price
                 2,   //1 = Weapon, 2 = Armor
                 1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Equipment Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 0,   //CritBonus
                 3,   //Stamina Stat Bonus
                 2,   //Defense Stat Bonus
                 5,   //Strength Stat Bonus
                 0,   //Intelligence Stat Bonus
                 4,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 0);  //Damage

            equipmentList.Add(leatherHood);
            //--------------------------------------------------------

            Equipment mageHat = new Equipment
                ("Simple Mage Hat", //Name
                 "A simple Mage Hat designed especially for young determined Mages.", //Description
                 4,   //Item ID
                 100, //Price
                 2,   //1 = Weapon, 2 = Armor
                 1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Equipment Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 0,   //CritBonus
                 2,   //Stamina Stat Bonus
                 2,   //Defense Stat Bonus
                 0,   //Strength Stat Bonus
                 5,   //Intelligence Stat Bonus
                 0,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 0);  //Damage

            equipmentList.Add(mageHat);
            //--------------------------------------------------------
            #endregion
        }

        void LoadBreastpiece()
        {
            #region StartEquipment
            Equipment ironBreastplate = new Equipment
                   ("Iron Breastplate", //Name
                    "A normal Iron Breastplate", //Description
                    101, //Item ID
                    150, //Price
                    2,   //1 = Weapon, 2 = Armor 
                    2,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    3,   //Stamina Stat Bonus
                    15,  //Defense Stat Bonus
                    5,   //Strength Stat Bonus
                    0,   //Intelligence Stat Bonus
                    0,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(ironBreastplate);
            //--------------------------------------------------------
            Equipment leatherJacket = new Equipment
                  ("Leather Jacket", //Name
                   "A leather Jacket, perfect for having little defense while being quick.", //Description
                   102, //Item ID
                   150, //Price
                   2,   //1 = Weapon, 2 = Armor 
                   2,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                   0,   //Equipment Tier
                   1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                   0,   //CritBonus
                   4,   //Stamina Stat Bonus
                   2,   //Defense Stat Bonus
                   10,  //Strength Stat Bonus
                   0,   //Intelligence Stat Bonus
                   10,  //Speed Stat Bonus
                   0,   //Fire Resistance Bonus
                   0,   //Water Resistance Bonus
                   0,   //Wind Resistance Bonus
                   0,   //Light Resistance Bonus
                   0,   //Dark Resistance Bonus
                   0);  //Damage

            equipmentList.Add(leatherJacket);
            //--------------------------------------------------------
            Equipment clothRobe = new Equipment
                  ("Cloth Robe", //Name
                   "A cloth robe, perfect for every beginning Mage.", //Description
                   103, //Item ID
                   150, //Price
                   2,   //1 = Weapon, 2 = Armor 
                   2,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                   0,   //Equipment Tier
                   1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                   0,   //CritBonus
                   4,   //Stamina Stat Bonus
                   3,   //Defense Stat Bonus
                   0,   //Strength Stat Bonus
                   10,  //Intelligence Stat Bonus
                   0,   //Speed Stat Bonus
                   0,   //Fire Resistance Bonus
                   0,   //Water Resistance Bonus
                   0,   //Wind Resistance Bonus
                   0,   //Light Resistance Bonus
                   0,   //Dark Resistance Bonus
                   0);  //Damage

            equipmentList.Add(clothRobe);
            //--------------------------------------------------------
            #endregion

        }

        void LoadGloves()
        {
            #region StartEquipment
            Equipment ironGloves = new Equipment
                   ("Iron Gloves", //Name
                    "Simple Iron Gloves", //Description
                    201, //Item ID
                    70,  //Price
                    2,   //1 = Weapon, 2 = Armor 
                    3,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    5,   //Stamina Stat Bonus
                    10,  //Defense Stat Bonus
                    5,   //Strength Stat Bonus
                    0,   //Intelligence Stat Bonus
                    0,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(ironGloves);
            //--------------------------------------------------------

            Equipment leatherGloves = new Equipment
                   ("Leather Gloves", //Name
                    "Leather Gloves, perfect for everyone who's trying to be quick while not sacrificing too much defense.", //Description
                    202, //Item ID
                    70,  //Price
                    2,   //1 = Weapon, 2 = Armor 
                    3,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    3,   //Stamina Stat Bonus
                    2,   //Defense Stat Bonus
                    7,   //Strength Stat Bonus
                    0,   //Intelligence Stat Bonus
                    5,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(leatherGloves);
            //--------------------------------------------------------

            Equipment clothGloves = new Equipment
                   ("Cloth Gloves", //Name
                    "Simple Cloth Gloves designed to fit the powers of a Mage.", //Description
                    203, //Item ID
                    70,  //Price
                    2,   //1 = Weapon, 2 = Armor 
                    3,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    2,   //Stamina Stat Bonus
                    1,   //Defense Stat Bonus
                    0,   //Strength Stat Bonus
                    7,   //Intelligence Stat Bonus
                    0,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(clothGloves);
            //--------------------------------------------------------
            #endregion

        }

        void LoadBoots()
        {
            #region StartEquipment
            Equipment ironBoots = new Equipment
                   ("Iron Boots", //Name
                    "Simple Iron Boots", //Description
                    301, //Item ID
                    65,  //Price
                    2,   //1 = Weapon, 2 = Armor 
                    4,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    5,  //Stamina Stat Bonus
                    10,   //Defense Stat Bonus
                    4,   //Strength Stat Bonus
                    0,   //Intelligence Stat Bonus
                    0,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(ironBoots);
            //--------------------------------------------------------
            Equipment leatherBoots = new Equipment
                   ("Leather Boots", //Name
                    "Simple leather Boots", //Description
                    302, //Item ID
                    65,  //Price
                    2,   //1 = Weapon, 2 = Armor 
                    4,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    3,   //Stamina Stat Bonus
                    2,   //Defense Stat Bonus
                    6,   //Strength Stat Bonus
                    0,   //Intelligence Stat Bonus
                    5,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(leatherBoots);
            //--------------------------------------------------------
            Equipment mageBoots = new Equipment
                   ("Mage Boots", //Name
                    "Simple Boots, designed to fit Mages", //Description
                    303, //Item ID
                    65,  //Price
                    2,   //1 = Weapon, 2 = Armor 
                    4,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                    0,   //Equipment Tier
                    1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    0,   //CritBonus
                    2,   //Stamina Stat Bonus
                    1,   //Defense Stat Bonus
                    0,   //Strength Stat Bonus
                    7,   //Intelligence Stat Bonus
                    0,   //Speed Stat Bonus
                    0,   //Fire Resistance Bonus
                    0,   //Water Resistance Bonus
                    0,   //Wind Resistance Bonus
                    0,   //Light Resistance Bonus
                    0,   //Dark Resistance Bonus
                    0);  //Damage

            equipmentList.Add(mageBoots);
            //--------------------------------------------------------
            #endregion
        }

        

        void LoadWeapons()
        {
            #region StartEquipment / Tier 0

            Equipment ironSword = new Equipment
                ("Iron Sword", //Name
                 "A normal Iron Sword", //Description
                 401, //Item ID
                 250, //Price
                 1,   //1 = Weapon, 2 = Armor 
                 1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Weapon Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 20,  //Crit Chance Bonus
                 5,   //Stamina Stat Bonus
                 0,   //Defense Stat Bonus
                 10,   //Strength Stat Bonus
                 0,   //Intelligence Stat Bonus
                 0,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 7);  //Damage

            equipmentList.Add(ironSword);
            //-----------------------------------------------------
            Equipment twinDagger = new Equipment
                ("Twin Daggers", //Name
                 "Two Daggers, perfect for an Assassin", //Description
                 402, //Item ID
                 250, //Price
                 1,   //1 = Weapon, 2 = Armor 
                 1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Weapon Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 25,  //Crit Chance Bonus
                 3,   //Stamina Stat Bonus
                 0,   //Defense Stat Bonus
                 7,   //Strength Stat Bonus
                 0,   //Intelligence Stat Bonus
                 5,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 5);  //Damage

            equipmentList.Add(twinDagger);
            //-----------------------------------------------------
            Equipment woodenBow = new Equipment
                ("Wooden Bow", //Name
                 "A normal wooden Bow", //Description
                 403, //Item ID
                 250, //Price
                 1,   //1 = Weapon, 2 = Armor 
                 2,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Weapon Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 20,  //Crit Chance Bonus
                 5,   //Stamina Stat Bonus
                 0,   //Defense Stat Bonus
                 5,   //Strength Stat Bonus
                 0,   //Intelligence Stat Bonus
                 3,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 4);  //Damage

            equipmentList.Add(woodenBow);
            //-----------------------------------------------------
            Equipment woodenStaff = new Equipment
                ("Wooden Staff", //Name
                 "A normal wooden Staff", //Description
                 404, //Item ID
                 250, //Price
                 1,   //1 = Weapon, 2 = Armor 
                 3,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 0,   //Weapon Tier
                 1,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 5,   //Crit Chance Bonus
                 5,   //Stamina Stat Bonus
                 0,   //Defense Stat Bonus
                 0,   //Strength Stat Bonus
                 10,   //Intelligence Stat Bonus
                 0,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 2);  //Damage

            equipmentList.Add(woodenStaff);
            //-----------------------------------------------------
            #endregion

            Equipment excalibur = new Equipment
                ("Excalibur", //Name
                 "The legendary Sword Excalibur. Only the chosen one can use it.", //Description
                 405, //Item ID
                 2500, //Price
                 1,   //1 = Weapon, 2 = Armor 
                 1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                 3,   //Weapon Tier
                 5,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                 25,   //Crit Chance Bonus
                 20,   //Stamina Stat Bonus
                 0,   //Defense Stat Bonus
                 30,   //Strength Stat Bonus
                 10,   //Intelligence Stat Bonus
                 10,   //Speed Stat Bonus
                 0,   //Fire Resistance Bonus
                 0,   //Water Resistance Bonus
                 0,   //Wind Resistance Bonus
                 0,   //Light Resistance Bonus
                 0,   //Dark Resistance Bonus
                 100);  //Damage

            equipmentList.Add(excalibur);
            //-----------------------------------------------------
            Equipment fireSword = new Equipment
               ("Fire Sword", //Name
                "A Sword, whose blade is burning.", //Description
                406, //Item ID
                500, //Price
                1,   //1 = Weapon, 2 = Armor 
                1,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                1,   //Weapon Tier
                2,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                5,   //Crit Chance Bonus
                10,   //Stamina Stat Bonus
                0,   //Defense Stat Bonus
                15,   //Strength Stat Bonus
                5,   //Intelligence Stat Bonus
                5,   //Speed Stat Bonus
                0,   //Fire Resistance Bonus
                0,   //Water Resistance Bonus
                0,   //Wind Resistance Bonus
                0,   //Light Resistance Bonus
                0,   //Dark Resistance Bonus
                25);  //Damage

            equipmentList.Add(fireSword);
            //-----------------------------------------------------
            Equipment iceBow = new Equipment
               ("Ice Bow", //Name
                "A normal ice bow.", //Description
                407, //Item ID
                450, //Price
                1,   //1 = Weapon, 2 = Armor 
                2,   //If Weapon, 1 = Melee, 2 = Bow, 3 = Wand/Staff | If Armor, 1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
                0,   //Weapon Tier
                3,   //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                10,   //Crit Chance Bonus
                5,   //Stamina Stat Bonus
                0,   //Defense Stat Bonus
                10,   //Strength Stat Bonus
                0,   //Intelligence Stat Bonus
                10,   //Speed Stat Bonus
                0,   //Fire Resistance Bonus
                0,   //Water Resistance Bonus
                0,   //Wind Resistance Bonus
                0,   //Light Resistance Bonus
                0,   //Dark Resistance Bonus
                20);  //Damage

            equipmentList.Add(iceBow);
            //-----------------------------------------------------
            
        }


        #endregion
    }
}
