using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class UpgradeManager
    {

        ItemManager im = new ItemManager();
        

        public List<Item> GetRequiredMaterials(Equipment eq)
        {
            im.LoadItems();
            List<Item> mat = new List<Item>();

            //Important ItemIDs
            // 101 = Rune Stone
            // 102 = Runic Dust
            // 103 = White Dust
            // 104 = Red Dust
            // 105 = Blue Dust
            // 106 = Yellow Dust
            // 107 = Dark Dust

            

            switch (eq.GetElementType())
            {
                //Setting Materials depending on the element
                case 1:
                    switch (eq.GetTier())
                    {
                        //Setting Materials depending on the Tier
                        case 0:
                            AddToMaterials(101, 5 + (5 * eq.GetLevel()), mat);
                            AddToMaterials(102, 2 + (2 * eq.GetLevel()), mat);
                            break;
                        case 1:
                            AddToMaterials(101, 10 + (10 * eq.GetLevel()), mat);
                            AddToMaterials(102, 5 + (5 * eq.GetLevel()), mat);
                            break;
                        case 2:
                            AddToMaterials(101, 15 + (15 * eq.GetLevel()), mat);
                            AddToMaterials(102, 10 + (10 * eq.GetLevel()), mat);
                            break;
                        case 3:
                            AddToMaterials(101, 30 + (30 * eq.GetLevel()), mat);
                            AddToMaterials(102, 15 + (15 * eq.GetLevel()), mat);
                            break;
                        default:
                            AddToMaterials(101, 0, mat);
                            AddToMaterials(102, 0, mat);
                            break;
                    }
                    break;
                case 2:
                    switch (eq.GetTier())
                    {
                        //Setting Materials depending on the Tier
                        case 0:
                            AddToMaterials(101, 5 + (5 * eq.GetLevel()), mat);
                            AddToMaterials(104, 2 + (2 * eq.GetLevel()), mat);
                            break;
                        case 1:
                            AddToMaterials(101, 10 + (10 * eq.GetLevel()), mat);
                            AddToMaterials(104, 5 + (5 * eq.GetLevel()), mat);
                            break;
                        case 2:
                            AddToMaterials(101, 15 + (15 * eq.GetLevel()), mat);
                            AddToMaterials(104, 10 + (10 * eq.GetLevel()), mat);
                            break;
                        case 3:
                            AddToMaterials(101, 30 + (30 * eq.GetLevel()), mat);
                            AddToMaterials(104, 15 + (15 * eq.GetLevel()), mat);
                            break;
                        default:
                            AddToMaterials(101, 0, mat);
                            AddToMaterials(104, 0, mat);
                            break;
                    }
                    break;
                case 3:
                    switch (eq.GetTier())
                    {
                        //Setting Materials depending on the Tier
                        case 0:
                            AddToMaterials(101, 5 + (5 * eq.GetLevel()), mat);
                            AddToMaterials(105, 2 + (2 * eq.GetLevel()), mat);
                            break;
                        case 1:
                            AddToMaterials(101, 10 + (10 * eq.GetLevel()), mat);
                            AddToMaterials(105, 5 + (5 * eq.GetLevel()), mat);
                            break;
                        case 2:
                            AddToMaterials(101, 15 + (15 * eq.GetLevel()), mat);
                            AddToMaterials(105, 10 + (10 * eq.GetLevel()), mat);
                            break;
                        case 3:
                            AddToMaterials(101, 30 + (30 * eq.GetLevel()), mat);
                            AddToMaterials(105, 15 + (15 * eq.GetLevel()), mat);
                            break;
                        default:
                            AddToMaterials(101, 0, mat);
                            AddToMaterials(105, 0, mat);
                            break;
                    }
                    break;
                case 4:
                    switch (eq.GetTier())
                    {
                        //Setting Materials depending on the Tier
                        case 0:
                            AddToMaterials(101, 5 + (5 * eq.GetLevel()), mat);
                            AddToMaterials(106, 2 + (2 * eq.GetLevel()), mat);
                            break;
                        case 1:
                            AddToMaterials(101, 10 + (10 * eq.GetLevel()), mat);
                            AddToMaterials(106, 5 + (5 * eq.GetLevel()), mat);
                            break;
                        case 2:
                            AddToMaterials(101, 15 + (15 * eq.GetLevel()), mat);
                            AddToMaterials(106, 10 + (10 * eq.GetLevel()), mat);
                            break;
                        case 3:
                            AddToMaterials(101, 30 + (30 * eq.GetLevel()), mat);
                            AddToMaterials(106, 15 + (15 * eq.GetLevel()), mat);
                            break;
                        default:
                            AddToMaterials(101, 0, mat);
                            AddToMaterials(106, 0, mat);
                            break;
                    }
                    break;
                case 5:
                    switch (eq.GetTier())
                    {
                        //Setting Materials depending on the Tier
                        case 0:
                            AddToMaterials(101, 5 + (5 * eq.GetLevel()), mat);
                            AddToMaterials(103, 2 + (2 * eq.GetLevel()), mat);
                            break;
                        case 1:
                            AddToMaterials(101, 10 + (10 * eq.GetLevel()), mat);
                            AddToMaterials(103, 5 + (5 * eq.GetLevel()), mat);
                            break;
                        case 2:
                            AddToMaterials(101, 15 + (15 * eq.GetLevel()), mat);
                            AddToMaterials(103, 10 + (10 * eq.GetLevel()), mat);
                            break;
                        case 3:
                            AddToMaterials(101, 30 + (30 * eq.GetLevel()), mat);
                            AddToMaterials(103, 15 + (15 * eq.GetLevel()), mat);

                            // For Weapon 405: Excalibur
                            if (eq.GetItemID() == 405)
                            {
                                AddToMaterials(108, 2 + (3 * eq.GetLevel()), mat);
                            }
                            break;
                        default:
                            AddToMaterials(101, 0, mat);
                            AddToMaterials(103, 0, mat);
                            break;
                    }
                    break;
                case 6:
                    switch (eq.GetTier())
                    {
                        //Setting Materials depending on the Tier
                        case 0:
                            AddToMaterials(101, 5 + (5 * eq.GetLevel()), mat);
                            AddToMaterials(107, 2 + (2 * eq.GetLevel()), mat);
                            break;
                        case 1:
                            AddToMaterials(101, 10 + (10 * eq.GetLevel()), mat);
                            AddToMaterials(107, 5 + (5 * eq.GetLevel()), mat);
                            break;
                        case 2:
                            AddToMaterials(101, 15 + (15 * eq.GetLevel()), mat);
                            AddToMaterials(107, 10 + (10 * eq.GetLevel()), mat);
                            break;
                        case 3:
                            AddToMaterials(101, 30 + (30 * eq.GetLevel()), mat);
                            AddToMaterials(107, 15 + (15 * eq.GetLevel()), mat);
                            break;
                        default:
                            AddToMaterials(101, 0, mat);
                            AddToMaterials(107, 0, mat);
                            break;
                    }
                    break;
            }


            return mat;
        }

        public Equipment Upgrade(Equipment oldEQ, Player player)
        {
            oldEQ.SetLevel(oldEQ.GetLevel() + 1);

            if (oldEQ.GetDamage() >= 1)
            {
                oldEQ.SetDamage(oldEQ.GetDamage() + oldEQ.GetLevel() * 2);
            }

            if (oldEQ.GetStaminaBonus() >= 1)
            {
                int newStam = oldEQ.GetStaminaBonus() + oldEQ.GetLevel() * 2;
                oldEQ.SetStamina(newStam);
                player.UpdateStats();
                player.AddHealth((oldEQ.GetLevel() * 2) * 10);
            }

            if (oldEQ.GetStrengthBonus() >= 1)
            {
                oldEQ.SetStrength(oldEQ.GetStrengthBonus() + oldEQ.GetLevel() * 2);
            }

            if (oldEQ.GetDefenseBonus() >= 1)
            {
                oldEQ.SetDefense(oldEQ.GetDefenseBonus() + oldEQ.GetLevel() * 2);
            }

            if (oldEQ.GetIntelligenceBonus() >= 1)
            {
                oldEQ.SetIntelligence(oldEQ.GetIntelligenceBonus() + oldEQ.GetLevel() * 2);
            }

            if (oldEQ.GetSpeedBonus() >= 1)
            {
                oldEQ.SetSpeed(oldEQ.GetSpeedBonus() + oldEQ.GetLevel() * 2);
            }

            oldEQ.SetPrice(oldEQ.GetPrice() + oldEQ.GetLevel() * oldEQ.GetPrice());
            return oldEQ;
        }

        public bool CheckMats(List<Item> reqMats, List<Item> playerMats)
        {
            for (int i = 0; i < reqMats.Count; i++)
            {
                int amount = reqMats[i].GetAmount();
                int playerAmount = 0;

                for (int j = 0; j < playerMats.Count; j++)
                {
                    if(reqMats[i].GetName() == playerMats[j].GetName())
                    {
                        playerAmount = playerMats[j].GetAmount();
                    }
                }
                if(playerAmount < amount)
                {
                    return false;
                }
            }

            return true;
        }

        public void DeleteMats(List<Item> reqMats, List<Item> playerMats)
        {
            for (int i = 0; i < reqMats.Count; i++)
            {
                int amount = reqMats[i].GetAmount();

                for (int j = 0; j < playerMats.Count; j++)
                {
                    if (reqMats[i].GetItemID() == playerMats[j].GetItemID())
                    {
                        playerMats[j].SetAmount(playerMats[j].GetAmount() - amount);
                    }
                }
                

            }
        }

        void AddToMaterials(int itemID, int amount, List<Item> itList)
        {
            Item it = new Item();

            for (int i = 0; i < im.GetItemList().Count; i++)
            {
                Item item = im.GetItemList()[i];
                if(item.GetItemID() == itemID)
                {
                    it = item;
                }
            }

            it.SetAmount(amount);
            itList.Add(it);
        }

        
    }
}
