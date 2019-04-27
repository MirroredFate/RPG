using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class DungeonManager
    {
        List<Dungeon> dungeons = new List<Dungeon>();
        List<DungeonRoom> rooms = new List<DungeonRoom>();

        #region Getter

        public List<Dungeon> GetDungeonList()
        {
            return dungeons;
        }

        public Dungeon GetDungeon(int id)
        {
            Dungeon dg = new Dungeon();

            for (int i = 0; i < dungeons.Count; i++)
            {
                if(id == dungeons[i].GetDungeonID())
                {
                    dg = dungeons[i];
                }
            }

            return dg;
        }

        public List<DungeonRoom> GetRoomList()
        {
            return rooms;
        }

        #endregion

        
        void LoadRooms()
        {
            DungeonRoom slimeRoom = new DungeonRoom(
                "Slime Room",   // Name
                1,              // Type | 1 = EnemyRoom | 2 = SaveRoom | 3 = TreasureRoom(Item) | 4 = TreasureRoom(Equipment) | 5 = BossRoom
                1,              // ID
                1,              // Amount of Enemies
                1,              // EnemyID
                0,              // ItemID
                0);             // BossID

            rooms.Add(slimeRoom);
            //-------------------------------------------------------------------

            DungeonRoom fireSlimeRoom = new DungeonRoom(
                "Fire Slime Room",    // Name
                1,                    // Type | 1 = EnemyRoom | 2 = SaveRoom | 3 = TreasureRoom(Item) | 4 = TreasureRoom(Equipment) | 5 = BossRoom
                2,                    // ID
                1,                    // Amount of Enemies
                2,                    // EnemyID
                0,                    // ItemID
                0);                   // BossID

            rooms.Add(fireSlimeRoom);
            //-------------------------------------------------------------------



        }


    }
}
