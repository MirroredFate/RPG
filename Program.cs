using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {

        const string border = "||-----------------------------------------------------------";

        static void Main(string[] args)
        {
            Player player = new Player();
            EquipmentManager equipmentManager = new EquipmentManager();
            UpgradeManager upgradeManager = new UpgradeManager();
            EnemyManager enemyManager = new EnemyManager();
            SkillManager skillManager = new SkillManager();
            ItemManager itemManager = new ItemManager();
            DungeonManager dungeonManager = new DungeonManager();
            List<Enemy> enemies = new List<Enemy>();
            List<Item> items = new List<Item>();
            Shop shop = new Shop();
            Enemy randomEnemy;

            equipmentManager.LoadEquipment();
            enemyManager.LoadEnemies(skillManager, itemManager);
            skillManager.LoadSkills();
            itemManager.LoadItems();

            Welcome();

            #region Intro Sequence

            void Welcome()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||     WELCOME TO PROJECT RPG            ");
                Console.WriteLine(border);
                Console.WriteLine("||                                  ");

                NameSequence();
                ClassSequence();

                Console.WriteLine("||                                  ");
                Console.WriteLine("|| Setting Stats...         ");
                player.SetStartEquipment(equipmentManager, itemManager, skillManager);
                player.SetStartStats();
                Console.WriteLine("|| Done!              ");
                Console.WriteLine(border);

                Console.WriteLine("|| Then Welcome to the World...   ");
                Console.WriteLine("|| {0}, the  {1}       ", player.name, player.rpgClass);
                Console.WriteLine(border);
                Console.WriteLine("|| Press Enter to continue     ");
                Console.WriteLine(border);

                Console.ReadLine();

                
                MainMenu();

            }

            void NameSequence()
            {
                Console.WriteLine("|| What is your name?        ");
                Console.WriteLine("||                                  ");
                Console.WriteLine(border);

                player.SetName(Console.ReadLine());

                Console.WriteLine(border);
                Console.WriteLine("|| So your name is {0}?   ", player.name);
                Console.WriteLine(border);
                Console.WriteLine("|| [1]Yes      |     [2]No      ");
                Console.WriteLine(border);


                if (Console.ReadLine().Contains("1"))
                {
                    Console.WriteLine("||                                  ");
                    Console.WriteLine("|| Good!               ");
                    Console.WriteLine("||                                  ");
                }
                else
                {
                    NameSequence();
                }
            }

            void ClassSequence()
            {
                ClassSelect:
                Console.Clear();
                Console.WriteLine("||                                  ");
                Console.WriteLine("|| What Class will you choose?    ");
                Console.WriteLine(border);
                Console.WriteLine("|| [1]Knight              ");
                Console.WriteLine(border);
                Console.WriteLine("|| [2]Assassin             ");
                Console.WriteLine(border);
                Console.WriteLine("|| [3]Archer              ");
                Console.WriteLine(border);
                Console.WriteLine("|| [4]Mage               ");
                Console.WriteLine(border);

                string input = Console.ReadLine();

                if(input == "1")
                {
                    Console.WriteLine("|| The Knight, slow but deadly. Has the highest physical protection");
                    Console.WriteLine(border);
                    Console.WriteLine("|| Do you want to be a Knight?");
                    Console.WriteLine("|| [1] Yes | [2] No");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        player.SetClass("Knight");
                        Console.WriteLine("|| Very well then...");
                        Console.WriteLine(border);
                    }
                    else
                    {
                        goto ClassSelect;
                    }
                 
                }
                else if(input == "2")
                {
                    Console.WriteLine("|| The Assassin, one of the deadliest classes but also one of the weakest. Has a high critical strike chance");
                    Console.WriteLine(border);
                    Console.WriteLine("|| Do you want to be an Assassin?");
                    Console.WriteLine("|| [1] Yes | [2] No");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        player.SetClass("Assassin");
                        Console.WriteLine("|| Very well then...");
                        Console.WriteLine(border);
                    }
                    else
                    {
                        goto ClassSelect;
                    }
                    
                }
                else if(input == "3")
                {
                    Console.WriteLine("|| The Archer, fast and accurate. Has the highest Speed");
                    Console.WriteLine(border);
                    Console.WriteLine("|| Do you want to be an Archer?");
                    Console.WriteLine("|| [1] Yes | [2] No");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        player.SetClass("Archer");
                        Console.WriteLine("|| Very well then...");
                        Console.WriteLine(border);
                    }
                    else
                    {
                        goto ClassSelect;
                    }
                    
                }
                else if(input == "4")
                {
                    Console.WriteLine("|| The Mage, deals heavy magic damage. Has the highest Intelligence");
                    Console.WriteLine(border);
                    Console.WriteLine("|| Do you want to be a Mage?");
                    Console.WriteLine("|| [1] Yes | [2] No");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        player.SetClass("Mage");
                        Console.WriteLine("|| Very well then...");
                        Console.WriteLine(border);
                    }
                    else
                    {
                        goto ClassSelect;
                    }
                }
                else
                {
                    Console.WriteLine("||                                  ");
                    Console.WriteLine("|| Pls enter a number from 1 to 4  ");
                    Console.WriteLine("||                                  ");
                    Console.ReadLine();

                    ClassSequence();
                }
            }

            #endregion

            #region Menues

            void MainMenu()
            {
                Console.Clear();
                player.UpdateStats();
                enemies = enemyManager.GetEnemyList();

                Console.WriteLine(border);
                Console.WriteLine("||           MAIN MENU              ");
                Console.WriteLine(border);
                Console.WriteLine("||                                  ");
                Console.WriteLine("|| [1] Fight Random Enemy         ");
                Console.WriteLine("|| [2] Shop");
                Console.WriteLine("|| [3] Smith");
                Console.WriteLine("||                                  ");
                Console.WriteLine("|| [4] Show Equipment         ");
                Console.WriteLine("|| [5] Show Stats             ");
                Console.WriteLine("|| [6] Show Skills             ");
                Console.WriteLine("|| [7] Show Inventory             ");
                Console.WriteLine("||                                  ");
                Console.WriteLine("|| [X] Close Game             ");
                Console.WriteLine("||                                  ");
                Console.WriteLine(border);

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Random rng = new Random();
                        int random = rng.Next(0, enemies.Count);
                        randomEnemy = enemies[random];

                        FightEnemyMenu();
                        break;
                    case "2":
                        ShopMenu();
                        break;
                    case "3":
                        UpgradeMenu();
                        break;
                    case "4":
                        EquipmentMenu();
                        break;
                    case "5":
                        StatMenu();
                        break;
                    case "6":
                        SkillMenu();
                        break;
                    case "7":
                        InventoryMenu();
                        break;
                    case "g":
                        int gold = 99999;
                        player.AddGold(gold);
                        Console.WriteLine("|| {0} Gold added!", gold);
                        Console.ReadLine();
                        MainMenu();
                        break;
                    case "x":
                        Environment.Exit(0);
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        MainMenu();
                        break;
                }
            }

            void EquipmentMenu()
            {
                Equipment pHelmet = player.GetHelmet();
                Equipment pTorso = player.GetTorso();
                Equipment pGloves = player.GetGloves();
                Equipment pBoots = player.GetBoots();
                Equipment pWeapon = player.GetWeapon();

                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("|| EQUIPMENT");
                Console.WriteLine(border);
                Console.WriteLine("|| ARMOR");
                Console.WriteLine(String.Format("|| {0,-10} {1,-20} {2}", "[1]Helmet:",pHelmet.GetName(), pHelmet.GetElementText()));
                Console.WriteLine(String.Format("|| {0,-10} {1,-20} {2}", "[2]Torso:",pTorso.GetName(), pTorso.GetElementText()));
                Console.WriteLine(String.Format("|| {0,-10} {1,-20} {2}", "[3]Gloves:",pGloves.GetName(), pGloves.GetElementText()));
                Console.WriteLine(String.Format("|| {0,-10} {1,-20} {2}", "[4]Boots:",pBoots.GetName(), pBoots.GetElementText()));
                Console.WriteLine(border);
                Console.WriteLine("|| WEAPON");
                Console.WriteLine(String.Format("|| {0,-10} {1,-20} {2}", "[5]Weapon:",pWeapon.GetName(), pWeapon.GetElementText()));
                Console.WriteLine(border);
                Console.WriteLine("|| Press Enter to return to the Main Menu ");
                Console.WriteLine("|| or insert keys 1-5 for equipment info ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetEquipmentInfo(pHelmet);
                        break;
                    case "2":
                        GetEquipmentInfo(pTorso);
                        break;
                    case "3":
                        GetEquipmentInfo(pGloves);
                        break;
                    case "4":
                        GetEquipmentInfo(pBoots);
                        break;
                    case "5":
                        GetEquipmentInfo(pWeapon);
                        break;
                    case "":
                        MainMenu();
                        break;
                    default:
                        EquipmentMenu();
                        break;
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Press Enter to return to your Equipment");

                Console.ReadLine();
                EquipmentMenu();

            }

            void StatMenu()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||              STATS             ");
                Console.WriteLine(border);
                Console.WriteLine("|| {0}, the {1}", player.name, player.rpgClass);
                Console.WriteLine(border);
                Console.WriteLine("|| Health:    {0} / {1}   ", player.GetHealth(), player.GetMaxHealth());
                Console.WriteLine("|| Mana:    {0} / {1}   ", player.GetMana(), player.GetMaxMana());
                Console.WriteLine(border);
                Console.WriteLine("|| Level:   {0}", player.level);
                Console.WriteLine("|| Experience:  {0} / {1}", player.GetExperience(), player.GetMaxExperience());
                Console.WriteLine(border);
                Console.WriteLine(String.Format("|| {0,-26}{1}%", "Critical Strike Chance:", player.GetCrit()));
                Console.WriteLine(String.Format("|| {0,-26}{1}", "Damage:", player.GetDamage()));
                Console.WriteLine(border);
                Console.WriteLine(String.Format("|| [1] {0,-22}{1}","Stamina:", player.GetStamina()));
                Console.WriteLine(String.Format("|| [2] {0,-22}{1}","Defense:", player.GetDefense()));
                Console.WriteLine(String.Format("|| [3] {0,-22}{1}","Strength:", player.GetStrength()));
                Console.WriteLine(String.Format("|| [4] {0,-22}{1}","Intelligence:", player.GetIntelligence()));
                Console.WriteLine(String.Format("|| [5] {0,-22}{1}","Speed:", player.GetSpeed()));
                Console.WriteLine(border);
                Console.WriteLine(String.Format("|| [6] {0,-22}{1}","Fire Resistance:", player.GetFireRes()));
                Console.WriteLine(String.Format("|| [7] {0,-22}{1}","Water Resistance:",player.GetWaterRes()));
                Console.WriteLine(String.Format("|| [8] {0,-22}{1}","Wind Resistance:",player.GetWindRes()));
                Console.WriteLine(String.Format("|| [9] {0,-22}{1}","Light Resistance:",player.GetLightRes()));
                Console.WriteLine(String.Format("|| [10]{0,-22}{1}","Dark Resistance:",player.GetDarkRes()));
                Console.WriteLine(border);
                Console.WriteLine("|| Press keys 1 - 10 for more information");
                Console.WriteLine("|| or press Enter to return to the Main Menu ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Stamina increases your Maximum Health!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "2":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Defense reduces normal damage taken!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "3":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Strength increases your physical damage!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "4":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Intelligence increases your elemental damage and your Maximum Mana!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "5":
                        Console.WriteLine(border);
                        Console.WriteLine("|| If you have more Speed than your enemy, you attack first!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "6":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Fire Resistance reduces damage taken by fire type attacks!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "7":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Water Resistance reduces damage taken by water type attacks!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "8":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Wind Resistance reduces damage taken by wind type attacks!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "9":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Light Resistance reduces damage taken by light type attacks!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "10":
                        Console.WriteLine(border);
                        Console.WriteLine("|| Dark Resistance reduces damage taken by dark type attacks!");
                        Console.WriteLine(border);
                        Console.ReadLine();
                        StatMenu();
                        break;
                    case "":
                        MainMenu();
                        break;
                    default:
                        StatMenu();
                        break;
                }
            }

            void FightEnemyMenu()
            {
                if (!randomEnemy.IsDead())
                {
                    Console.Clear();
                    Console.WriteLine(border);
                    Console.WriteLine("||         FIGHTING ENEMY           ");
                    Console.WriteLine(border);

                    Console.WriteLine("|| {0} appears!", randomEnemy.GetName());
                    Console.WriteLine(border);
                    Console.Write("|| Element: ");
                    Console.ForegroundColor = randomEnemy.GetElementColor();
                    Console.Write("{0}", randomEnemy.GetElementText());
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.WriteLine(border);
                    Console.WriteLine("|| Enemy HP : {0} / {1}", randomEnemy.GetHP(), randomEnemy.GetMaxHP());

                    if (randomEnemy.GetEnemyType() == 2)
                    {
                        Console.WriteLine("|| Enemy Mana : {0} / {1}", randomEnemy.GetMana(), randomEnemy.GetMaxMana());
                    }

                    Console.WriteLine(border);
                    Console.Write("|| Player HP: ");
                    Console.ForegroundColor = player.GetHPColor();
                    Console.Write("{0} / {1}", player.GetHealth() ,player.GetMaxHealth());
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.WriteLine("|| Player Mana: {0} / {1}   ", player.GetMana(), player.GetMaxMana());
                    Console.WriteLine(border);
                    Console.WriteLine("|| What will you do?");
                    Console.WriteLine("|| [1] Attack");
                    Console.WriteLine("|| [2] Use Skill");
                    Console.WriteLine("|| [3] Use Item");
                    Console.WriteLine(border);

                    string input = Console.ReadLine();
                    int slot;

                    if (Int32.TryParse(input, out slot))
                    {
                        slot = Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Pls enter a valid number!");
                        Console.ReadLine();
                        FightEnemyMenu();
                    }
                    if (input == "1")
                    {
                        if (player.GetSpeed() > randomEnemy.GetSpeed())
                        {
                            Attack(player.Attack(), 1, null);
                            if (!randomEnemy.IsDead())
                            {
                                EnemyAttack();
                                if (player.IsDead()) GameOver();
                            }

                            Console.WriteLine("|| Press Enter to Continue");

                            Console.ReadLine();
                            FightEnemyMenu();
                        }
                        else
                        {
                            if (!randomEnemy.IsDead())
                            {
                                EnemyAttack();
                                if (player.IsDead()) GameOver();
                            } 
                            Attack(player.Attack(), 1, null);

                            Console.WriteLine("|| Press Enter to Continue");

                            Console.ReadLine();
                            FightEnemyMenu();
                        }
                    }
                    else if (input == "2")
                    {
                        ChooseSkill();
                    }
                    else if (input == "3")
                    {
                        ChooseItem();
                    }
                    else if (input == "9")
                    {
                        Attack(99999, 1, null);
                        Console.WriteLine("|| Press Enter to Continue");

                        Console.ReadLine();
                        FightEnemyMenu();
                    }
                    else
                    {
                        Console.WriteLine("|| Pls enter a Valid number.");
                        FightEnemyMenu();
                    }

                }
                else
                {
                    Console.Clear();
                    if (randomEnemy.GetKillCount() <= 0)
                    {
                        Console.WriteLine(border);
                        Console.WriteLine("||            VICTORY          ");
                        Console.WriteLine(border);

                        randomEnemy.SetKillCount(randomEnemy.GetKillCount() + 1);
                        player.GainExperience(randomEnemy.GetXP());
                        player.SetGold(player.GetGold() + randomEnemy.GetGold());

                        Console.WriteLine("|| You got {0} Gold!", randomEnemy.GetGold());
                        Console.WriteLine("|| You got {0} Experience!", randomEnemy.GetXP());
                        if (randomEnemy.ItemDropped())
                        {
                            Item it = randomEnemy.GetDroppedItem();
                            player.AddToInventory(it, it.GetAmount());
                            Console.WriteLine("|| You got {0}x {1}!", it.GetAmount(), it.GetName());
                        }
                        if (player.LevelUp())
                        {
                            Console.WriteLine(border);
                            Console.WriteLine("|| You leveled up!");
                            Console.WriteLine("|| You are now Level {0} !", player.level);
                            CheckForNewSkills();
                            Console.WriteLine("|| Choose a Stat to Level up!");
                            Console.WriteLine(border);

                            string stam = "Increases your Max HP";
                            string def = "Reduces normal damage taken";
                            string str = "Increases physical damage dealt";
                            string inte = "Increases elemental damage dealt and your maximum Mana";
                            string spd = "If you have more speed than your enemy, you attack first";

                            Console.WriteLine("|| [1] Stamina - {0,10}", stam);
                            Console.WriteLine("|| [2] Defense  - {0,10}", def);
                            Console.WriteLine("|| [3] Strength  - {0,10}", str);
                            Console.WriteLine("|| [4] Intelligence  - {0,10}", inte);
                            Console.WriteLine("|| [5] Speed  - {0,10}", spd);
                            Console.WriteLine(border);
                            
                            LevelUp:
                            string input = Console.ReadLine();
                            if (input == "1")
                            {
                                Console.WriteLine("|| Stamina increased by 1. Max Health increased!");
                                player.ChooseStat(input);
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("|| Defense increased by 1!");
                                player.ChooseStat(input);
                            }
                            else if (input == "3")
                            {
                                Console.WriteLine("|| Strength increased by 1!");
                                player.ChooseStat(input);
                            }
                            else if (input == "4")
                            {
                                Console.WriteLine("|| Intelligence increased by 1. Max Mana increased!");
                                player.ChooseStat(input);
                            }
                            else if (input == "5")
                            {
                                Console.WriteLine("|| Speed increased by 1.");
                                player.ChooseStat(input);
                            }
                            else
                            {
                                goto LevelUp;
                            }
                        }

                        Console.WriteLine(border);
                        Console.WriteLine("|| Press Enter to return to the Main Menu");
                        
                    }
                    else
                    {
                        Console.WriteLine(border);
                        Console.WriteLine("|| No enemies are nearby...");
                        Console.WriteLine(border);
                        Console.WriteLine("|| Press Enter to return to the Main Menu");
                        
                    }

                    enemyManager.LoadEnemies(skillManager, itemManager);
                    Console.ReadLine();
                    MainMenu();

                }
            }

            void SkillMenu()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||                SKILLS");
                Console.WriteLine(border);
                for (int i = 0; i < player.GetSkills().Count; i++)
                {
                    string name = player.GetSkills()[i].GetName();
                    string level = player.GetSkills()[i].GetLevelText();
                    int damage = player.GetSkills()[i].GetDamage();
                    int manaCost = player.GetSkills()[i].GetManaCost();

                    Console.WriteLine("|| {0}{1} | Base Damage: {2} | Mana: {3}", name, level, damage, manaCost);
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Press Enter to return to the Main Menu");

                Console.ReadLine();
                MainMenu();
            }

            void InventoryMenu()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||                INVENTORY");
                Console.WriteLine(border);

                

                for (int i = 0; i < player.GetInventory().Count; i++)
                {
                    if(player.GetInventory()[i].GetSlotType() == 1)
                    {
                        Item item = player.GetInventory()[i].GetItem();

                        Console.WriteLine("|| [{0}] {1} | x{2}",i + 1, item.GetName(), item.GetAmount());
                        Console.WriteLine("||--------------------------------------");
                    }

                    if (player.GetInventory()[i].GetSlotType() == 2)
                    {
                        Equipment item = player.GetInventory()[i].GetEquipment();

                        Console.WriteLine("|| [{0}] {1} | {2} | ", i + 1, item.GetName(), item.GetElementText());
                        Console.WriteLine("||--------------------------------------");
                    }

                    if (player.GetInventory()[i].GetSlotType() == 3)
                    {
                        Item item = player.GetInventory()[i].GetOther();

                        Console.WriteLine("|| [{0}] {1} | x{2}", i + 1, item.GetName(), item.GetAmount());
                        Console.WriteLine("||--------------------------------------");
                    }

                }
                Console.WriteLine("|| Gold: {0}", player.GetGold());
                Console.WriteLine("||--------------------------------------");
                Console.WriteLine("|| Choose an Item by typing the Number of the Item you want to use / equip.");
                Console.WriteLine("|| or press Enter to return to the Main Menu");

                string input = Console.ReadLine();
                int slot;
                if(input == "")
                {
                    MainMenu();
                }
                else
                {
                    if (Int32.TryParse(input, out slot))
                    {
                        slot = Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Pls enter a valid number!");
                        Console.ReadLine();
                        InventoryMenu();
                    }
                    if (player.GetInventory()[slot - 1].GetSlotType() == 1)
                    {
                        Item item = player.GetInventory()[slot - 1].GetItem();

                        Console.WriteLine("||--------------------------------------");
                        Console.WriteLine("|| {0} | {1}", item.GetName(), item.GetDescription());
                        Console.WriteLine("||--------------------------------------");
                        Console.WriteLine("|| Do you want to use it?");
                        Console.WriteLine("|| ");
                        Console.WriteLine("||   [1] Yes  |  [2] No");
                        Console.WriteLine("||--------------------------------------");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            itemManager.UseItem(item, player);
                            Console.WriteLine("||--------------------------------------");
                        }
                        else
                        {
                            InventoryMenu();
                        }
                    }
                    else if(player.GetInventory()[slot - 1].GetSlotType() == 2)
                    {
                        Equipment item = player.GetInventory()[slot - 1].GetEquipment();

                        Console.WriteLine("||--------------------------------------");
                        GetEquipmentInfo(item);
                        Console.WriteLine("||--------------------------------------");
                        Console.WriteLine("|| Do you want to equip it?");
                        Console.WriteLine("|| ");
                        Console.WriteLine("||   [1] Yes  |  [2] No");
                        Console.WriteLine("||--------------------------------------");
                        string choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            equipmentManager.EquipEquipment(item, player, slot - 1);

                            Console.WriteLine("||--------------------------------------");
                        }
                        else
                        {
                            InventoryMenu();
                        }
                    }
                    else if(player.GetInventory()[slot - 1].GetSlotType() == 3)
                    {
                        Item item = player.GetInventory()[slot - 1].GetOther();

                        Console.WriteLine("||--------------------------------------");
                        Console.WriteLine("|| {0} | {1}", item.GetName(), item.GetDescription());
                        Console.WriteLine("||--------------------------------------");
                    }

                }

                Console.WriteLine("|| Press Enter to continue");
                Console.ReadLine();

                InventoryMenu();
            }

            void ShopMenu()
            {
                Console.Clear();

                shop.LoadShop();
                List<Item> shopConsumables = shop.GetShopConsumables();
                List<Item> shopOther = shop.GetShopOther();
                List<Equipment> shopEquipment = shop.GetShopEquipment();
                
                
                Console.WriteLine(border);
                Console.WriteLine("||                SHOP");
                Console.WriteLine(border);
                Console.WriteLine("||");
                Console.WriteLine("|| [1] Consumables");
                Console.WriteLine("|| [2] Equipment");
                Console.WriteLine("|| [3] Other Items");
                Console.WriteLine("||");
                Console.WriteLine(border);
                Console.WriteLine(border);
                Console.WriteLine("|| Choose a Category by typing the number 1 - 3");
                Console.WriteLine("|| or press Enter to return to the Main Menu");

                string input = Console.ReadLine();
                if(input == "")
                {
                    MainMenu();
                    
                }
                else if(input == "1")
                {
                    ShopConsumables(shopConsumables);

                }
                else if(input == "2")
                {
                    ShopEquipment(shopEquipment);

                }
                else if(input == "3")
                {
                    ShopOther(shopOther);

                }
                else
                {
                    ShopMenu();
                }

            }

            void UpgradeMenu()
            {
                UpgradeMenu:
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("|| SMITH ");
                Console.WriteLine(border);
                Console.WriteLine("|| Which equipment do you want to Upgrade?");
                Console.WriteLine(border);
                for (int i = 0; i < player.GetEquipment().Count; i++)
                {
                    string name = player.GetEquipment()[i].GetName();
                    string element = player.GetEquipment()[i].GetElementText();
                    string equipped = player.GetEquipment()[i].GetIsEquippedText();
                    Console.WriteLine(String.Format("|| [{0}] {1,-20} {2,-10} {3}", i + 1, name, element, equipped));
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Type in the Number of the Item you want to upgrade!");
                Console.WriteLine("|| Or press enter to return to the Main Menu");
                Console.WriteLine(border);
                string input = Console.ReadLine();
                int itemSlot;

                if (input == "")
                {
                    MainMenu();
                }

                if (Int32.TryParse(input, out itemSlot))
                {
                    itemSlot = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto UpgradeMenu;
                }
                UpgradeChoice:
                if(player.GetEquipment()[itemSlot - 1].GetLevel() < 9)
                {
                    GetUpgradeInfo(player.GetEquipment()[itemSlot - 1]);
                    Console.WriteLine(border);
                    List<Item> reqMat = upgradeManager.GetRequiredMaterials(player.GetEquipment()[itemSlot - 1]);
                    List<Item> playerMat = new List<Item>();
                    for (int i = 0; i < player.GetInventory().Count; i++)
                    {
                        InventorySlot slot = player.GetInventory()[i];
                        if (slot.GetSlotType() == 3)
                        {
                            playerMat.Add(slot.GetOther());
                        }
                    }
                    Console.WriteLine("|| Required Materials:");
                    Console.WriteLine(border);
                    for (int i = 0; i < reqMat.Count; i++)
                    {
                        string name = reqMat[i].GetName();
                        int amount = reqMat[i].GetAmount();
                        int playerAmount = 0;
                        for (int j = 0; j < playerMat.Count; j++)
                        {
                            if (reqMat[i].GetName() == playerMat[j].GetName())
                            {
                                Item mat = playerMat[j];
                                playerAmount = mat.GetAmount();
                            }
                        }
                        Console.WriteLine("|| {0}: {1}/{2}", name, playerAmount, amount);
                    }
                    Console.WriteLine(border);
                    Console.WriteLine("|| Want to upgrade?");
                    Console.WriteLine("|| [1] Yes | [2] No");
                    Console.WriteLine(border);
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        if (upgradeManager.CheckMats(reqMat, playerMat))
                        {
                            upgradeManager.Upgrade(player.GetEquipment()[itemSlot - 1], player);
                            upgradeManager.DeleteMats(reqMat, player.GetMaterials());
                            Console.WriteLine("|| Here you go!");
                            Console.ReadLine();
                            goto UpgradeChoice;
                        }
                        else
                        {
                            Console.WriteLine("|| You don't have enough Materials!");
                            Console.ReadLine();
                            goto UpgradeMenu;
                        }
                    }
                    else
                    {
                        goto UpgradeMenu;
                    }
                }
                else
                {
                    GetEquipmentInfo(player.GetEquipment()[itemSlot - 1]);
                    Console.WriteLine(border);
                    Console.WriteLine("|| I can't upgrade it anymore! (max level)");
                    Console.ReadLine();
                    goto UpgradeMenu;
                }
                

            }

            #endregion

            #region Information Methods

            void GetEquipmentInfo(Equipment eq)
            {
                Console.WriteLine(border);
                Console.WriteLine("|| {0} {1}", eq.GetName(), eq.GetElementText());
                Console.WriteLine(border);
                Console.WriteLine("|| {0}", eq.description);
                Console.WriteLine(border);

                if(eq.GetEquipmentType() == 1)
                {
                    Console.WriteLine("|| Damage: {0}", eq.GetDamage());
                }
                if(eq.GetStaminaBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Stamina", eq.GetStaminaBonus());
                }
                if (eq.GetDefenseBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Defense", eq.GetDefenseBonus());
                }
                if (eq.GetStrengthBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Strength", eq.GetStrengthBonus());
                }
                if (eq.GetIntelligenceBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Intelligence", eq.GetIntelligenceBonus());
                }
                if (eq.GetSpeedBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Speed", eq.GetSpeedBonus());
                }
                if (eq.GetFireRes() > 0)
                {
                    Console.WriteLine("|| +{0} Fire Resistance", eq.GetFireRes());
                }
                if (eq.GetWaterRes() > 0)
                {
                    Console.WriteLine("|| +{0} Water Resistance", eq.GetWaterRes());
                }
                if (eq.GetWindRes() > 0)
                {
                    Console.WriteLine("|| +{0} Wind Resistance", eq.GetWindRes());
                }
                if (eq.GetLightRes() > 0)
                {
                    Console.WriteLine("|| +{0} Light Resistance", eq.GetLightRes());
                }
                if (eq.GetDarkRes() > 0)
                {
                    Console.WriteLine("|| +{0} Dark Resistance", eq.GetDarkRes());
                }


            }

            void GetUpgradeInfo(Equipment eq)
            {
                int newLevel = eq.GetLevel() + 1;
                string newLevelText = "+" + newLevel;

                int levelBonus = newLevel * 2;

                int newDamage = eq.GetDamage() + (levelBonus);
                int newStamina = eq.GetStaminaBonus() + (levelBonus);
                int newDefense = eq.GetDefenseBonus() + (levelBonus);
                int newStrength = eq.GetStrengthBonus() + (levelBonus);
                int newIntelligence = eq.GetIntelligenceBonus() + (levelBonus);
                int newSpeed = eq.GetSpeedBonus() + (levelBonus);
                int newFireRes = eq.GetFireRes() + (levelBonus);
                int newWaterRes = eq.GetWaterRes() + (levelBonus);
                int newWindRes = eq.GetWindRes() + (levelBonus);
                int newLightRes = eq.GetLightRes() + (levelBonus);
                int newDarkRes = eq.GetDarkRes() + (levelBonus);

                Console.WriteLine(border);
                Console.WriteLine("|| {0} {1} -> {2} {3} {4}", eq.GetName(), eq.GetElementText(), eq.name, newLevelText, eq.GetElementText());
                Console.WriteLine(border);
                Console.WriteLine("|| {0}", eq.description);
                Console.WriteLine(border);

                if (eq.GetEquipmentType() == 1)
                {
                    Console.WriteLine("|| Damage: {0} | -> Damage: {1}", eq.GetDamage(), newDamage);
                }
                if (eq.GetStaminaBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Stamina | -> +{1} Stamina", eq.GetStaminaBonus(), newStamina);
                }
                if (eq.GetDefenseBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Defense | -> +{1} Defense", eq.GetDefenseBonus(), newDefense);
                }
                if (eq.GetStrengthBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Strength | -> +{1} Strength", eq.GetStrengthBonus(), newStrength);
                }
                if (eq.GetIntelligenceBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Intelligence | -> +{1} Intelligence", eq.GetIntelligenceBonus(), newIntelligence);
                }
                if (eq.GetSpeedBonus() > 0)
                {
                    Console.WriteLine("|| +{0} Speed | -> +{1} Speed", eq.GetSpeedBonus(), newSpeed);
                }
                if (eq.GetFireRes() > 0)
                {
                    Console.WriteLine("|| +{0} Fire Resistance | -> +{1} Fire Resistance", eq.GetFireRes(), newFireRes);
                }
                if (eq.GetWaterRes() > 0)
                {
                    Console.WriteLine("|| +{0} Water Resistance | -> +{1} Water Resistance", eq.GetWaterRes(), newWaterRes);
                }
                if (eq.GetWindRes() > 0)
                {
                    Console.WriteLine("|| +{0} Wind Resistance | -> +{1} Wind Resistance", eq.GetWindRes(), newWindRes);
                }
                if (eq.GetLightRes() > 0)
                {
                    Console.WriteLine("|| +{0} Light Resistance | -> +{1} Light Resistance", eq.GetLightRes(), newLightRes);
                }
                if (eq.GetDarkRes() > 0)
                {
                    Console.WriteLine("|| +{0} Dark Resistance | -> +{1} Dark Resistance", eq.GetDarkRes(), newDarkRes);
                }


            }

            #endregion

            #region Shop SubMenues

            void ShopConsumables(List<Item> shopList)
            {
                ConsumablesShop:
                Console.Clear();
                

                Console.WriteLine(border);
                Console.WriteLine("||                CONSUMABLES");
                Console.WriteLine(border);
                for (int i = 0; i < shopList.Count; i++)
                {
                    int price = shopList[i].GetPrice();
                    string name = shopList[i].GetName();
                    int amount = player.GetAmountInInventory(shopList[i]);

                    Console.Write("|| [{0}] ", i + 1);
                    Console.WriteLine(String.Format("| {0, -20} | {1, -3} Gold | {2, 1} in Inventory", name, price, amount));
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Gold: {0}", player.GetGold());
                Console.WriteLine(border);
                Console.WriteLine("|| Type in the Number of the Item you want to buy!");
                Console.WriteLine("|| Or press enter to return to the Shop Menu");
                Console.WriteLine(border);

                string input = Console.ReadLine();
                int slot;

                if (input == "")
                {
                    shopList.Clear();
                    ShopMenu();
                }

                if (Int32.TryParse(input, out slot))
                {
                    slot = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto ConsumablesShop;
                }

                if (!(slot <= 0 || slot > shopList.Count))
                {

                    string name = shopList[slot - 1].GetName();
                    int itemPrice = shopList[slot - 1].GetPrice();

                    Console.WriteLine(border);
                    Console.WriteLine("|| How many? | Please Enter a Number from 1 to 99! ");
                    Console.WriteLine(border);

                    int amount = Convert.ToInt32(Console.ReadLine());
                    int finalPrice = itemPrice * amount;

                    Console.WriteLine(border);
                    Console.WriteLine("|| You want to buy {0}x {1}? That would be {2} Gold.", amount, name, finalPrice);
                    Console.WriteLine("|| Are you sure? [1] Yes | [2] No");
                    Console.WriteLine(border);

                    string choice = Console.ReadLine();

                    int gold = player.GetGold();

                    if (choice == "1")
                    {
                        if (gold >= finalPrice)
                        {
                            player.AddToInventory(shopList[slot - 1], amount);
                            player.SetGold(gold - finalPrice);

                            Console.WriteLine(border);
                            Console.WriteLine("|| You bought {0}x {1}!", amount, name);
                            Console.WriteLine(border);

                            Console.ReadLine();
                            shopList.Clear();
                            ShopMenu();
                        }
                        else
                        {
                            Console.WriteLine(border);
                            Console.WriteLine("|| Are you kidding me? You dont have enough Gold!");
                            Console.WriteLine(border);

                            Console.ReadLine();
                            shopList.Clear();
                            ShopMenu();
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.ReadLine();
                        shopList.Clear();
                        ShopMenu();
                    }
                    else
                    {
                        Console.WriteLine(border);
                        Console.WriteLine("|| Please enter a valid number!");
                        Console.WriteLine(border);

                        Console.ReadLine();
                        goto ConsumablesShop;
                    }
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto ConsumablesShop;
                }

            }

            void ShopEquipment(List<Equipment> shopList)
            {
                EquipmentShop:
                Console.Clear();
                

                Console.WriteLine(border);
                Console.WriteLine("|| EQUIPMENT");
                Console.WriteLine(border);
                for (int i = 0; i < shopList.Count; i++)
                {
                    int price = shopList[i].GetPrice();
                    string name = shopList[i].GetName();
                    string element = shopList[i].GetElementText();
                    int amount = player.GetAmountInInventory(shopList[i]);

                    Console.Write(String.Format("|| [{0}] | {1, -12} |", i + 1, name, element, price));
                    Console.ForegroundColor = shopList[i].GetElementColor();
                    Console.Write(String.Format(" {0, -8} ", element));
                    Console.ResetColor();
                    Console.Write(String.Format("| {0, -5} Gold | {1} in Inventory", price, amount));
                    Console.WriteLine("");
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Gold: {0}", player.GetGold());
                Console.WriteLine(border);
                Console.WriteLine("|| Type in the Number of the Item you want to buy!");
                Console.WriteLine("|| Or press enter to return to the Shop Menu");
                Console.WriteLine(border);

                string input = Console.ReadLine();
                int slot;

                if (input == "")
                {
                    shopList.Clear();
                    ShopMenu();
                }


                if (Int32.TryParse(input, out slot))
                {
                    slot = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto EquipmentShop;
                }

              
                if(!(slot <= 0 || slot > shopList.Count))
                {
                    string name = shopList[slot - 1].GetName();
                    int itemPrice = shopList[slot - 1].GetPrice();
                    string element = shopList[slot - 1].GetElementText();

                    Console.WriteLine(border);
                    Console.WriteLine("|| You want to buy {0} | {1} |? That would be {2} Gold.", name, element, itemPrice);
                    Console.WriteLine("|| Are you sure? [1] Yes | [2] No");
                    Console.WriteLine(border);

                    string choice = Console.ReadLine();

                    int gold = player.GetGold();

                    if (choice == "1")
                    {
                        if (gold >= itemPrice)
                        {
                            player.AddToInventory(shopList[slot - 1]);
                            player.SetGold(gold - itemPrice);

                            Console.WriteLine(border);
                            Console.WriteLine("|| You bought {0} | {1} |!", name, element);
                            Console.WriteLine(border);

                            Console.ReadLine();
                            shopList.Clear();
                            ShopMenu();
                        }
                        else
                        {
                            Console.WriteLine(border);
                            Console.WriteLine("|| Are you kidding me? You dont have enough Gold!");
                            Console.WriteLine(border);

                            Console.ReadLine();
                            shopList.Clear();
                            ShopMenu();
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.ReadLine();
                        shopList.Clear();
                        ShopMenu();
                    }
                    else
                    {
                        Console.WriteLine(border);
                        Console.WriteLine("|| Please enter a valid number!");
                        Console.WriteLine(border);

                        Console.ReadLine();
                        goto EquipmentShop;
                    }
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto EquipmentShop;
                }


            }

            void ShopOther(List<Item> shopList)
            {
                OtherShop:
                Console.Clear();

                Console.WriteLine(border);
                Console.WriteLine("||                OTHER ITEMS");
                Console.WriteLine(border);
                Console.WriteLine("||");
                for (int i = 0; i < shopList.Count; i++)
                {
                    int price = shopList[i].GetPrice();
                    string name = shopList[i].GetName();
                    int amount = player.GetAmountInInventory(shopList[i]);

                    Console.Write("|| [{0}] ", i + 1);
                    Console.WriteLine(String.Format("| {0, -20} | {1, -3} Gold | {2, 1} in Inventory", name, price, amount));
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Gold: {0}", player.GetGold());
                Console.WriteLine(border);
                Console.WriteLine("|| Type in the Number of the Item you want to buy!");
                Console.WriteLine("|| Or press enter to return to the Shop Menu");
                Console.WriteLine(border);

                string input = Console.ReadLine();
                int slot;

                if (input == "")
                {
                    shopList.Clear();
                    ShopMenu();
                }

                if (Int32.TryParse(input, out slot))
                {
                    slot = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto OtherShop;
                }
                
                if (!(slot <= 0 || slot > shopList.Count))
                {

                    string name = shopList[slot - 1].GetName();
                    int itemPrice = shopList[slot - 1].GetPrice();

                    Console.WriteLine(border);
                    Console.WriteLine("|| How many? | Please Enter a Number from 1 to 99! ");
                    Console.WriteLine(border);

                    int amount = Convert.ToInt32(Console.ReadLine());
                    int finalPrice = itemPrice * amount;

                    Console.WriteLine(border);
                    Console.WriteLine("|| You want to buy {0}x {1}? That would be {2} Gold.", amount, name, finalPrice);
                    Console.WriteLine("|| Are you sure? [1] Yes | [2] No");
                    Console.WriteLine(border);

                    string choice = Console.ReadLine();

                    int gold = player.GetGold();

                    if (choice == "1")
                    {
                        if (gold >= finalPrice)
                        {
                            player.AddToInventory(shopList[slot - 1], amount);
                            player.SetGold(gold - finalPrice);

                            Console.WriteLine(border);
                            Console.WriteLine("|| You bought {0}x {1}!", amount, name);
                            Console.WriteLine(border);

                            Console.ReadLine();
                            shopList.Clear();
                            ShopMenu();
                        }
                        else
                        {
                            Console.WriteLine(border);
                            Console.WriteLine("|| Are you kidding me? You dont have enough Gold!");
                            Console.WriteLine(border);

                            Console.ReadLine();
                            shopList.Clear();
                            ShopMenu();
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.ReadLine();
                        shopList.Clear();
                        ShopMenu();
                    }
                    else
                    {
                        Console.WriteLine(border);
                        Console.WriteLine("|| Please enter a valid number!");
                        Console.WriteLine(border);

                        Console.ReadLine();
                        goto OtherShop;
                    }
                }
                else
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Invalid Input. Please try again!");
                    Console.ReadLine();
                    goto OtherShop;
                }
            }

            #endregion

            #region Battle Methods

            void Attack(int damage, int order, Skill skill)
            {
                string wElement = player.GetWeapon().GetElementBattleText();
                string sElement = "";
                string sName = "";
                if (skill != null)
                {
                    sElement = skill.GetElementText();
                    sName = skill.GetName();
                }
                string eElement = randomEnemy.GetElementText();
                string pName = player.name;
                string eName = randomEnemy.GetName();


                Console.WriteLine(border);
                if(order == 1)
                {
                    if (!player.GetUsedSkill())
                    {
                        Console.WriteLine("|| {0} attacks!", pName);
                        Console.WriteLine(border);
                        if (player.GetDidCrit())
                        {
                            Console.WriteLine("|| CRITICAL HIT!");
                        }
                        Console.WriteLine("|| {0} got {1} {2} damage!", eName, randomEnemy.GetDamaged(damage, wElement), wElement);
                        if (randomEnemy.IsDead())
                        {
                            Console.WriteLine("|| {0} got defeated!", eName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("|| {0} uses {1}!", pName, sName);
                        player.SetUsedSkill(false);
                        Console.WriteLine(border);
                        if (player.GetDidCrit())
                        {
                            Console.WriteLine("|| CRITICAL HIT!");
                        }
                        Console.WriteLine("|| {0} got {1} {2} damage!", eName, randomEnemy.GetDamaged(damage, sElement), sElement);
                        if (randomEnemy.IsDead())
                        {
                            Console.WriteLine("|| {0} got defeated!", eName);
                        }
                    }
                    
                }
                else
                {
                    if (!randomEnemy.GetUsedSkill())
                    {
                        Console.WriteLine("|| {0} attacks!", eName);
                        Console.WriteLine(border);
                        if (randomEnemy.GetDidCrit())
                        {
                            Console.WriteLine("|| CRITICAL HIT!");
                        }
                        Console.WriteLine("|| {0} got {1} {2} damage!", pName, player.GetDamaged(damage, eElement), eElement);
                    }
                    else
                    {
                        Console.WriteLine("|| {0} uses {1}!", eName, sName);
                        randomEnemy.SetUsedSkill(false);
                        if (randomEnemy.GetDidCrit())
                        {
                            Console.WriteLine("|| CRITICAL HIT!");
                        }
                        Console.WriteLine(border);
                        Console.WriteLine("|| {0} got {1} {2} damage!", pName, player.GetDamaged(damage, sElement), sElement);
                    }
                    
                }
                Console.WriteLine(border);
                
            }

            void ChooseSkill()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||                SKILLS");
                Console.WriteLine(border);
                for (int i = 0; i < player.GetSkills().Count; i++)
                {
                    string sName = player.GetSkills()[i].GetName();
                    string sElement = player.GetSkills()[i].GetElementText();
                    string sLevel = player.GetSkills()[i].GetLevelText();
                    int sDamage = player.GetSkills()[i].GetDamage();
                    int sManaCost = player.GetSkills()[i].GetManaCost();

                    Console.WriteLine("|| [{0}] {1}{2} | {3} | Base Damage: {4} | Mana Cost: {5}", i+1, sName, sLevel, sElement, sDamage, sManaCost);
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Choose a Skill by typing the Number of the Skill.");
                Console.WriteLine("|| Or press Enter to return to the Fight");
                Console.WriteLine(border);

                string input = Console.ReadLine();
                int slot;

                if(input == "")
                {
                    FightEnemyMenu();
                }
                else
                {
                    if (Int32.TryParse(input, out slot))
                    {
                        slot = Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Pls enter a valid number!");
                        Console.ReadLine();
                        ChooseSkill();
                    }

                    if (slot < 0 || slot > player.GetSkills().Count)
                    {
                        Console.WriteLine("Pls enter a valid number!");
                        Console.ReadLine();
                        ChooseSkill();
                    }

                    if(player.GetSkills()[slot- 1].GetManaCost() > player.GetMana())
                    {
                        Console.WriteLine(border);
                        Console.WriteLine("|| Not enough Mana!");
                        Console.WriteLine(border);
                        Console.WriteLine("|| ");
                        Console.WriteLine("|| Press Enter to continue");
                        Console.WriteLine(border);

                        Console.ReadLine();
                        ChooseSkill();
                    }
                    else
                    {
                        if (player.GetSpeed() > randomEnemy.GetSpeed())
                        {
                            Attack(player.UseSkill(slot - 1), 1, player.GetSkills()[slot - 1]);
                            if (!randomEnemy.IsDead())
                            {
                                EnemyAttack();
                                if (player.IsDead()) GameOver();
                            }


                            Console.WriteLine("|| Press Enter to Continue");

                            Console.ReadLine();
                            FightEnemyMenu();
                        }
                        else
                        {
                            if (!randomEnemy.IsDead())
                            {
                                EnemyAttack();
                                if (player.IsDead()) GameOver();
                            }
                            Attack(player.UseSkill(slot - 1), 1, player.GetSkills()[slot - 1]);

                            Console.WriteLine("|| Press Enter to Continue");

                            Console.ReadLine();
                            FightEnemyMenu();
                        }
                    }
                   
                }

            }

            void EnemyAttack()
            {
                int slot;
                Skill enemySkill = new Skill();
                List<Skill> skillList = randomEnemy.GetSkills();
                Random rng = new Random();

                if(skillList.Count > 0)
                {
                    slot = rng.Next(0, skillList.Count-1);
                }
                else
                {
                    slot = rng.Next(0, skillList.Count);
                }
                
                int damage = randomEnemy.Fight(slot);

                if (randomEnemy.GetUsedSkill())
                {
                    enemySkill = randomEnemy.GetSkills()[slot];

                    Attack(damage, 2, enemySkill);

                }
                else
                {
                    Attack(damage, 2, null);
                }

            }

            void ChooseItem()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||                INVENTORY");
                Console.WriteLine(border);
                for (int i = 0; i < player.GetConsumables().Count; i++)
                {
                    Item item = player.GetConsumables()[i];
                    
                    Console.WriteLine("|| [{0}] {1} | x{2}", i + 1, item.GetName(), item.GetAmount());
                    Console.WriteLine(border);
                }
                Console.WriteLine(border);
                Console.WriteLine("|| Choose an Item by typing the Number of the Item you want to use.");
                Console.WriteLine("|| or press Enter to return to the Fight");

                string input = Console.ReadLine();
                int slot;
                if (input == "")
                {
                    FightEnemyMenu();
                }
                else
                {
                    if (Int32.TryParse(input, out slot))
                    {
                        slot = Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Pls enter a valid number!");
                        Console.ReadLine();
                        ChooseItem();
                    }

                    if (slot < 0 || slot > player.GetConsumables().Count)
                    {
                        Console.WriteLine("|| Pls enter a valid number!");
                        Console.ReadLine();
                        ChooseItem();
                    }

                    Console.WriteLine(border);
                    Console.WriteLine("|| {0} | {1}", player.GetConsumables()[slot - 1].GetName(), player.GetConsumables()[slot - 1].GetDescription());
                    Console.WriteLine(border);
                    Console.WriteLine("|| Do you want to use it?");
                    Console.WriteLine("|| ");
                    Console.WriteLine("||   [1] Yes  |  [2] No");
                    Console.WriteLine(border);
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        itemManager.UseItem(player.GetConsumables()[slot - 1], player);
                        player.RefreshInventory();
                        Console.WriteLine(border);
                    }
                    else
                    {
                        ChooseItem();
                    }
                }

                Console.WriteLine("|| Press Enter to continue");
                Console.ReadLine();

                ChooseItem();
            }

            void GameOver()
            {
                Console.Clear();
                Console.WriteLine(border);
                Console.WriteLine("||            GAME OVER          ");
                Console.WriteLine(border);
                Console.ReadLine();

                Welcome();
            }

            #endregion

            void CheckForNewSkills()
            {
                switch (player.GetClass())
                {
                    case "Knight":
                        switch (player.level)
                        {
                            case 5:
                                player.AddSkill(skillManager.GetSkill(105));
                                Console.WriteLine("|| You've learned {0}!", skillManager.GetSkill(105).GetName());
                                break;
                        }
                        break;
                    case "Assassin":

                        break;
                    case "Archer":

                        break;
                    case "Mage":

                        break;
                    default:

                        break;
                }
            }

        }
    }
}
