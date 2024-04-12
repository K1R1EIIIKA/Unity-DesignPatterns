using System;
using DefaultNamespace;
using UnityEngine;

namespace Player.Health
{
    public class HealthLogic : MonoBehaviour
    {
        private int Health => PlayerLogic.Instance.Stats.CurrentHealth;
        private int MaxHealth => PlayerLogic.Instance.Stats.MaxHealth;

        [SerializeField] private GameObject _heartPrefab;

        private void Start()
        {
            EventBus.Instance.AddListener(GameEvent.OnHealthChanged, UpdateHealth);
            UpdateHealth();
        }

        private void UpdateHealth()
        {
            DestroyHealth();

            for (int i = 0; i < MaxHealth; i += 2)
            {
                var heart = Instantiate(_heartPrefab, new Vector3(i, 0, 0), Quaternion.identity, transform);
                var heartComponent = heart.GetComponent<Heart>();

                if (i + 1 < Health)
                {
                    heartComponent.ChangeState(HealthState.Full);
                }
                else if (i + 1 == Health)
                {
                    heartComponent.ChangeState(HealthState.Half);
                }
                else
                {
                    heartComponent.ChangeState(HealthState.Empty);
                }
            }
        }

        private void DestroyHealth()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}