using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Example
{
    public class UGT_DialogExample : UGT_Example
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        public void ShowTestDialog()
        {
            UGT_DialogManager.ShowDialog("TestDialog");
        }
    }
}
