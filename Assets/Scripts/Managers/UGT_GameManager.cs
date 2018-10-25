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

namespace UnityGameTemplate.Game
{
    /// <summary>
    /// * Game manager class. The core of the game should go here.
    /// * Or the main parts... you know
    /// </summary>
    public class UGT_GameManager : UGT_SingletonMonobehaviour<UGT_GameManager>
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (UGT_InputManager.IsConfirmInputPressedDown())
                Debug.Log("CONFIRM BUTTON");
        }
    }

}
