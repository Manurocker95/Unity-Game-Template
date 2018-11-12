/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace UnityGameTemplate.Save
{
    /// <summary>
    /// Player Data serialized in encrypted JSON
    /// </summary>
    [System.Serializable]
    public class UGT_CharacterData
    {
        public int m_level = 1;
        /// <summary>
        /// Current HP
        /// </summary>
        public int m_HP = 100;
        /// <summary>
        /// Max HP
        /// </summary>
        public int m_maxHP = 100;
        /// <summary>
        /// User Name 
        /// </summary>
        public string m_name = "Chara";
        /// <summary>
        /// Full name
        /// </summary>
        public string m_completeName = "Complete name";
        /// <summary>
        /// Status
        /// </summary>
        public STATUS m_status;
        /// <summary>
        /// Stats
        /// </summary>
        public UGT_Stats m_stats;
        /// <summary>
        /// Constructor
        /// </summary>
        public UGT_CharacterData()
        {
            m_level = 1;
            m_HP = 100;
            m_maxHP = 100;
            m_name = "Chara";
            m_completeName = "Complete name";
            m_stats = new UGT_Stats();
            m_status = STATUS.NONE;
        }
    }

}
