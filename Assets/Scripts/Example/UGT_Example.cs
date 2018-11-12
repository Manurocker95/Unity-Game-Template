/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Example
{
    /// <summary>
    /// Base class for simple example scripts
    /// </summary>
    public class UGT_Example : MonoBehaviour
    {
        [Header("Configuration"), Space(10)]
        /// <summary>
        /// If false, we call scene manager directly
        /// </summary>
        [SerializeField] protected bool m_usingEvents = true;

        protected virtual void Update()
        {
            /// Other Input check example
            if (UGT_InputManager.IsKeyCodePressedDown(KeyCode.Escape))
                BackToMenu();

        }
        /// <summary>
        /// We go to menu from each example when pressing Escape - 
        /// </summary>
        protected virtual void BackToMenu()
        {
            if (m_usingEvents)
                UGT_EventManager.TriggerEvent<int>(UGT_EventSetup.Scene.LOAD_SCENE, 1);
            else
                UGT_SceneManager.LoadScene(1);

        }

    }

}
