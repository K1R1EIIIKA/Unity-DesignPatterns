using System;
using Audio;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Soap.BulletSoap
{
    public class BulletSoap : MonoBehaviour, ISoap
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Init(BulletSoapSO soapConfig)
        {
            _spriteRenderer.sprite = soapConfig.Sprites[Random.Range(0, soapConfig.Sprites.Length)];
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }

        public void PlayHitSound()
        {
            AudioManager.Instance.Play("BulletSoap Hit");
        }
    }
}