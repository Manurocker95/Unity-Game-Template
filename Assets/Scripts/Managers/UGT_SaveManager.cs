/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *                 and Micah Paul Davis                          *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityGameTemplate.Serialization;

namespace UnityGameTemplate.Save
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
            m_path = System.Environment.SpecialFolder.MyDocuments + "/" + m_gameName;
            Directory.CreateDirectory(m_path);
            m_path += UGT_PathSetup.SAVE_FILE;
        }
        /// <summary>
        /// Save the game to a file
        /// </summary>
        public void SaveGame()
        {
            //
            UGT_ComplexFormatter.SaveObjectToDESFile(m_gameData, m_path);
        }
        /// <summary>
        /// Load the data from the file
        /// </summary>
        public void LoadGame()
        {
            if (File.Exists(m_path))
            {
                m_gameData = UGT_ComplexFormatter.LoadObjectFromDESFile < UGT_SaveData > (m_path);

                Debug.Log("Data Saved: Lives = " + m_gameData.lives);

                // Call the manager or whatever you need
            }
            
        }
    }

}
