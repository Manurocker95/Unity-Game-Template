/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using UnityGameTemplate.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGameTemplate.Game
{
    /// <summary>
    /// * Game manager class. The core of the game should go here.
    /// * Or the main parts... you know
    /// </summary>
    public class UGT_GameManager : UGT_SingletonMonobehaviour<UGT_GameManager>
    {
        /// <summary>
        /// Player Reference - Variable Assigned from the player itself :D
        /// </summary>
        public UGT_Player Player;

        // Use this for initialization
        void Start()
        {
            StartAllListeners();
        }

        void StartAllListeners()
        {
            UGT_EventManager.StartListening(UGT_EventSetup.Menu.EXIT, ExitGame);
            UGT_EventManager.StartListening(UGT_EventSetup.Menu.OPEN_WEB, OpenWeb);
        }

        void StopAllListeners()
        {
            UGT_EventManager.StopListening(UGT_EventSetup.Menu.EXIT, ExitGame);
            UGT_EventManager.StartListening(UGT_EventSetup.Menu.OPEN_WEB, OpenWeb);
        }

        private void OnDestroy()
        {
            StopAllListeners();
        }
        /// <summary>
        /// Open an URL
        /// </summary>
        void OpenWeb()
        {
            Application.OpenURL(UGT_GameSetup.General.WEB_URL);
        }
        /// <summary>
        /// Exit the game
        /// </summary>
        void ExitGame()
        {
            Debug.Log("Exit Game");
            Application.Quit();
        }
    }

}
