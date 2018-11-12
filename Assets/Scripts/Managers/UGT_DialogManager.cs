using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate
{
    public class UGT_DialogManager : UGT_SingletonMonobehaviour<UGT_DialogManager>
    {

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
           // Show custom
        }

        public static void ShowDialog(string key)
        {
            Instance._ShowDialog(key);
        }
    }

}
