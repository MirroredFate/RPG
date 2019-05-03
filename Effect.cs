using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Effect
    {
        int effectID;
        int type; //1 - Attack | 2 - Heal

        int healAmount;
        int damageAmount;

        string useText;

        public Effect(int ID = 0, int type = 0, int healAmount = 0, int damageAmount = 0, string useText = "")
        {
            this.effectID = ID;
            this.type = type;
            switch (type)
            {
                case 1:
                    this.damageAmount = damageAmount;
                    break;
                case 2:
                    this.healAmount = healAmount;
                    break;
                default:
                    this.damageAmount = 0;
                    this.healAmount = 0;
                    break;
            }
            this.useText = useText;
        }

        #region Setter

        public void SetEffectType(int type)
        {
            this.type = type;
        }

        public void SetHealAmount(int amount)
        {
            this.healAmount = amount;
        }

        public void SetDamageAmount(int amount)
        {
            this.damageAmount = amount;
        }


        #endregion

        #region Getter

        public int GetEffectID()
        {
            return effectID;
        }

        public int GetEffectType()
        {
            return type;
        }

        public int GetHealAmount()
        {
            return healAmount;
        }

        public int GetDamageAmount()
        {
            return damageAmount;
        }

        public string GetUseText()
        {
            return useText;
        }

        #endregion
    }
}
