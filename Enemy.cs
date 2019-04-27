using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Enemy
    {
        string name;
        int id;

        int type; //1 = Physical, 2 = Magical, 3 = Both
        int element; //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark

        int hp;
        int maxHP;
        int mana;
        int maxMana;

        int defense;
        int strength;
        int intelligence;
        int speed;

        int damage;
        int crit;
        int xp;
        int gold;

        int killCount;

        bool usedSkill;
        bool didCrit;

        List<Skill> skills;
        List<Item> items;

        Item droppedItem;

        public Enemy(string name, int id,int type, int element, int defense, int strength, int intelligence, int speed, int damage, int crit, int xp, int gold, int hp, int mana)
        {
            this.name = name;
            this.id = id;
            this.type = type;
            this.element = element;
            this.defense = defense;
            this.strength = strength;
            this.intelligence = intelligence;
            this.speed = speed;
            this.damage = damage;
            this.crit = crit;
            this.xp = xp;
            this.gold = gold;
            killCount = 0;

            this.maxHP = hp;
            this.hp = this.maxHP;

            this.maxMana = mana;
            this.mana = this.maxMana;
            skills = new List<Skill>();
            items = new List<Item>();

        }

        public Enemy()
        {
            this.name = "Dummy";
            this.id = 0;
            this.type = 1;
            this.hp = 1;
            this.maxHP = 1;
            this.mana = 0;
            this.maxMana = 0;

            this.defense = 0;
            this.strength = 0;
            this.intelligence = 0;
            this.speed = 0;

            this.damage = 0;
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

        public void SetHP(int amount)
        {
            this.hp = amount;
        }

        public void SetMana(int amount)
        {
            this.mana = amount;
        }

        public void SetKillCount(int amount)
        {
            this.killCount = amount;
        }

        public void SetUsedSkill(bool state)
        {
            this.usedSkill = state;
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

        public int GetEnemyType()
        {
            return type;
        }

        public int GetHP()
        {
            return hp;
        }

        public int GetMaxHP()
        {
            return maxHP;
        }

        public int GetMana()
        {
            return mana;
        }

        public int GetMaxMana()
        {
            return maxMana;
        }

        public int GetDefense()
        {
            return defense;
        }

        public int GetStrength()
        {
            return strength;
        }

        public int GetIntelligence()
        {
            return intelligence;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public int GetDamage()
        {
            return damage;
        }

        public int GetXP()
        {
            return xp;
        }

        public int GetGold()
        {
            return gold;
        }

        public int GetKillCount()
        {
            return killCount;
        }

        public List<Skill> GetSkills()
        {
            return skills;
        }

        public Skill GetSkill(int slot)
        {
            return skills[slot];
        }

        public bool GetUsedSkill()
        {
            return usedSkill;
        }

        public string GetElementText()
        {
            if(element == 2)
            {
                return "Fire";
            }
            else if(element == 3)
            {
                return "Water";
            }
            else if (element == 4)
            {
                return "Wind";
            }
            else if (element == 5)
            {
                return "Light";
            }
            else if (element == 6)
            {
                return "Dark";
            }
            else
            {
                return "Normal";
            }
        }

        public ConsoleColor GetElementColor()
        {
            if (element == 2) // Fire
            {
                return ConsoleColor.Red;
            }
            else if (element == 3) // Water
            {
                return ConsoleColor.Blue;
            }
            else if (element == 4) // Wind
            {
                return ConsoleColor.DarkYellow;
            }
            else if (element == 5) // Light
            {
                return ConsoleColor.Cyan;
            }
            else if (element == 6) // Dark
            {
                return ConsoleColor.DarkGray;
            }
            else // Normal
            {
                return ConsoleColor.White;
            }
        }

        public bool GetDidCrit()
        {
            return didCrit;
        }

        public Item GetDroppedItem()
        {
            return droppedItem;
        }
        #endregion

        #region Public Methods

        public int GetDamaged(int damage, string element)
        {
            if(element == "Fire")
            {
                if(this.element == 2) // Fire
                {
                    if (damage > defense)
                    {
                        hp -= (damage - defense);
                        return (damage - defense);
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if(this.element == 3) // Water
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage / 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 4) // Wind
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage * 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 5) // Dark
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 6) // Light
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else if(element == "Water")
            {
                if (this.element == 2) // Fire
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage * 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 3) // Water
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 4) // Wind
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage / 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 5) // Light
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 6) // Dark
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else if (element == "Wind")
            {
                if (this.element == 2) // Fire
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage / 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 3) // Water
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage * 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 4) // Wind
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 5) // Light
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 6) // Dark
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else if (element == "Light")
            {
                if (this.element == 2) // Fire
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 3) // Water
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 4) // Wind
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 5) // Light
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 6) // Dark
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage * 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else if (element == "Dark")
            {
                if (this.element == 2) // Fire
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage ) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 3) // Water
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 4) // Wind
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 5) // Light
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage * 2) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else if (this.element == 6) // Dark
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (damage > defense)
                    {
                        int totalDamage = ((damage) - defense);
                        hp -= totalDamage;
                        return totalDamage;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                if (damage > defense)
                {
                    hp -= (damage - defense);
                    return (damage - defense);
                }
                else
                {
                    return 0;
                }
            }
            

        }

        public bool IsDead()
        {
            if(hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Attack()
        {
            if(type == 1)
            {
                if (CheckForCrit())
                {
                    return damage * strength * 2;
                }
                else
                {
                    return damage * strength;

                }
            }
            else if(type == 2)
            {
                if (CheckForCrit())
                {
                    return damage * intelligence * 2;
                }
                else
                {
                    return damage * intelligence;
                }
            }
            else if(type == 3)
            {
                if (CheckForCrit())
                {
                    return damage * (strength + intelligence) * 2;
                }
                else
                {
                    return damage * (strength + intelligence);
                }
                
            }
            else
            {
                return 0;
            }


        }

        public int UseSkill(int slot)
        {
            if(skills.Count == 1)
            {
                
                if(mana >= skills[0].GetManaCost())
                {
                    usedSkill = true;
                    mana -= skills[0].GetManaCost();
                    //Checking if the Skill is Physical or Magical and Change the Skills Damage accordingly
                    if (skills[0].GetSkillType() == 1)
                    {
                        
                        return skills[0].GetDamage() * ((int)strength / 2);
                    }
                    else
                    {
                       
                        return skills[0].GetDamage() * ((int)intelligence / 2);
                    }
                }
                else
                {
                    return Attack();
                }
                
            }
            else
            {
                if(mana >= skills[0].GetManaCost())
                {
                    usedSkill = true;
                    mana -= skills[slot].GetManaCost();
                    //Checking if the Skill is Physical or Magical and Change the Skills Damage accordingly
                    if (skills[slot].GetSkillType() == 1)
                    {
                        return skills[slot].GetDamage() * ((int)strength / 2);
                    }
                    else
                    {
                        return skills[slot].GetDamage() * ((int)intelligence / 2);
                    }
                }
                else
                {
                    return Attack();
                }

            }

            

        }

        public int Fight(int slot)
        {
            if(skills.Count > 0)
            {
                Random rng = new Random();
                int action = rng.Next(0, 2);

                if (action == 0)
                {
                    return Attack();
                }
                else
                {
                    return UseSkill(slot);
                }
            }
            else
            {
                return Attack();
            }

            
        }

        public void AddSkill(int skillID, SkillManager sm)
        {
            List<Skill> smList = sm.GetSkillList();

            for (int i = 0; i < smList.Count; i++)
            {
                if(skillID == smList[i].GetID())
                {
                    skills.Add(smList[i]);
                }
            }
        }

        public void AddItem(int itemID, int amount, ItemManager im)
        {
            List<Item> imList = im.GetItemList();

            for (int i = 0; i < imList.Count; i++)
            {
                if (itemID == imList[i].GetItemID())
                {
                    Item it = imList[i];
                    it.SetAmount(amount);
                    items.Add(it);
                }
            }
        }

        public bool CheckForCrit()
        {
            Random random = new Random();
            int rng = random.Next(1, 100);

            if (rng <= crit)
            {
                didCrit = true;
                return true;
            }
            else
            {
                didCrit = false;
                return false;
            }
        }

        public Item DropItem()
        {
            Item it = new Item();

            if(items.Count < 1)
            {
                return null;
            }

            if(items.Count > 1)
            {
                Random rnd = new Random();
                int rng = rnd.Next(0, items.Count);
                it = items[rng];
            }
            else
            {
                it = items[0];
            }

            return it;
        }

        public bool ItemDropped()
        {
            if(DropItem() != null)
            {
                Item it = DropItem();
                Random rnd = new Random();
                int rng = rnd.Next(0, 100);

                if (rng > it.GetDropChance())
                {
                    return false;
                }

                droppedItem = it;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        #endregion
    }
}
