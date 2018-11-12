using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate
{
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
            if (UGT_InputManager.IsKeyCodePressed(KeyCode.Escape))
                BackToMenu();

        }

        protected virtual void BackToMenu()
        {
            if (m_usingEvents)
                UGT_EventManager.TriggerEvent<int>(UGT_EventSetup.Scene.LOAD_SCENE, 1);
            else
                UGT_SceneManager.LoadScene(1);

        }

    }

}
