
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.Save;

namespace UnityGameTemplate
{
    /// <summary>
    /// General Character.
    /// </summary>
    public class UGT_Character : MonoBehaviour
    {
        /// <summary>
        /// Character Data. need to be overrided in each child
        /// </summary>
        public UGT_CharacterData Data;
        /// <summary>
        /// Our ability tree. Serialized for debug.
        /// </summary>
        protected UGT_AbilityTree m_AbilityTree;
        /// <summary>
        /// Json name. Placed in Resources/path
        /// </summary>
         protected string AbilityJSON = "Data/abilities";
        /// <summary>
        /// Animator
        /// </summary>
        [SerializeField] protected Animator m_animator;
        /// <summary>
        /// Mode
        /// </summary>
        [SerializeField] protected bool m_3DMode = false;
        /// <summary>
        /// Vector for raycasting
        /// </summary>
        [SerializeField] protected Vector3 m_detectionVector;
        /// <summary>
        /// Distance the raycast is set
        /// </summary>
        [SerializeField] protected float m_detectionDistance = 1f;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] protected LayerMask m_detectionLayers;

        protected bool m_isObjectDetected = false;
        protected UGT_Actionable m_objectDetected;

        public bool IsObjectDetected { get { return m_isObjectDetected; } }
        public UGT_Actionable Actionable { get { return m_objectDetected; } }

        // Use this for initialization
        protected virtual void Awake()
        {
            m_AbilityTree = new UGT_AbilityTree(this);          
        }

        // Use this for initialization
        protected virtual void Start()
        {
            m_AbilityTree.PrepareAbilities(AbilityJSON);

            if (!m_animator)
                m_animator = GetComponent<Animator>();

        }

        protected virtual void FixedUpdate()
        {
            m_detectionVector =  (m_3DMode) ? transform.forward : -transform.right;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, m_detectionVector, m_detectionDistance, m_detectionLayers);
            Debug.DrawLine(transform.position, -transform.right * m_detectionDistance, Color.red);

            if (hit.collider != null)
            {
                if (!m_isObjectDetected)
                {
                    m_isObjectDetected = true;
                    m_objectDetected = hit.collider.gameObject.GetComponent<UGT_Actionable>();
                }
            }
            else
            {
                if (m_isObjectDetected)
                {
                    m_isObjectDetected = false;
                    m_objectDetected = null;
                }
            }
        }

        public virtual void LevelUp()
        {
            Data.m_level++;
            Debug.Log("Level up to level " + Data.m_level + "!");
            m_AbilityTree.SetAbilitiesByCharacterLevel();
        }


        public virtual void Heal(int hp)
        {
            if (Data.m_HP + hp <= Data.m_maxHP)
                Data.m_HP += hp;
            else
                Data.m_HP = Data.m_maxHP;
        }

        public virtual void Damage(int hp)
        {
            if (Data.m_HP - hp > 0)
                Data.m_HP -= hp;
            else
                Data.m_HP = 0;
        }

        // Update is called once per frame
        protected virtual void Update()
        {

        }
    }

    public enum STATUS
    {
        NONE,
        BURN,
        FREEZE,
        PARALYZE,
        POISON,
        FAINTED
    }
}
