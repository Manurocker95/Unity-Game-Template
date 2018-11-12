/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate
{
    /// <summary>
    /// Menu Class. Goes to each example scene
    /// </summary>
    public class UGT_Menu : MonoBehaviour
    {
        [SerializeField] private bool m_loadByEvent = true;

        // Use this for initialization
        void Start()
        {

        }

        /// <summary>
        /// Exit event - As I want to show how to use events, lets use one instead of simply Application.Quit();
        /// </summary>
        public void ExitGame()
        {
            UGT_EventManager.TriggerEvent(UGT_EventSetup.Menu.EXIT);
        }

        /// <summary>
        /// Same with load scene ;)
        /// </summary>
        /// <param name="_scene"></param>
        public void LoadScene(int _scene)
        {
            if (m_loadByEvent)
                UGT_EventManager.TriggerEvent<int>(UGT_EventSetup.Scene.LOAD_SCENE, _scene);
            else
                UGT_SceneManager.LoadScene(_scene);
        }
    }

}
