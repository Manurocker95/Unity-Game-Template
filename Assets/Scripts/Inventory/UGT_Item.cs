/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Inventory
{
    /// <summary>
    /// Script assigned to a gameobject in the scene. When touching this gameobject, it will disappear.
    /// If it needed, when touching it, this script will trigger an event. If not, the effect will 
    /// take place when using it from Inventory.
    /// </summary>
    public class UGT_Item : MonoBehaviour
    {
        /// <summary>
        /// Type of the object. As it is a small game, we will have a few types of items.
        /// </summary>
        [SerializeField] private ITEM_TYPES m_type = ITEM_TYPES.TRIGGER;
        /// <summary>
        /// Internal name for storing the object in the dictionary. it's the key.
        /// </summary>
        [SerializeField] private string m_internalName = "TestID";
        /// <summary>
        /// Name displayed when the inventory shows info about the selected item
        /// </summary>
        [SerializeField] private string m_itemName = "Test";
        /// <summary>
        /// Description of the item. Just the key for using the TextManager as translator
        /// </summary>
        [SerializeField] private string m_itemDescriptionKey = "TestDesc";
        /// <summary>
        /// How much effect does it have. E.G: If healing, how much does it heal
        /// </summary>
        [SerializeField] private int m_effectCount = 20;
        /// <summary>
        /// Trigger called on touch or when using it
        /// </summary>
        [SerializeField] private string m_trigger = "";
        /// <summary>
        /// If the trigger is called OnTriggerEnter
        /// </summary>
        [SerializeField] private bool m_onTouch = false;
        
        /// <summary>
        /// Properties
        /// </summary>
        public ITEM_TYPES ItemType { get { return m_type; } }
        public string InternalName { get { return m_internalName; } }
        public string ItemName { get { return m_itemName; } }
        public string Description { get { return m_itemDescriptionKey; } }
        public string Trigger { get { return m_trigger; } }
        public int EffectCount { get { return m_effectCount; } }
        /// <summary>
        /// When the player touches this GO, the object disappears and the item is added
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == UGT_GameSetup.Tags.PLAYER && !UGT_InventoryManager.Instance.HasItemReachedLimit(this))
            {
                if (!string.IsNullOrEmpty(m_trigger) && m_onTouch)
                    UGT_EventManager.TriggerEvent(m_trigger);

                this.gameObject.SetActive(false);
            }
     
        }
    }

}
