using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate
{
    public class UGT_GameEvent : MonoBehaviour, UGT_Actionable
    {
        /// <summary>
        /// If it uses Unity Events or Unity Send Message
        /// </summary>
        [SerializeField] private GAME_EVENT_TYPE m_type = GAME_EVENT_TYPE.SEND_MESSAGE;
        /// <summary>
        /// If the event must be triggered when an event is listened, On Action or On Trigger Enter
        /// </summary>
        [SerializeField] private GAME_EVENT_TRIGGER m_trigger = GAME_EVENT_TRIGGER.ON_ACTION;
        /// <summary>
        /// If wanna use send message, which objects do you wanna call
        /// </summary>
        [SerializeField] private string[] m_triggerTags;
        /// <summary>
        /// If wanna use send message, which objects do you wanna call
        /// </summary>
        [SerializeField] private GameObject[] m_relatedGOs;
        /// <summary>
        /// If wanna use send message, which methods do you wanna call. The rest uses Unity Events and only the first one in the array
        /// </summary>
        [SerializeField] private string[] m_events;
        /// <summary>
        /// Events that this game event can be listening to
        /// </summary>
        [SerializeField] private string[] m_listeningEvents;
        
        // Use this for initialization
        void Start()
        {
            if (m_trigger == GAME_EVENT_TRIGGER.ON_EVENT)
            {
                foreach (string ev in m_listeningEvents)
                {
                    UGT_EventManager.StartListening(ev, DoEvent);
                }
            }
        }

        void OnDestroy()
        {
            if (m_trigger == GAME_EVENT_TRIGGER.ON_EVENT)
            {
                foreach (string ev in m_listeningEvents)
                {
                    UGT_EventManager.StopListening(ev, DoEvent);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnAction()
        {
            if (m_trigger == GAME_EVENT_TRIGGER.ON_ACTION)
            {
                DoEvent();
            }

        }

        void DoEvent()
        {
            switch (m_type)
            {
                case GAME_EVENT_TYPE.UNITY_EVENT:
                    UGT_EventManager.TriggerEvent(m_events[0]);
                    break;
                case GAME_EVENT_TYPE.SHOW_DIALOG:
                    UGT_DialogManager.ShowDialog(m_events[0]);
                    break;
                case GAME_EVENT_TYPE.SEND_MESSAGE:
                    int index = 0;
                    foreach (GameObject go in m_relatedGOs)
                    {
                        go.SendMessage(m_events[index]);
                        index++;
                    }
                    break;
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_trigger == GAME_EVENT_TRIGGER.ON_ENTER)
            {
                foreach (string go in m_triggerTags)
                {
                    if (collision.gameObject.tag == go)
                    {
                        DoEvent();
                        break;
                    }
                }
            }
        }
    }

    public enum GAME_EVENT_TYPE
    {
        SEND_MESSAGE,
        UNITY_EVENT,
        SHOW_DIALOG
    }

    public enum GAME_EVENT_TRIGGER
    {
        ON_ENTER,
        ON_ACTION,
        ON_EVENT
    }
}
