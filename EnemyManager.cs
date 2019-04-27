using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class EnemyManager
    {
        List<Enemy> enemyList = new List<Enemy>();


        #region Getter

        public List<Enemy> GetEnemyList()
        {
            return enemyList;
        }

        public Enemy GetEnemy(int id)
        {
            Enemy dummy = new Enemy();

            for (int i = 0; i < enemyList.Count; i++)
            {
                if(enemyList[i].GetID() == id)
                {
                    dummy = enemyList[i];
                    
                }
            }

            return dummy;

        }

        #endregion

        #region Public Methods

        public void LoadEnemies(SkillManager sm, ItemManager im)
        {
            enemyList.Clear();

            Enemy slime = new Enemy(
                    "Slime", // Name
                    1,       // ID
                    1,       // Type | 1 = Physical / 2 = Elemental / 3 = Both 
                    1,       //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    2,       // Defense   
                    10,      // Strength
                    0,       // Intelligence
                    5,       // Speed
                    5,       // Damage
                    10,      // Critical Chance
                    20,      // XP the player gets for killing
                    10,      // Gold the player gets for killing
                    100,     // Max HP
                    0);      // Max Mana

            slime.AddItem(102, 2, im);

            enemyList.Add(slime);
            //-------------------------------------------------------
            Enemy fireSlime = new Enemy(
                    "Fire Slime", // Name
                    2,       // ID
                    2,       // Type | 1 = Physical / 2 = Elemental / 3 = Both 
                    2,       //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    3,       // Defense   
                    1,       // Strength
                    15,      // Intelligence
                    5,       // Speed
                    5,       // Damage
                    10,      // Critical Chance
                    25,      // XP the player gets for killing
                    20,      // Gold the player gets for killing
                    100,     // Max HP
                    10);     // Max Mana

            fireSlime.AddSkill(1, sm);
            fireSlime.AddItem(104, 2, im);

            enemyList.Add(fireSlime);
            //-------------------------------------------------------
            Enemy waterSlime = new Enemy(
                    "Water Slime", // Name
                    3,       // ID
                    2,       // Type | 1 = Physical / 2 = Elemental / 3 = Both 
                    3,       //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    3,       // Defense   
                    1,       // Strength
                    15,      // Intelligence
                    5,       // Speed
                    5,       // Damage
                    10,      // Critical Chance
                    25,      // XP the player gets for killing
                    20,      // Gold the player gets for killing
                    100,     // Max HP
                    10);     // Max Mana

            waterSlime.AddSkill(2, sm);
            waterSlime.AddItem(105, 2, im);

            enemyList.Add(waterSlime);
            //-------------------------------------------------------
            Enemy lightSlime = new Enemy(
                    "Light Slime", // Name
                    3,       // ID
                    2,       // Type | 1 = Physical / 2 = Elemental / 3 = Both 
                    5,       //1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                    3,       // Defense   
                    1,       // Strength
                    20,      // Intelligence
                    5,       // Speed
                    5,       // Damage
                    10,      // Critical Chance
                    25,      // XP the player gets for killing
                    20,      // Gold the player gets for killing
                    100,     // Max HP
                    10);     // Max Mana

            lightSlime.AddSkill(3, sm);
            lightSlime.AddItem(103, 2, im);

            enemyList.Add(lightSlime);
            //-------------------------------------------------------


        }

        #endregion

       
    }
}
