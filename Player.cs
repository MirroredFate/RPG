using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Player
    {
        //Name, Class and Class of the Player
        public string name;
        public string rpgClass;  //Knight, Assassin, Archer, Mage
        public int level;

        //How much health and Mana the Player has
        int health;
        int maxHealth;
        int mana;
        int maxMana;

        //Stats of the Player
        int stamina;
        int defense;
        int strength;
        int intelligence;
        int speed;
        int critChance;

        //Elemental Resistence of the Player
        int fireRes;
        int waterRes;
        int windRes;
        int lightRes;
        int darkRes;

        //Experience of the Player
        int experience;
        int maxExperience;

        //Gold of the Player
        int gold;

        //The Levelpoints the Player has to increase one stat after each level up
        int levelPoints;
        int staminaPoints;
        int defensePoints;
        int strengthPoints;
        int intelligencePoints;
        int speedPoints;

        //Did the player use a skill?
        bool usedSkill;

        //Did the player hit a critical strike?
        bool didCrit;

        Equipment weapon;
        Equipment helmet;
        Equipment torso;
        Equipment gloves;
        Equipment boots;

        List<Skill> skills;
        List<Item> items;
        List<Equipment> equipment;

        List<InventorySlot> inventory;

        EffectManager em = new EffectManager();

        //Creating the Player
        public Player(string name = "Player", string rpgClass = "Class", int level = 1)
        {
            this.name = name;
            this.rpgClass = rpgClass;
            this.level = level;

            fireRes = 0;
            waterRes = 0;
            windRes = 0;
            lightRes = 0;
            darkRes = 0;

            Equipment notEquipped = new Equipment();
            weapon = notEquipped;
            helmet = notEquipped;
            torso = notEquipped;
            gloves = notEquipped;
            boots = notEquipped;

            skills = new List<Skill>();
            items = new List<Item>();
            equipment = new List<Equipment>();

            inventory = new List<InventorySlot>();

        }

        #region Setter

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetClass(string rpgclass)
        {
            this.rpgClass = rpgclass;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }

        public void SetMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }

        public void SetMana(int mana)
        {
            this.mana = mana;
        }

        public void SetMaxMana(int maxMana)
        {
            this.maxMana = maxMana;
        }

        public void SetStamina(int stamina)
        {
            this.stamina = stamina;
        }

        public void SetDefense(int defense)
        {
            this.defense = defense;
        }

        public void SetIntelligence(int intelligence)
        {
            this.intelligence = intelligence;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        public void SetExperience(int experience)
        {
            this.experience = experience;
        }

        public void SetGold(int amount)
        {
            this.gold = amount;
        }

        public void SetUsedSkill(bool state)
        {
            this.usedSkill = state;
        }

        public void SetStartStats()
        {
            gold = 0;
            UpdateStats();

            
            this.health = maxHealth;
            this.mana = maxMana;

            this.experience = 0;
            this.maxExperience = 90;
        }

        public void SetWeapon(Equipment weapon)
        {
            this.weapon = weapon;
        }

        public void SetHelmet(Equipment helmet)
        {
            this.helmet = null;
            this.helmet = helmet;
        }

        public void SetTorso(Equipment torso)
        {
            this.torso = null;
            this.torso = torso;
        }

        public void SetGloves(Equipment gloves)
        {
            this.gloves = null;
            this.gloves = gloves;
        }

        public void SetBoots(Equipment boots)
        {
            this.boots = null;
            this.boots = boots;
        }



        #endregion

        #region Getter

        public int GetStamina()
        {
            return stamina;
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

        public int GetExperience()
        {
            return experience;
        }

        public int GetMaxExperience()
        {
            return maxExperience;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public int GetMana()
        {
            return mana;
        }

        public int GetMaxMana()
        {
            return maxMana;
        }

        public Equipment GetWeapon()
        {
            return weapon;
        }

        public Equipment GetHelmet()
        {
            return helmet;
        }

        public Equipment GetTorso()
        {
            return torso;
        }

        public Equipment GetGloves()
        {
            return gloves;
        }

        public Equipment GetBoots()
        {
            return boots;
        }

        public List<Skill> GetSkills()
        {
            return skills;
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public List<Equipment> GetEquipment()
        {
            List<Equipment> _equipment = new List<Equipment>();

            _equipment.Add(GetHelmet());
            _equipment.Add(GetTorso());
            _equipment.Add(GetGloves());
            _equipment.Add(GetBoots());
            _equipment.Add(GetWeapon());

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetSlotType() == 2)
                {
                    Equipment eq = inventory[i].GetEquipment();

                    _equipment.Add(eq);
                }
            }


            return _equipment;
        }

        public int GetGold()
        {
            return gold;
        }

        public bool GetUsedSkill()
        {
            return usedSkill;
        }

        public List<InventorySlot> GetInventory()
        {
            return inventory;
        }

        public List<Item> GetConsumables()
        {
            List<Item> consumables = new List<Item>();

            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].GetSlotType() == 1)
                {
                    Item item = inventory[i].GetItem();

                    if (item.GetUseable())
                    {
                        consumables.Add(item);
                    }
                }
            }

            return consumables;
        }

        public List<Item> GetMaterials()
        {
            List<Item> materials = new List<Item>();

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetSlotType() == 3)
                {
                    Item item = inventory[i].GetOther();
                    materials.Add(item);
                }
            }

            return materials;
        }

        public int GetCrit()
        {
            return critChance;
        }

        public int GetFireRes()
        {
            return fireRes;
        }

        public int GetWaterRes()
        {
            return waterRes;
        }

        public int GetWindRes()
        {
            return windRes;
        }

        public int GetLightRes()
        {
            return lightRes;
        }

        public int GetDarkRes()
        {
            return darkRes;
        }

        public bool GetDidCrit()
        {
            return didCrit;
        }

        public ConsoleColor GetHPColor()
        {
            int low = maxHealth / 4;
            int half = maxHealth / 2;
            //Console.WriteLine("|| DEBUG | Health: {0} | Max Health: {1} | pHealth: {2:N1}", health, maxHealth, pHealth);
            
            if(health <= low)
            {
                return ConsoleColor.Red;
            }
            else if(health <= half)
            {
                return ConsoleColor.DarkYellow;
            }
            else
            {
                return ConsoleColor.Green;
            }
        }

        public int GetDamage()
        {
            if (weapon.GetElementType() != 1)
            {
                return (intelligence * 2) + (weapon.GetDamage() * 2);
            }
            else
            {
                return (strength * 2) + (weapon.GetDamage() * 2);
            }
        }

        public string GetClass()
        {
            return rpgClass;
        }
        #endregion

       

        #region Public Methods

        public void GainExperience(int xp)
        {
            this.experience += xp;
        }

        public bool LevelUp()
        {
            if(experience >= maxExperience)
            {
                this.experience = 0;
                this.level++;
                FullHeal();

                this.maxExperience = (90 * level);

                this.levelPoints++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChooseStat(string stat)
        {
            if(stat == "1")
            {
                staminaPoints++; ;
                this.maxHealth += 10;
            }

            if (stat == "2")
            {
                defensePoints++;
            }

            if (stat == "3")
            {
                strengthPoints++;
            }

            if (stat == "4")
            {
                intelligencePoints++;
                this.maxMana += 10;
            }

            if (stat == "5")
            {
                speedPoints++;
            }

            levelPoints--;
        }

        public int Attack()
        {
            if (CheckForCrit())
            {
                if(weapon.GetElementType() != 1)
                {
                    return (intelligence * 4) + (weapon.GetDamage() * 4);
                }
                else
                {
                    return (strength * 4) + (weapon.GetDamage() * 4);
                }
                
            }
            else
            {
                if(weapon.GetElementType() != 1)
                {
                    return (intelligence * 2) + (weapon.GetDamage() * 2);
                }
                else
                {
                    return (strength * 2) + (weapon.GetDamage() * 2);
                }
                
            }
            
            
        }

        public int UseSkill(int slot)
        {
            em.LoadEffects();
            usedSkill = true;
            Skill sk = skills[slot];
            mana -= sk.GetManaCost();

            if(sk.GetSkillType() == 1)
            {
                return sk.GetDamage() * ((int)strength / 2) + Attack();
            }
            else if(sk.GetSkillType() == 2)
            {
                return sk.GetDamage() * ((int)intelligence / 2) + Attack();
            }
            else if(sk.GetSkillType() == 3)
            {
                Effect ef = em.GetEffect(sk.GetEffectID());
                em.UseHeal(ef.GetEffectID(), this);
                Console.WriteLine(ef.GetUseText());

                return 0;
            }
            else
            {
                return 0;
            }

            
        }

        public int GetDamaged(int damage, string element)
        {
            if(element == "Fire")
            {
                if (damage > fireRes)
                {
                    health -= (damage - fireRes);
                    return (damage - fireRes);
                }
                else
                {
                    return 0;
                }
            }
            else if(element == "Water")
            {
                if (damage > waterRes)
                {
                    health -= (damage - waterRes);
                    return (damage - waterRes);
                }
                else
                {
                    return 0;
                }
            }
            else if (element == "Wind")
            {
                if (damage > windRes)
                {
                    health -= (damage - windRes);
                    return (damage - windRes);
                }
                else
                {
                    return 0;
                }
            }
            else if (element == "Light")
            {
                if (damage > lightRes)
                {
                    health -= (damage - lightRes);
                    return (damage - lightRes);
                }
                else
                {
                    return 0;
                }
            }
            else if (element == "Dark")
            {
                if (damage > darkRes)
                {
                    health -= (damage - darkRes);
                    return (damage - darkRes);
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
                    health -= (damage - defense);
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
            if(health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RefreshInventory()
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if(inventory[i].GetSlotType() == 1)
                {
                    Item item = inventory[i].GetItem();

                    if (item.GetAmount() <= 0)
                    {
                        inventory.RemoveAt(i);
                    }
                }
                
            }
        }

        public void AddSkill(Skill skill)
        {
            skills.Add(skill);
        }

        public void AddToInventory(Item item, int amount)
        {
            InventorySlot it = new InventorySlot();

            bool sameItem = false;

            if(inventory.Count <= 0)
            {
                item.SetAmount(amount);

                if (item.GetUseable())
                {
                    it.SetItem(item);
                }
                else
                {
                    it.SetOther(item);
                }

                inventory.Add(it);

            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].GetSlotType() == 1)
                    {
                        if (item.GetItemID() == inventory[i].GetItem().GetItemID())
                        {
                            item = inventory[i].GetItem();
                            sameItem = true;
                        }
                        
                    }
                }

                if (sameItem)
                {
                    item.SetAmount(item.GetAmount() + amount);
                }
                else
                {
                    item.SetAmount(amount);

                    if (item.GetUseable())
                    {
                        it.SetItem(item);
                    }
                    else
                    {
                        it.SetOther(item);
                    }

                    inventory.Add(it);
                }
            }
        }

        public void AddToInventory(Equipment eq)
        {
            InventorySlot it = new InventorySlot();

            it.SetEquipment(eq);

            inventory.Add(it);
        }

        public void RemoveFromInventory(int slot)
        {
            inventory.RemoveAt(slot);
        }

        public bool CheckForCrit()
        {
            Random random = new Random();
            int rng = random.Next(1, 100);

            if(rng <= critChance)
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

        public void UpdateStats()
        {
            int bonusStamina = weapon.GetStaminaBonus() + helmet.GetStaminaBonus() + torso.GetStaminaBonus() + gloves.GetStaminaBonus() + boots.GetStaminaBonus() + staminaPoints;
            int bonusDefense = weapon.GetDefenseBonus() + helmet.GetDefenseBonus() + torso.GetDefenseBonus() + gloves.GetDefenseBonus() + boots.GetDefenseBonus() + defensePoints;
            int bonusStrength = weapon.GetStrengthBonus() + helmet.GetStrengthBonus() + torso.GetStrengthBonus() + gloves.GetStrengthBonus() + boots.GetStrengthBonus() + strengthPoints;
            int bonusIntelligence = weapon.GetIntelligenceBonus() + helmet.GetIntelligenceBonus() + torso.GetIntelligenceBonus() + gloves.GetIntelligenceBonus() + boots.GetIntelligenceBonus() + intelligencePoints;
            int bonusSpeed = weapon.GetSpeedBonus() + helmet.GetSpeedBonus() + torso.GetSpeedBonus() + gloves.GetSpeedBonus() + boots.GetSpeedBonus() + speedPoints;

            int bonusFireRes = helmet.GetFireRes() + torso.GetFireRes() + gloves.GetFireRes() + boots.GetFireRes();
            int bonusWaterRes = helmet.GetWaterRes() + torso.GetWaterRes() + gloves.GetWaterRes() + boots.GetWaterRes();
            int bonusWindRes = helmet.GetWindRes() + torso.GetWindRes() + gloves.GetWindRes() + boots.GetWindRes();
            int bonusLightRes = helmet.GetLightRes() + torso.GetLightRes() + gloves.GetLightRes() + boots.GetLightRes();
            int bonusDarkRes = helmet.GetDarkRes() + torso.GetDarkRes() + gloves.GetDarkRes() + boots.GetDarkRes();

            if (rpgClass == "Knight")
            {
                this.stamina = 4 + bonusStamina;
                this.defense = 3 + bonusDefense;
                this.strength = 3 + bonusStrength;
                this.intelligence = 1 + bonusIntelligence;
                this.speed = 2 + bonusSpeed;

                this.maxHealth = 100 + (stamina * 10);
                this.maxMana = 50 + (intelligence * 10);
                this.critChance = 0 + weapon.GetCritChance();
            }
            else if(rpgClass == "Assassin")
            {
                this.stamina = 3 + bonusStamina;
                this.defense = 2 + bonusDefense; 
                this.strength = 4 + bonusStrength;
                this.intelligence = 2 + bonusIntelligence;
                this.speed = 4 + bonusSpeed;

                this.maxHealth = 80 + (stamina * 10);
                this.maxMana = 50 + (intelligence * 10);
                this.critChance = 25 + weapon.GetCritChance();
            }
            else if (rpgClass == "Archer")
            {
                this.stamina = 2 + bonusStamina;
                this.defense = 1 + bonusDefense;
                this.strength = 3 + bonusDefense;
                this.intelligence = 1 + bonusIntelligence;
                this.speed = 5 + bonusSpeed;

                this.maxHealth = 75 + (stamina * 10);
                this.maxMana = 50 + (intelligence * 10);
                this.critChance = 20 + weapon.GetCritChance();
            }
            else if (rpgClass == "Mage")
            {
                this.stamina = 2 + bonusStamina;
                this.defense = 1 + bonusDefense;
                this.strength = 1 + bonusStrength;
                this.intelligence = 5 + bonusIntelligence;
                this.speed = 3 + bonusSpeed;

                this.maxHealth = 60 + (stamina * 10);
                this.maxMana = 100 + (intelligence * 10);
                this.critChance = 5 + weapon.GetCritChance();
            }

            fireRes = bonusFireRes;
            waterRes = bonusWaterRes;
            windRes = bonusWindRes;
            lightRes = bonusLightRes;
            darkRes = bonusDarkRes;

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public void AddHealth(int amount)
        {
            if(health <= (maxHealth - amount))
            {
                health += amount;
            }
            else
            {
                health = maxHealth;
            }

            
        }

        public void AddMana(int amount)
        {
            if (mana <= (maxMana - amount))
            {
                mana += amount;
            }
            else
            {
                mana = maxMana;
            }
        }

        public void AddGold(int amount)
        {
            gold += amount;
        }

        public int GetAmountInInventory(Item item)
        {
            int amount = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                InventorySlot slot = inventory[i];
                if(slot.GetSlotType() == 1)
                {
                    if(slot.GetItem().GetItemID() == item.GetItemID())
                    {
                        amount = slot.GetItem().GetAmount();
                    }
                }
                else if(slot.GetSlotType() == 3)
                {
                    if(slot.GetOther().GetItemID() == item.GetItemID())
                    {
                        amount = slot.GetOther().GetAmount();
                    }
                }
                else
                {
                    amount = 0;
                }
            }

            return amount;  
        }

        public int GetAmountInInventory(Equipment eq)
        {
            int amount = 0;
            for (int i = 0; i < inventory.Count; i++)
            {
                InventorySlot slot = inventory[i];
                if (slot.GetSlotType() == 2)
                {
                    if (slot.GetEquipment().GetItemID() == eq.GetItemID())
                    {
                        amount = 1;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
            }

            return amount;
        }

        public void SetStartEquipment(EquipmentManager eq, ItemManager im, SkillManager sm)
        {
            switch (GetClass())
            {
                case "Knight":
                    SetWeapon(eq.GetEquipment(401));
                    SetHelmet(eq.GetEquipment(1));
                    SetTorso(eq.GetEquipment(101));
                    SetGloves(eq.GetEquipment(201));
                    SetBoots(eq.GetEquipment(301));

                    AddSkill(sm.GetSkill(101));
                    break;

                case "Assassin":
                    SetWeapon(eq.GetEquipment(402));
                    SetHelmet(eq.GetEquipment(2));             
                    SetTorso(eq.GetEquipment(102));
                    SetGloves(eq.GetEquipment(202));
                    SetBoots(eq.GetEquipment(302));

                    AddSkill(sm.GetSkill(102));
                    break;

                case "Archer":
                    SetWeapon(eq.GetEquipment(403));
                    SetHelmet(eq.GetEquipment(3));
                    SetTorso(eq.GetEquipment(102));
                    SetGloves(eq.GetEquipment(202));
                    SetBoots(eq.GetEquipment(302));

                    AddSkill(sm.GetSkill(103));
                    break;

                case "Mage":
                    SetWeapon(eq.GetEquipment(404));
                    SetHelmet(eq.GetEquipment(4));
                    SetTorso(eq.GetEquipment(103));
                    SetGloves(eq.GetEquipment(203));
                    SetBoots(eq.GetEquipment(303));

                    AddSkill(sm.GetSkill(1));
                    break;
            }

            GetWeapon().SetIsEquipped(true);
            GetHelmet().SetIsEquipped(true);
            GetTorso().SetIsEquipped(true);
            GetGloves().SetIsEquipped(true);
            GetBoots().SetIsEquipped(true);

            AddToInventory(im.GetItem(1), 5);
            AddToInventory(im.GetItem(2), 5);

        }

        public void FullHeal()
        {
            health = maxHealth;
            mana = maxMana;
        }

        public void CheckForNewSkills(SkillManager sm)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            switch (GetClass())
            {
                case "Knight":
                    dic = sm.GetKnightSkills();
                    if (dic.ContainsKey(level))
                    {
                        Skill sk = sm.GetSkill(dic[level]);
                        AddSkill(sk);
                        Console.WriteLine("|| You've learned {0}!", sk.GetName());
                    }
                    break;
            }
        }
        #endregion


    }
}
