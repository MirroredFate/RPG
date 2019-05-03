using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class SkillManager
    {
        List<Skill> skillList = new List<Skill>();
        Dictionary<int, int> knightSkills = new Dictionary<int, int>();

        #region Getter

        public List<Skill> GetSkillList()
        {
            return skillList;
        }

        public Skill GetSkill(int id)
        {
            Skill sk = new Skill();

            for (int i = 0; i < skillList.Count; i++)
            {
                if(skillList[i].GetID() == id)
                {
                    sk = skillList[i];
                }
            }

            return sk;
        }

        public Dictionary<int, int> GetKnightSkills()
        {
            AddKnightSkills();
            return knightSkills;
        }

        #endregion

        #region Public Methods

        public void LoadSkills()
        {
            #region Magic Skills

            Skill fireball = new Skill(
                "Fireball",  // Name
                1,           // Skill ID
                2,           // Type | 1 = Physical / 2 = Magical
                2,           // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                10,          // Manacost
                15);         // Damage

            skillList.Add(fireball);
            //-------------------------------------------------------
            Skill waterSpear = new Skill(
                "Water Spear",  // Name
                2,           // Skill ID
                2,           // Type | 1 = Physical / 2 = Magical
                3,           // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                10,          // Manacost
                15);         // Damage

            skillList.Add(waterSpear);
            //-------------------------------------------------------
            Skill lightBeam = new Skill(
                "Light Beam",  // Name
                3,           // Skill ID
                2,           // Type | 1 = Physical / 2 = Magical
                5,           // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                20,          // Manacost
                30);         // Damage

            skillList.Add(lightBeam);
            //-------------------------------------------------------
            #endregion

            #region Physical Skills

            Skill heavyblow = new Skill(
                "Heavy Blow",  // Name
                101,           // Skill ID
                1,             // Type | 1 = Physical / 2 = Magical
                1,             // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                10,            // Manacost
                10);           // Damage

            skillList.Add(heavyblow);

            //-------------------------------------------------------
            Skill assassinate = new Skill(
                "Assassinate",  // Name
                102,            // Skill ID
                1,              // Type | 1 = Physical / 2 = Magical
                1,              // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                50,             // Manacost
                25);            // Damage

            skillList.Add(assassinate);

            //-------------------------------------------------------
            Skill piercingArrow = new Skill(
                "Piercing Arrow",  // Name
                103,               // Skill ID
                1,                 // Type | 1 = Physical / 2 = Magical
                1,                 // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                10,                // Manacost
                15);               // Damage

            skillList.Add(piercingArrow);
            //-------------------------------------------------------
            Skill doubleSlash= new Skill(
                "Double Slash",   // Name
                104,               // Skill ID
                1,                 // Type | 1 = Physical / 2 = Magical
                1,                 // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                5,                 // Manacost
                10);               // Damage

            skillList.Add(piercingArrow);
            //-------------------------------------------------------
            Skill execute = new Skill(
                "Execute",   // Name
                105,               // Skill ID
                1,                 // Type | 1 = Physical / 2 = Magical
                1,                 // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                0,                 // Manacost
                50);               // Damage

            skillList.Add(execute);

            #endregion

            #region Healing Skills
            //-------------------------------------------------------
            Skill calmingCry = new Skill(
                "Calming Cry",   // Name
                201,             // Skill ID
                3,               // Type | 1 = Physical / 2 = Magical / 3 = Healing
                1,               // Element Type | 1 = Normal, 2 = Fire, 3 = Water, 4 = Wind, 5 = Light, 6 = Dark
                20,              // Manacost
                0,               // Damage
                1);              // EffectID  

            skillList.Add(calmingCry);


            #endregion

        }

        void AddKnightSkills()
        {
            knightSkills.Add(2, 201);
            knightSkills.Add(5, 105);
        }

        #endregion

    }
}
