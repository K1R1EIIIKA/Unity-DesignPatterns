using ScriptableObjects;
using UnityEngine;

namespace Soap.BulletSoap
{
    public class BulletSoap : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Init(BulletSoapSO soapConfig)
        {
            _spriteRenderer.sprite = soapConfig.Sprites[Random.Range(0, soapConfig.Sprites.Length)];
        }
    }
}