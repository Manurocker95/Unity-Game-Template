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
    /// * Instead of mapping the KeyCodes in many scripts, we just ask this script
    /// * to tell if that keyCode is pressed
    /// * Just call:
    /// 
    /// UGT_InputManager.IsConfirmInputPressedDown();
    /// </summary>
    public class UGT_InputManager : UGT_SingletonMonobehaviour<UGT_InputManager>
    {
        [SerializeField] private KeyCode[] m_InteractKeyCodes = { KeyCode.Return, KeyCode.Joystick1Button0, KeyCode.Space };
        [SerializeField] private KeyCode[] m_LevelUpKeyCodes = { KeyCode.U };
        [SerializeField] private KeyCode[] m_SaveKeyCodes = { KeyCode.S };
        [SerializeField] private KeyCode[] m_LoadKeyCodes = { KeyCode.L };

        // Use this for initialization
        void Start()
        {

        }
        /// <summary>
        /// Confirm button / Interact
        /// </summary>
        /// <returns></returns>
        bool _IsConfirmInputPressedDown(bool _down = false)
        {
            if (_down)
            {
                foreach (KeyCode kc in m_InteractKeyCodes)
                {
                    if (Input.GetKeyDown(kc))
                        return true;
                }
            }
            else
            {
                foreach (KeyCode kc in m_InteractKeyCodes)
                {
                    if (Input.GetKey(kc))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// If we are in unity editor we can press this keys to manually level up
        /// </summary>
        /// <returns></returns>
        bool _DebugLevelUpInput(bool _down = false)
        {
            if (_down)
            {
                foreach (KeyCode kc in m_LevelUpKeyCodes)
                {
                    if (Input.GetKeyDown(kc))
                        return true;
                }
            }
            else
            {
                foreach (KeyCode kc in m_LevelUpKeyCodes)
                {
                    if (Input.GetKey(kc))
                        return true;
                }
            }
            return false;
        }

        bool _SaveInput(bool _down = false)
        {
            if (_down)
            {
                foreach (KeyCode kc in m_SaveKeyCodes)
                {
                    if (Input.GetKeyDown(kc))
                        return true;
                }
            }
            else
            {
                foreach (KeyCode kc in m_SaveKeyCodes)
                {
                    if (Input.GetKey(kc))
                        return true;
                }
            }
            return false;
        }
        bool _LoadInput(bool _down = false)
        {
            if (_down)
            {
                foreach (KeyCode kc in m_LoadKeyCodes)
                {
                    if (Input.GetKeyDown(kc))
                        return true;
                }
            }
            else
            {
                foreach (KeyCode kc in m_LoadKeyCodes)
                {
                    if (Input.GetKey(kc))
                        return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Any code
        /// </summary>
        /// <param name="kc"></param>
        /// <returns></returns>
        public static bool IsKeyCodePressed(KeyCode kc)
        {
            return Input.GetKey(kc);
        }

        public static bool IsKeyCodePressedDown(KeyCode kc)
        {
            return Input.GetKeyDown(kc);
        }

        /// <summary>
        /// We just set a confirm keys but any keys can be set
        /// </summary>
        /// <returns></returns>
        public static bool IsConfirmInputPressedDown(bool _down = true)
        {
            return Instance._IsConfirmInputPressedDown(_down);
        }

        /// <summary>
        /// Keys for leveling up in unity editor
        /// </summary>
        /// <returns></returns>
        public static bool DebugLevelUpInput(bool _down = true)
        {
            return Instance._DebugLevelUpInput(_down);
        }

        /// <summary>
        /// Keys for Saving the game in unity editor
        /// </summary>
        /// <returns></returns>
        public static bool SaveInput(bool _down = true)
        {
            return Instance._SaveInput(_down);
        }
        /// <summary>
        /// Keys for loading the game from editor
        /// </summary>
        /// <returns></returns>
        public static bool LoadInput(bool _down = true)
        {
            return Instance._LoadInput(_down);
        }
    }
}
