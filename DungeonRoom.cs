using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class DungeonRoom
    {
        string name;
        int type;           // 1 = EnemyRoom | 2 = SaveRoom | 3 = TreasureRoom(Item) | 4 = TreasureRoom(Equipment) | 5 = BossRoom
        int roomID;
        int itemID;
        int bossID;
        int amountOfEnemies;
        int enemyID;

        public DungeonRoom(string name = "",int type = 0, int roomID = 0, int amountOfEnemies = 0,int enemyID = 0,int itemID = 0, int bossID = 0)
        {
            this.name = name;
            this.type = type;
            this.roomID = roomID;

            switch (type)
            {
                case 1:
                    this.amountOfEnemies = amountOfEnemies;
                    this.enemyID = enemyID;
                    break;
                case 3:
                case 4:
                    this.itemID = itemID;
                    break;
                case 5:
                    this.bossID = bossID;
                    break;
                default:
                    this.bossID = 0;
                    this.itemID = 0;
                    this.amountOfEnemies = 0;
                    this.enemyID = 0;
                    break;
            }

        }

        #region Setters

        public void SetType(int type)
        {
            this.type = type;
        }

        public void SetRoomID(int id)
        {
            this.roomID = id;
        }

        #endregion

        #region Getters

        public int GetRoomType()
        {
            return type;
        }

        public int GetRoomID()
        {
            return roomID;
        }

        #endregion

    }
}
