/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Example
{
    /// <summary>
    /// Example class. Just shows a few texts 
    /// </summary>
    public class UGT_EventExample : UGT_Example
    {

        // Use this for initialization
        void Start()
        {
            StartAllListeners();
        }
        /// <summary>
        /// We stop listening on destroy
        /// </summary>
        private void OnDestroy()
        {
            StopAllListeners();
        }

        void StartAllListeners()
        {
            UGT_EventManager.StartListening(UGT_EventSetup.Example.EXAMPLE_EVENT, ShowEventNoParameters);
            UGT_EventManager.StartListening<int>(UGT_EventSetup.Example.EXAMPLE_EVENT_2, ShowEventOneParameter);
            UGT_EventManager.StartListening<int, int>(UGT_EventSetup.Example.EXAMPLE_EVENT_3, ShowEventTwoParameters);
        }

        void StopAllListeners()
        {
            UGT_EventManager.StopListening(UGT_EventSetup.Example.EXAMPLE_EVENT, ShowEventNoParameters);
            UGT_EventManager.StopListening<int>(UGT_EventSetup.Example.EXAMPLE_EVENT_2, ShowEventOneParameter);
            UGT_EventManager.StopListening<int,int>(UGT_EventSetup.Example.EXAMPLE_EVENT_3, ShowEventTwoParameters);
        }

        protected override void Update()
        {
            base.Update();
        }
        /// <summary>
        /// Method called from button
        /// </summary>
        public void StartEventWithoutParameter()
        {
            UGT_EventManager.TriggerEvent(UGT_EventSetup.Example.EXAMPLE_EVENT);
        }
        /// <summary>
        /// Method called from button
        /// </summary>
        public void StartEventWithParameter(int value)
        {
            UGT_EventManager.TriggerEvent<int>(UGT_EventSetup.Example.EXAMPLE_EVENT_2, value);
        }
        /// <summary>
        /// Method called from button
        /// </summary>
        public void StartEventWith2Parameter(int value)
        {
            UGT_EventManager.TriggerEvent<int, int>(UGT_EventSetup.Example.EXAMPLE_EVENT_3, value, value+1);
        }
        /// <summary>
        /// Method called when the no parameter event is called
        /// </summary>
        void ShowEventNoParameters()
        {
            Debug.Log("No parameters :D");
        }

        /// <summary>
        /// Method called when the two parameters event is called
        /// </summary>
        void ShowEventTwoParameters(int val1, int val2)
        {
            Debug.Log("Values: " + val1 + " and " + val2);
        }
        /// <summary>
        /// Method called when the one parameter event is called
        /// </summary>
        void ShowEventOneParameter(int val)
        {
            Debug.Log("Value: " + val);
        }
    }
}
