using System;
using Soap;
using Soap.Strategies;
using UnityEngine;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        public PlayerStats Stats;
        
        public static PlayerLogic Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (Stats.TakeDamage(1) == 0)
                {
                    Debug.Log("Player died");
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (Stats.TakeDamage(1) == 0)
                {
                    Debug.Log("Player died");
                }
            }
        }
    }
}
