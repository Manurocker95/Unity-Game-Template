/*===============================================================*
 *                                                               *
 *       Script made by Manuel Rodríguez Matesanz                *
 *          Free to use if credits are given                     *
 *                                                               *
 *===============================================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityGameTemplate
{
    /// <summary>
    /// * This is a modified version of Unity's Event Tutorial.
    /// * From any script you can call: 
    /// 
    /// UGT_EventManager.StartListening(EventName, methodToCallbackWhenTriggered);
    /// 
    /// * to start listening a specific event. Remember to stop listening on destroy so you don't have listener bugs
    /// 
    /// UGT_EventManager.StopListening(EventName, sameStartListeningMethod);
    /// 
    /// * And if you want to trigger an event, just call:
    /// 
    /// UGT_EventManager.TriggerEvent(EventName);
    /// 
    /// * For easier use, you can store event names in UGT_EventSetup. Then call it from anywhere:
    /// 
    /// UGT_EventManager.TriggerEvent(UGT_EventSetup.Localization.TRANSLATE_TEXTS);
    /// </summary>
    public class UGT_EventManager : UGT_SingletonMonobehaviour<UGT_EventManager>
    {
        /// <summary>
        /// Event dictionary
        /// </summary>
        private Dictionary<string, UnityEvent> eventDictionary;

        /// <summary>
        /// Dictionary initialization
        /// </summary>
        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }
        /// <summary>
        /// The desired object is now listening if it wasn't
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void StartListening(string eventName, UnityAction listener)
        {
            if (Instance == null)
                return;

            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance.eventDictionary.Add(eventName, thisEvent);
            }
        }
        /// <summary>
        /// The desired object is no longer listening
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void StopListening(string eventName, UnityAction listener)
        {
            if (Instance == null)
                return;

            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }
        /// <summary>
        /// Triggers the event and calls every object that is listening to that event
        /// </summary>
        /// <param name="eventName"></param>
        public static void TriggerEvent(string eventName)
        {
            if (Instance == null)
                return;

            UnityEvent thisEvent = null;
            if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}
