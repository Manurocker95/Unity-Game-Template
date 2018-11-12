using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.Inventory;

namespace UnityGameTemplate
{
    public class UGT_SaveExample : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (UGT_InputManager.IsKeyCodePressed(KeyCode.I))
            {
                UGT_InventoryManager.Instance.AddItem(new UGT_Item());
            }

            if (UGT_InputManager.SaveInput())
            {
                UGT_SaveManager.Instance.SaveGame();
            }

            if (UGT_InputManager.LoadInput())
            {
                UGT_SaveManager.Instance.LoadGame();
            }
        }
    }

}
