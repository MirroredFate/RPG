using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class BattleManager 
    {
        const string border = "||-----------------------------------------------------------";

        ItemManager im = new ItemManager();
        SkillManager sm = new SkillManager();
        EffectManager em = new EffectManager();

        bool won;
        bool gameOver;

        #region Public Methods

        public BattleManager()
        {
            im.LoadItems();
            sm.LoadSkills();
            em.LoadEffects();

            won = false;
            gameOver = false;
        }

        public void StartBattle(Player player, Enemy randomEnemy)
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
                Console.Write("{0} / {1}", player.GetHealth(), player.GetMaxHealth());
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
                    StartBattle(player, randomEnemy);
                }
                if (input == "1")
                {
                    if (player.GetSpeed() > randomEnemy.GetSpeed())
                    {
                        Attack(player.Attack(), 1, null, player, randomEnemy);
                        if (!randomEnemy.IsDead())
                        {
                            EnemyAttack(player, randomEnemy);
                            
                        }
                        if (player.IsDead()) GameOver();
                        Console.WriteLine("|| Press Enter to Continue");

                        Console.ReadLine();
                        StartBattle(player, randomEnemy);
                    }
                    else
                    {
                        if (!randomEnemy.IsDead())
                        {
                            EnemyAttack(player, randomEnemy);
                        }
                        if (player.IsDead())
                        {
                            GameOver();
                        }
                        else
                        {
                            Attack(player.Attack(), 1, null, player, randomEnemy);
                        }

                        Console.WriteLine("|| Press Enter to Continue");

                        Console.ReadLine();
                        if (gameOver)
                        {
                            return;
                        }
                        else
                        {
                            StartBattle(player, randomEnemy);
                        }

                    }
                }
                else if (input == "2")
                {
                    ChooseSkill(player, randomEnemy);
                }
                else if (input == "3")
                {
                    ChooseItem(player, randomEnemy);
                }
                else if (input == "9")
                {
                    Attack(99999, 1, null, player, randomEnemy);
                    Console.WriteLine("|| Press Enter to Continue");

                    Console.ReadLine();
                    StartBattle(player, randomEnemy);
                }
                else
                {
                    Console.WriteLine("|| Pls enter a Valid number.");
                    StartBattle(player, randomEnemy);
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
                    player.AddGold(randomEnemy.GetGold());
                    won = true;
                    gameOver = false;

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
                        player.CheckForNewSkills(sm);
                        Console.WriteLine("|| Choose a Stat to Level up!");
                        Console.WriteLine(border);

                        string stam = "Increases your Max HP";
                        string def = "Reduces normal damage taken";
                        string str = "Increases physical damage dealt";
                        string inte = "Increases elemental damage dealt and your maximum Mana";
                        string spd = "If you have more speed than your enemy, you attack first";

                        Console.WriteLine(String.Format("|| [1] Stamina - {0,10}", stam));
                        Console.WriteLine(String.Format("|| [2] Defense  - {0,10}", def));
                        Console.WriteLine(String.Format("|| [3] Strength  - {0,10}", str));
                        Console.WriteLine(String.Format("|| [4] Intelligence  - {0,10}", inte));
                        Console.WriteLine(String.Format("|| [5] Speed  - {0,10}", spd));
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

                Console.ReadLine();
                EndBattle();

            }
        }

        #endregion

        #region Private Methods

        void Attack(int damage, int order, Skill skill, Player player, Enemy randomEnemy)
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
            if (order == 1)
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

        void ChooseSkill(Player player, Enemy randomEnemy)
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
                if (player.GetSkills()[i].GetSkillType() == 3)
                {
                    int sHealAmount = em.GetEffect(player.GetSkills()[i].GetEffectID()).GetHealAmount();
                    Console.WriteLine("|| [{0}] {1}{2} | {3} | Base Heal: {4} | Mana Cost: {5}", i + 1, sName, sLevel, sElement, sHealAmount, sManaCost);
                }
                else
                {
                    Console.WriteLine("|| [{0}] {1}{2} | {3} | Base Damage: {4} | Mana Cost: {5}", i + 1, sName, sLevel, sElement, sDamage, sManaCost);
                }

            }
            Console.WriteLine(border);
            Console.WriteLine("|| Mana: {0}", player.GetMana());
            Console.WriteLine(border);
            Console.WriteLine("|| Choose a Skill by typing the Number of the Skill.");
            Console.WriteLine("|| Or press Enter to return to the Fight");
            Console.WriteLine(border);

            string input = Console.ReadLine();
            int slot;

            if (input == "")
            {
                StartBattle(player, randomEnemy);
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
                    ChooseSkill(player, randomEnemy);
                }

                if (slot < 0 || slot > player.GetSkills().Count)
                {
                    Console.WriteLine("Pls enter a valid number!");
                    Console.ReadLine();
                    ChooseSkill(player, randomEnemy);
                }

                if (player.GetSkills()[slot - 1].GetManaCost() > player.GetMana())
                {
                    Console.WriteLine(border);
                    Console.WriteLine("|| Not enough Mana!");
                    Console.WriteLine(border);
                    Console.WriteLine("|| ");
                    Console.WriteLine("|| Press Enter to continue");
                    Console.WriteLine(border);

                    Console.ReadLine();
                    ChooseSkill(player, randomEnemy);
                }
                else
                {
                    if (player.GetSkills()[slot - 1].GetSkillType() == 3)
                    {
                        player.UseSkill(slot - 1);
                        Console.WriteLine(border);
                        Console.WriteLine("|| Press Enter to Continue");
                        Console.ReadLine();
                        ChooseSkill(player, randomEnemy);
                    }
                    else
                    {
                        if (player.GetSpeed() > randomEnemy.GetSpeed())
                        {
                            Attack(player.UseSkill(slot - 1), 1, player.GetSkills()[slot - 1], player, randomEnemy);
                            if (!randomEnemy.IsDead())
                            {
                                EnemyAttack(player, randomEnemy);
                                if (player.IsDead()) GameOver();
                            }


                            Console.WriteLine("|| Press Enter to Continue");

                            Console.ReadLine();
                            StartBattle(player, randomEnemy);
                        }
                        else
                        {
                            if (!randomEnemy.IsDead())
                            {
                                EnemyAttack(player, randomEnemy);
                                if (player.IsDead()) GameOver();
                            }
                            Attack(player.UseSkill(slot - 1), 1, player.GetSkills()[slot - 1], player, randomEnemy);

                            Console.WriteLine("|| Press Enter to Continue");

                            Console.ReadLine();
                            StartBattle(player, randomEnemy);
                        }

                    }
                }

            }

        }

        void EnemyAttack(Player player, Enemy randomEnemy)
        {
            int slot;
            Skill enemySkill = new Skill();
            List<Skill> skillList = randomEnemy.GetSkills();
            Random rng = new Random();

            if (skillList.Count > 0)
            {
                slot = rng.Next(0, skillList.Count - 1);
            }
            else
            {
                slot = rng.Next(0, skillList.Count);
            }

            int damage = randomEnemy.Fight(slot);

            if (randomEnemy.GetUsedSkill())
            {
                enemySkill = randomEnemy.GetSkills()[slot];

                Attack(damage, 2, enemySkill, player, randomEnemy);

            }
            else
            {
                Attack(damage, 2, null, player, randomEnemy);
            }

        }

        void ChooseItem(Player player, Enemy randomEnemy)
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
                StartBattle(player, randomEnemy);
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
                    ChooseItem(player, randomEnemy);
                }

                if (slot < 0 || slot > player.GetConsumables().Count)
                {
                    Console.WriteLine("|| Pls enter a valid number!");
                    Console.ReadLine();
                    ChooseItem(player, randomEnemy);
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
                    im.UseItem(player.GetConsumables()[slot - 1], player);
                    player.RefreshInventory();
                    Console.WriteLine(border);
                }
                else
                {
                    ChooseItem(player, randomEnemy);
                }
            }

            Console.WriteLine("|| Press Enter to continue");
            Console.ReadLine();

            ChooseItem(player, randomEnemy);
        }

        void GameOver()
        {
            Console.Clear();
            Console.WriteLine(border);
            Console.WriteLine("||            GAME OVER          ");
            Console.WriteLine(border);
            gameOver = true;
            won = false;

            Console.ReadLine();
            EndBattle();
        }

        void EndBattle()
        {
            Console.WriteLine("|| The Battle has ended...");
            Console.WriteLine(border);
        }

        #endregion

        #region Getter

        public bool getWon()
        {
            return won;
        }

        public bool getGameOver()
        {
            return gameOver;
        }

        #endregion
    }
}
