using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Skill
    {
        string name;
        int id;
        int type; //1 - Physical | 2 - Elemental
        int elementType; //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark

        int manaCost; //How much Mana the Skill costs
        int level;

        int damage;

        public Skill(string name = "No skill equipped", int id = 0, int type = 0, int elementType = 0, int manaCost = 0, int damage = 0)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            if(this.type == 1)
            {
                this.elementType = 1;
            }
            else
            {
                this.elementType = elementType;
            }
            this.manaCost = manaCost;

            this.damage = damage;
            this.level = 0;
        }

                
        #region Setter

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetType(int type)
        {
            this.type = type;
        }

        public void SetManaCost(int amount)
        {
            this.manaCost = amount;
        }

        public void SetDamage(int amount)
        {
            this.damage = amount;

        }

        #endregion

        #region Getter

        public string GetName()
        {
            return name;
        }

        public int GetID()
        {
            return id;
        }

        public int GetSkillType()
        {
            return type;
        }

        public int GetManaCost()
        {
            return manaCost;
        }

        public int GetDamage()
        {
            return damage;
        }

        public string GetElementText()
        {
            if(elementType == 2)
            {
                return "Fire";
            }
            else if(elementType == 3)
            {
                return "Water";
            }
            else if (elementType == 4)
            {
                return "Wind";
            }
            else if (elementType == 5)
            {
                return "Light";
            }
            else if (elementType == 6)
            {
                return "Dark";
            }
            else
            {
                return "Normal";
            }
        }

        public int GetElementType()
        {
            return elementType;
        }

        public string GetLevelText()
        {
            if(level <= 0)
            {
                return "";
            }
            else
            {
                return "+" + level;
            }
        }

        public int GetLevel()
        {
            return level;
        }

        #endregion

    }
}
