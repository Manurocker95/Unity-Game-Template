/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using SimpleJSON;


namespace UnityGameTemplate
{
    public class UGT_AbilityTree
    {
        /// <summary>
        /// Usable abilities by the player
        /// </summary>
        private Dictionary<string, UGT_Ability> m_myAbilities;
        /// <summary>
        /// Reference to the character that uses those abilities
        /// </summary>
        [SerializeField] private UGT_Character m_character;

        public UGT_AbilityTree( )
        {
            m_myAbilities = new Dictionary<string, UGT_Ability>();
        }

        public UGT_AbilityTree(UGT_Character _character)
        {
            m_character = _character;
            m_myAbilities = new Dictionary<string, UGT_Ability>();
        }

        /// <summary>
        /// We read abilities from JSON and save them in our dictionary
        /// </summary>
        /// <param name="json_path"></param>
        public void PrepareAbilities(string json_path)
        {
            int level = m_character.Data.m_level;

            JSONNode info = JSON.Parse(Resources.Load(json_path).ToString());
            for (int i = 0; i < info["skilltree"].Count; i++)
            {
                UGT_Ability ability = new UGT_Ability(info["skilltree"][i]);

                // We have that ability
                if (level >= ability.LevelToUnlock)
                {
                    m_myAbilities.Add(ability.ID, ability);

                    //Each ability checks it's evolutions
                    for (int j = 0; j < ability.evolutions.Count; j++)
                    {
                        if (level >= ability.evolutions[j].LevelToUnlock)
                        {
                            m_myAbilities.Add(ability.evolutions[j].ID, ability);
                            Debug.Log("Learned " + ability.evolutions[j].ID);
                        }
                    }
                }
            }
        }

        public void SetAbilitiesByCharacterLevel()
        {
            if (m_myAbilities == null)
                Debug.Log("There are no abilities");

            int level = m_character.Data.m_level;
            List<UGT_Ability> abilities_to_learn = new List<UGT_Ability>();

            foreach (string key in m_myAbilities.Keys)
            {
                UGT_Ability ab = m_myAbilities[key];
          
                //Each ability checks it's evolutions
                for (int j = 0; j < ab.evolutions.Count; j++)
                {
                    if (level >= ab.evolutions[j].LevelToUnlock && !m_myAbilities.ContainsKey(ab.evolutions[j].ID))
                    {
                        abilities_to_learn.Add(ab.evolutions[j]);
                        Debug.Log("Learned " + ab.evolutions[j].ID);
                    }
                }
            }

            for (int i = 0; i < abilities_to_learn.Count; i++)
            {
                m_myAbilities.Add(abilities_to_learn[i].ID, abilities_to_learn[i]);
            }

        }

        public UGT_Ability getAbilityByKey(string key)
        {
            return m_myAbilities[key];
        }
    }

}
