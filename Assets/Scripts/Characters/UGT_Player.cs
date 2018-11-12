/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using UnityGameTemplate.Localization;
using UnityGameTemplate.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Game
{
    public class UGT_Player : UGT_Character
    {
        // Your variables go here

    
        // Use this for initialization
        protected override void Awake()
        {
            base.Awake();
            UGT_GameManager.Instance.Player = this;
            Data = new UGT_PlayerData();
        }

        // Use this for initialization
        protected override void Start ()
        {
            base.Start();
           
        }
	
	    // Update is called once per frame
	    protected override void Update ()
        {
            base.Update();

        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.m_isObjectDetected)
            {
                if (UGT_InputManager.IsConfirmInputPressedDown())
                {
                    this.m_objectDetected.OnAction();
                }
            }

        }

        public void SetupData(UGT_PlayerData _data)
        {
            Data = _data;
            m_AbilityTree.SetAbilitiesByCharacterLevel();

            this.transform.position = _data.m_playerPosition;
            this.transform.rotation = _data.m_playerRotation;
            this.transform.localScale = _data.m_playerScale;
        }
    }

}
