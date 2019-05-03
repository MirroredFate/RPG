using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class EffectManager
    {
        List<Effect> effectList = new List<Effect>();

        public void LoadEffects()
        {
            #region Healing Effects

            Effect smallHeal = new Effect(
                1,   //ID
                2,   //Type (1 - Attack | 2 - Heal)
                100, //Heal Amount
                0,   //Damage Amount
                "|| Restored 100 Health!" //UseText
                );
            effectList.Add(smallHeal);
            //-----------------------------------
            Effect mediumHeal = new Effect(
                2,  //ID
                2,  //Type (1 - Attack | 2 - Heal)
                300, //Heal Amount
                0,  //Damage Amount
                "|| Restored 300 Health!"
                );
            effectList.Add(mediumHeal);
            //-----------------------------------
            #endregion
        }

        public Effect GetEffect(int id)
        {
            Effect ef = new Effect();

            for (int i = 0; i < effectList.Count; i++)
            {
                if (effectList[i].GetEffectID() == id)
                {
                    ef = effectList[i];
                }
            }

            return ef;
        }

        public int GetEffectType(int id)
        {
            Effect ef = new Effect();

            for (int i = 0; i < effectList.Count; i++)
            {
                if (effectList[i].GetEffectID() == id)
                {
                    ef = effectList[i];
                }
            }

            return ef.GetEffectType();
        }

        public void UseHeal(int effectID, Player player)
        {
            if(GetEffectType(effectID) == 2)
            {
                player.AddHealth(GetEffect(effectID).GetHealAmount());
            }
        }

    }
}
