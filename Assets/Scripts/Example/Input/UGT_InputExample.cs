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

namespace UnityGameTemplate.Example
{
    /// <summary>
    /// Custom script used in Test Input Scene
    /// Just an example
    /// </summary>
    public class UGT_InputExample : UGT_Example
    {
        [Header("Text Reference"), Space(10)]
        /// <summary>
        /// It will display: Confirm button displayed in the current selected language
        /// </summary>
        [SerializeField] private Text m_inputExampleText;

        /// <summary>
        /// Translated texts for not calling everyframe the singleton manager
        /// </summary>
        private string m_confirmInputPressed;
        private string m_confirmInputNotPressed;
        private bool m_confirmPressed = false;

        // Use this for initialization
        void Start()
        {
            m_confirmPressed = false;
            m_confirmInputPressed = UGT_TextManager.GetText(UGT_TextSetup.Inputs.CONFIRM_PRESSED);
            m_confirmInputNotPressed = UGT_TextManager.GetText(UGT_TextSetup.Inputs.CONFIRM_NOT_PRESSED);
            TranslateText(m_confirmPressed);           
        }

        protected override void Update()
        {
            /// Using a variable for debugging :)
            m_confirmPressed = UGT_InputManager.IsConfirmInputPressedDown(false);
            /// Translate the text
            TranslateText(m_confirmPressed);

            base.Update();
        }
        /// <summary>
        /// Set the text based on the language 
        /// </summary>
        /// <param name="_pressed"></param>
        void TranslateText(bool _pressed)
        {
            m_inputExampleText.text = (_pressed) ?  m_confirmInputPressed : m_confirmInputNotPressed;
        }
    }

}
