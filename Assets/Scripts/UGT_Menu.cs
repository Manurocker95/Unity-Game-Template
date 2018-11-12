using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate
{
    public class UGT_Menu : MonoBehaviour
    {
        [SerializeField] private bool m_loadByEvent = true;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExitGame()
        {
            UGT_EventManager.TriggerEvent(UGT_EventSetup.Menu.EXIT);
        }

        public void LoadScene(int _scene)
        {
            if (m_loadByEvent)
                UGT_EventManager.TriggerEvent<int>(UGT_EventSetup.Scene.LOAD_SCENE, _scene);
            else
                UGT_SceneManager.LoadScene(_scene);
        }
    }

}
