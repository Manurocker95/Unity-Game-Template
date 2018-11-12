/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameTemplate.Localization;
using System.Linq;

namespace UnityGameTemplate.Inventory
{
    /// <summary>
    /// Inventory Manager. Stores some items if needed and allows the user to use them if possible.
    /// Shows the current selected item 
    /// </summary>
    public class UGT_InventoryManager : UGT_SingletonMonobehaviour<UGT_InventoryManager>
    {

#if UNITY_EDITOR
        /// <summary>
        /// Just for debugging - As dictionaries can't be shown in inspector, we need 
        /// a list to check everything is correct. Using pragma unity_editor 
        /// just use it on editor so it's okay... I guess.
        /// </summary>
        public List<UGT_InventoryItem> debugItems;
#endif
        /// <summary>
        /// Item dictionary. Instead of a list.
        /// </summary>
        private Dictionary<string, UGT_InventoryItem> m_items;


        /// <summary>
        /// When hiding the inventory, the canvas will be deactivate for optimization
        /// </summary>
        [SerializeField] private GameObject m_inventoryCanvasGO;
        /// <summary>
        /// Inventory Group: Background + items!
        /// </summary>
        [SerializeField] private GameObject m_inventoryGroup;
        /// <summary>
        /// Text where the item name will be set
        /// </summary>
        [SerializeField] private Text m_itemNameText;
        /// <summary>
        /// Text where the item description will be set
        /// </summary>
        [SerializeField] private Text m_itemDescriptionText;
        /// <summary>
        /// Selection index for using an item
        /// </summary>
        private int m_index = 0; 

        /// <summary>
        /// Properties
        /// </summary>
        public Dictionary<string, UGT_InventoryItem> Items { get { return m_items; } }

        protected override void Awake()
        {
            m_destroyOnLoad = true;
            base.Awake();
            m_items = new Dictionary<string, UGT_InventoryItem>();
#if UNITY_EDITOR
            debugItems = new List<UGT_InventoryItem>();
#endif
        }

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// Load the data to the dictionary from the serialized list
        /// </summary>
        /// <param name="_list"></param>
        public void LoadInventory(List<UGT_InventoryItem> _list)
        {
            m_items.Clear();
#if UNITY_EDITOR
            debugItems.Clear(); // todo delete this
#endif
            string key;
            foreach (UGT_InventoryItem item in _list)
            {
                key = item.m_keyInDictionary;
                if (m_items.ContainsKey(key))
                {
                    ++m_items[key].m_quantity;

#if UNITY_EDITOR
                    foreach (UGT_InventoryItem it in debugItems)
                    {
                        if (it.m_keyInDictionary == item.m_keyInDictionary)
                        {
                            ++it.m_quantity;
                            break;
                        }
                    }
#endif

                }
                else
                {
                    m_items.Add(key, item);
#if UNITY_EDITOR
                    debugItems.Add(item);
#endif
                }

            }
        }
        /// <summary>
        /// Save the dictionary to a list
        /// </summary>
        /// <returns></returns>
        public List <UGT_InventoryItem > SaveInventory()
        {
            List<UGT_InventoryItem> itemList = new List<UGT_InventoryItem>();

            foreach (UGT_InventoryItem item in m_items.Values)
            {
                itemList.Add(item);
            }

            return itemList;
        }

        /// <summary>
        /// Add an item to the dictionary if possible. If the limit is reached, a MSG will be shown 
        /// </summary>
        /// <param name="_item"></param>
        public void AddItem(UGT_Item _item)
        {
            string key = _item.InternalName;

            if (m_items.ContainsKey(key))
            {
                ++m_items[key].m_quantity;

#if UNITY_EDITOR
                foreach (UGT_InventoryItem it in debugItems)
                {
                    if (it.m_keyInDictionary == key)
                    {
                        ++it.m_quantity;
                        break;
                    }
                }
#endif
            }
            else
            {
                // We add the item if we did not reached the limit
                if (!InventoryReachedLimit(1))
                {
                    UGT_InventoryItem item = new UGT_InventoryItem(key, UGT_TextManager.GetText(_item.ItemName), UGT_TextManager.GetText(_item.Description), _item.ItemType, _item.Trigger, _item.EffectCount);
                    m_items.Add(key, item);
#if UNITY_EDITOR
                    debugItems.Add(item);
#endif
                }

            }         
        }
        /// <summary>
        /// We return the size of the dictionary. Remember that if we store the same object, the quantity will be increased
        /// </summary>
        /// <returns></returns>
        public int InventoryCount()
        {
            return m_items.Values.Count;
        }
        /// <summary>
        /// Did we reach the limit of each object?
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public bool HasItemReachedLimit(UGT_Item _item)
        {
            string key = _item.InternalName;

            if (!m_items.ContainsKey(key))
            {
                AddItem(_item);
                return false;
            }

            return (m_items.ContainsKey(key) && m_items[key].m_quantity + 1 >= UGT_GameSetup.Inventory.QUANTITY_LIMIT);       
        }

        /// <summary>
        /// We can check the inventory values plus X increase to check the limit
        /// </summary>
        /// <param name="_increases">0 by default - We check directly the current values instead of adding</param>
        /// <returns></returns>
        public bool InventoryReachedLimit(int _increases = 0)
        {
            return InventoryCount() + _increases >= UGT_GameSetup.Inventory.INVENTORY_LIMIT;
        }
        /// <summary>
        /// We use the selected item triggering it's effect
        /// </summary>
        public void UseSelectedItem()
        {
            UGT_InventoryItem item = m_items.Values.ElementAt(m_index);
            
        }
    }

}
