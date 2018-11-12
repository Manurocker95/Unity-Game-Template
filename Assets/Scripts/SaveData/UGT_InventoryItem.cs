using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Inventory
{
    /// <summary>
    /// Item data stored in Inventory Dictionary. 
    /// I's like MS_Item in data but without any behaviour
    /// </summary>
    [System.Serializable]
    public class UGT_InventoryItem
    {
        /// <summary>
        /// this properties are the ame as MS_Item
        /// </summary>
        public string m_keyInDictionary;
        public string m_itemName;
        public string m_itemDescription;
        public ITEM_TYPES m_itemType;
        public int m_effectCount = 20;  // if heal status this is the one that will cure
        public string m_trigger;
        public int m_quantity = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_name"></param>
        /// <param name="_desc"></param>
        /// <param name="_type"></param>
        /// <param name="_trigger"></param>
        public UGT_InventoryItem(string _key, string _name, string _desc, ITEM_TYPES _type, string _trigger, int effectCount)
        {
            m_keyInDictionary = _key;
            m_itemName = _name;
            m_itemDescription = _desc;
            m_itemType = _type;
            m_trigger = _trigger;
            m_quantity = 1;
        }
    }

    public enum ITEM_TYPES
    {
        ATTACK, // Can attack with this
        BOOST,  // Boost user's stats
        DAMAGE, // Damage life to the user
        HEAL,   // Heal the user (HP)
        HEAL_STATUS,    // Heal just the status
        TRIGGER // Trigger a game event when using
    }
}
