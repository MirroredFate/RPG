using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Equipment
    {
        public string name;
        public string description;

        int itemID;
        int type; //1 = Weapon, 2 = Armor 
        int price; //Selling Price
        int weaponType; //1 = Melee, 2 = Bow, 3 = Wand/Staff
        int armorType; //1 = Helmet, 2 = Breast, 3 = Gloves, 4 = Boots
        int elementType; //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark

        //Bonus stats
        int staminaBonus;
        int defenseBonus;
        int strengthBonus;
        int intelligenceBonus;
        int speedBonus;

        //Bonus elemental Resistence
        int fireResBonus;
        int waterResBonus;
        int windResBonus;
        int lightResBonus;
        int darkResBonus;

        //For Weapon
        int damage;
        int critBonus;

        int level;
        int tier;

        bool isEquipped;

        public Equipment(string name = "Not equipped", string description = "", int itemID = -1, int price = 0, int type = 0, int subtype = 0, int tier = 0, int elementType = 0, int critBonus = 0, int staminaBonus = 0, int defBonus = 0, int strengthBonus = 0, int intBonus = 0, int speedBonus = 0, int fireResBonus = 0, int waterResBonus = 0, int windResBonus = 0, int lightResBonus = 0, int darkResBonus = 0, int damage = 0)
        {
            this.name = name;
            this.description = description;
            this.itemID = itemID;
            this.level = 0;
            this.price = price;
            this.type = type;
            this.tier = tier;
            if(type == 1)
            {
                this.weaponType = subtype;
                this.critBonus = critBonus;
                this.damage = damage;
                this.armorType = 0;
            }
            else if(type == 2)
            {
                this.armorType = subtype;
                this.critBonus = 0;
                this.weaponType = 0;
            }
            this.elementType = elementType;
            this.staminaBonus = staminaBonus;
            this.strengthBonus = strengthBonus;
            this.defenseBonus = defBonus;
            this.intelligenceBonus = intBonus;
            this.speedBonus = speedBonus;
            this.fireResBonus = fireResBonus;
            this.waterResBonus = waterResBonus;
            this.windResBonus = windResBonus;
            this.lightResBonus = lightResBonus;
            this.darkResBonus = darkResBonus;

        }

        #region Setter

        public void SetItemID(int ID)
        {
            this.itemID = ID;
        }

        public void SetPrice(int amount)
        {
            this.price = amount;
        }

        public void SetIsEquipped(bool equipped)
        {
            this.isEquipped = equipped;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public void SetDamage(int amount)
        {
            this.damage = amount;
        }

        public void SetStamina(int amount)
        {
            this.staminaBonus = amount;
        }

        public void SetDefense(int amount)
        {
            this.defenseBonus = amount;
        }

        public void SetStrength(int amount)
        {
            this.strengthBonus = amount;
        }

        public void SetSpeed(int amount)
        {
            this.speedBonus = amount;
        }

        public void SetIntelligence(int amount)
        {
            this.intelligenceBonus = amount;
        }

        #endregion

        #region Getter

        public string GetName()
        {
            if(level > 0)
            {
                return name + " +" + level;
            }
            else
            {
                return name;
            }
            
        }

        public int GetEquipmentType()
        {
            return type;
        }

        public int GetItemID()
        {
            return itemID;
        }

        public int GetWeaponType()
        {
            return weaponType;
        }

        public int GetArmorType()
        {
            return armorType;
        }

        public int GetStaminaBonus()
        {
            return staminaBonus;
        }

        public int GetDefenseBonus()
        {
            return defenseBonus;
        }

        public int GetStrengthBonus()
        {
            return strengthBonus;
        }

        public int GetIntelligenceBonus()
        {
            return intelligenceBonus;
        }

        public int GetSpeedBonus()
        {
            return speedBonus;
        }

        public int GetDamage()
        {
            return damage;
        }

        public int GetPrice()
        {
            return price;
        }

        public bool GetIsEquipped()
        {
            return isEquipped;
        }

        public string GetIsEquippedText()
        {
            if (isEquipped)
            {
                return "Equipped";
            }
            else
            {
                return "";
            }
        }


        public int GetLevel()
        {
            return level;
        }

        public string GetElementText()
        {
            if(elementType == 2)
            {
                return "|Fire|";
            }
            else if (elementType == 3)
            {
                return "|Water|";
            }
            else if (elementType == 4)
            {
                return "|Wind|";
            }
            else if (elementType == 5)
            {
                return "|Light|";
            }
            else if (elementType == 6)
            {
                return "|Dark|";
            }
            else
            {
                return "|Normal|";
            }
        }

        public string GetElementBattleText()
        {
            if (elementType == 2)
            {
                return "fire";
            }
            else if (elementType == 3)
            {
                return "water";
            }
            else if (elementType == 4)
            {
                return "wind";
            }
            else if (elementType == 5)
            {
                return "light";
            }
            else if (elementType == 6)
            {
                return "dark";
            }
            else
            {
                return "normal";
            }
        }

        public ConsoleColor GetElementColor()
        {
            if (elementType == 2) // Fire
            {
                return ConsoleColor.Red;
            }
            else if (elementType == 3) // Water
            {
                return ConsoleColor.Blue;
            }
            else if (elementType == 4) // Wind
            {
                return ConsoleColor.DarkYellow;
            }
            else if (elementType == 5) // Light
            {
                return ConsoleColor.Cyan;
            }
            else if (elementType == 6) // Dark
            {
                return ConsoleColor.DarkGray;
            }
            else // Normal
            {
                return ConsoleColor.White;
            }
        }

        public int GetElementType()
        {
            return elementType;
        }

        public int GetCritChance()
        {
            return critBonus;
        }

        public string GetCritText()
        {
            return critBonus + "%";
        }

        public int GetFireRes()
        {
            return fireResBonus;
        }

        public int GetWaterRes()
        {
            return waterResBonus;
        }

        public int GetWindRes()
        {
            return windResBonus;
        }

        public int GetLightRes()
        {
            return lightResBonus;
        }

        public int GetDarkRes()
        {
            return darkResBonus;
        }

        public int GetTier()
        {
            return tier;
        }

        #endregion

        #region Public Methods

        public void SetStats()
        {
            if(damage >= 1)
            {
                damage += level * 2;
            }

            if(staminaBonus >= 1)
            {
                staminaBonus += level * 2; 
            }

            if(strengthBonus >= 1)
            {
                strengthBonus += level * 2;
            }

            if(defenseBonus >= 1)
            {
                defenseBonus += level * 2;
            }

            if(intelligenceBonus >= 1)
            {
                intelligenceBonus += level * 2;
            }
            
            if(speedBonus >= 1)
            {
                speedBonus += level * 2;
            }

            price *= level;
            
        }




        #endregion
    }
}
