/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *                 and Micah Paul Davis                          *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate
{
    /// <summary>
    /// * Instead of mapping the KeyCodes in many scripts, we just ask this script
    /// * to tell if that keyCode is pressed
    /// * Just call:
    /// 
    /// UGT_InputManager.IsConfirmInputPressedDown();
    /// </summary>
    public class UGT_InputManager : UGT_SingletonMonobehaviour<UGT_InputManager>
    {
        [SerializeField] private KeyCode[] m_InteractKeyCodes = { KeyCode.Return, KeyCode.Joystick1Button0, KeyCode.Space };

        // Use this for initialization
        void Start()
        {

        }
        /// <summary>
        /// Private 
        /// </summary>
        /// <returns></returns>
        bool _IsConfirmInputPressedDown()
        {
            foreach (KeyCode kc in m_InteractKeyCodes)
            {
                if (Input.GetKeyDown(kc))
                    return true;
            }
            return false;
        }

        public static bool IsKeyCodePressed (KeyCode kc)
        {
            return Input.GetKey(kc);
        }

        /// <summary>
        /// We just set a confirm keys but any keys can be set
        /// </summary>
        /// <returns></returns>
        public static bool IsConfirmInputPressedDown() 
        {
            return Instance._IsConfirmInputPressedDown();
        }
    }

}
