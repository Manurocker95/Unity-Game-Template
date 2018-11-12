/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.Inventory;

namespace UnityGameTemplate.Save
{
    /// <summary>
    /// Serialized game data.Loaded when needed
    /// </summary>
    public class UGT_SaveData
    {
        public UGT_PlayerData m_playerData;
        public List<UGT_InventoryItem> m_inventoryData;

        /// <summary>
        /// Constructor
        /// </summary>
        public UGT_SaveData()
        {
            m_playerData = new UGT_PlayerData();
            m_inventoryData = new List<UGT_InventoryItem>();
        }
    }

}
