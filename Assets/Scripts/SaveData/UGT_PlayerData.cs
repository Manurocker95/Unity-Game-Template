using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Save
{
    public class UGT_PlayerData : UGT_CharacterData
    {
        /// <summary>
        /// Player position - in world space
        /// </summary>
        public Vector3 m_playerPosition;
        /// <summary>
        /// Player rotation
        /// </summary>
        public Quaternion m_playerRotation;
        /// <summary>
        /// Player Local Scale
        /// </summary>
        public Vector3 m_playerScale;
        /// <summary>
        /// Constructor
        /// </summary>
        public UGT_PlayerData()
        {
            m_level = 1;
            m_HP = 100;
            m_maxHP = 100;
            m_name = "Manuel";
            m_completeName = "Manuel Rodríguez Matesanz";
            m_stats = new UGT_Stats();
            m_status = STATUS.NONE;
            m_playerPosition = Vector3.zero;
            m_playerScale = Vector3.zero;
            m_playerRotation = Quaternion.identity;
        }
    }

}
