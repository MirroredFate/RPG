using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Dungeon
    {
        int dungeonID;
        int amountOfRooms;
        int currentRoom;

        DungeonRoom[] rooms;

        public Dungeon(int dungeonID = 0, int amountOfRooms = 1)
        {
            this.dungeonID = dungeonID;
            this.amountOfRooms = amountOfRooms;
            this.currentRoom = 0;
            rooms = new DungeonRoom[amountOfRooms];
        }

        #region Setters

        public void SetDungeonID(int id)
        {
            this.dungeonID = id;
        }

        public void SetAmountOfRooms(int amount)
        {
            this.amountOfRooms = amount;
        }

        #endregion

        #region Getter

        public int GetDungeonID()
        {
            return dungeonID;
        }

        public int GetAmountOfRooms()
        {
            return amountOfRooms;
        }

        #endregion

    }
}
