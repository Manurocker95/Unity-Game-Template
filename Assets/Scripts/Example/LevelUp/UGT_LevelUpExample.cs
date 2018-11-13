using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.Game;

namespace UnityGameTemplate.Example
{
    public class UGT_LevelUpExample : UGT_Example
    {

        // Use this for initialization
        void Start()
        {

        }

        protected override void Update()
        {

            if (UGT_InputManager.IsKeyCodePressedDown(KeyCode.L))
            {
                UGT_GameManager.Instance.Player.LevelUp();
            }

            base.Update();
        }
    }

}
