/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityGameTemplate.Serialization;
using UnityGameTemplate.Save;
using UnityGameTemplate.Game;
using UnityGameTemplate.Inventory;

namespace UnityGameTemplate
{
    public class UGT_SaveManager : UGT_SingletonMonobehaviour<UGT_SaveManager>
    {
        /// <summary>
        /// Serialized game data
        /// </summary>
        public UGT_SaveData m_gameData;
        /// <summary>
        /// Folder created in Documents for the save file
        /// </summary>
        [SerializeField] private string m_gameName = "UnityGameTemplate";
        /// <summary>
        /// GameName
        /// </summary>
        private string m_path;

        // Use this for initialization
        void Start()
        {
            m_gameData = new UGT_SaveData();
            m_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\" + m_gameName;

            if (!Directory.Exists(m_path))
            {
                Directory.CreateDirectory(m_path);
                Debug.Log("Creating Path in " + m_path);
            }

            m_path += "\\" + UGT_SaveSetup.SAVE_FILE;
        }
        /// <summary>
        /// Save the game to a file - Just a test - set your data as needed
        /// </summary>
        public void SaveGame()
        {
            if (!UGT_SceneManager.Instance.CanSave())
                return;

            m_gameData.m_inventoryData = UGT_InventoryManager.Instance.SaveInventory();
            m_gameData.m_playerData = (UGT_PlayerData)UGT_GameManager.Instance.Player.Data;

            Transform playerTrs = UGT_GameManager.Instance.Player.transform;
            m_gameData.m_playerData.m_playerPosition = playerTrs.position;
            m_gameData.m_playerData.m_playerRotation = playerTrs.rotation;
            m_gameData.m_playerData.m_playerScale = playerTrs.localScale;

            if (UGT_GameSetup.Game_Settings.ENCRYPT_SAVE_FILES)
                UGT_ComplexFormatter.SaveObjectToDESFile(m_gameData, m_path);
            else if (UGT_GameSetup.Game_Settings.USE_BINARY_SAVE_FILES)
                UGT_ComplexFormatter.SaveObjectToBinaryFile(m_gameData, m_path);
            else
                UGT_ComplexFormatter.SaveObjectoToJSONFile(m_gameData, m_path);

            Debug.Log("Saved the game data in " + m_path);
        }
        /// <summary>
        /// Load the data from the file
        /// </summary>
        public void LoadGame()
        {
            if (File.Exists(m_path))
            {
                if (UGT_GameSetup.Game_Settings.ENCRYPT_SAVE_FILES)
                    m_gameData = UGT_ComplexFormatter.LoadObjectFromDESFile<UGT_SaveData>(m_path);
                else if (UGT_GameSetup.Game_Settings.USE_BINARY_SAVE_FILES)
                    m_gameData = UGT_ComplexFormatter.LoadObjectFromBinaryFile<UGT_SaveData>(m_path);
                else
                    m_gameData = m_gameData = UGT_ComplexFormatter.LoadObjectFromJSONFile<UGT_SaveData>(m_path);


                UGT_InventoryManager.Instance.LoadInventory(m_gameData.m_inventoryData);

                UGT_GameManager.Instance.Player.SetupData(m_gameData.m_playerData);

                Debug.Log("Loaded the game data from " + m_path);
            }
        }
    }

}
