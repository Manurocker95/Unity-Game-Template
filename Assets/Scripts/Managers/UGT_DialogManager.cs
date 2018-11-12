using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace UnityGameTemplate
{
    public class UGT_DialogManager : UGT_SingletonMonobehaviour<UGT_DialogManager>
    {
        public Flowchart m_dialogFlowchart;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void _ShowDialog(string key)
        {
            m_dialogFlowchart.SendFungusMessage(key);
        }

        public static void ShowDialog(string key)
        {
            Instance._ShowDialog(key);
        }
    }

}
