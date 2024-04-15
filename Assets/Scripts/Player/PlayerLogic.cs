using Soap;
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
            EnemyHit(other.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            EnemyHit(other.gameObject);
        }

        private void EnemyHit(GameObject other)
        {
            if (!other.CompareTag("Enemy")) return;
            
            Stats.TakeDamage(1);
            other.GetComponent<ISoap>().PlayHitSound();

            if (Stats.CurrentHealth == 0)
                Debug.Log("Player died");
        }
    }
}