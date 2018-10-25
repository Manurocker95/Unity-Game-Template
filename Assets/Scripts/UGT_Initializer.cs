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

namespace UnityGameTemplate
{
    /// <summary>
    /// Script just set to change from initializer scene to the first scene
    /// Should be the menu scene
    /// </summary>
    public class UGT_Initializer : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            UGT_SceneManager.LoadScene(1);
        }
    }
}

