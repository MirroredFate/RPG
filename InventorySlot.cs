using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class InventorySlot
    {
        Item item;
        Item other;
        Equipment equipment;


        int type; //1 - Item | 2 - Equipment | 3 - Other


        #region Getter

        public int GetSlotType()
        {
            SetSlotType();

            return type;
        }

        public Item GetItem()
        {
            return item;
        }

        public Item GetOther()
        {
            return other;
        }

        public Equipment GetEquipment()
        {
            return equipment;
        }

        #endregion

        #region Setter

        public void SetSlotType()
        {
            if(!(item == null))
            {
                type = 1;
                equipment = null;
                other = null;
            }
            else if (!(equipment == null))
            {
                type = 2;
                item = null;
                other = null;
            }
            else if(!(other == null))
            {
                type = 3;
                item = null;
                equipment = null;

            }
        }

        public void SetItem(Item item)
        {
            this.item = item;
        }

        public void SetEquipment(Equipment eq)
        {
            this.equipment = eq;
        }

        public void SetOther(Item other)
        {
            this.other = other;
        }

        #endregion
    }
}
