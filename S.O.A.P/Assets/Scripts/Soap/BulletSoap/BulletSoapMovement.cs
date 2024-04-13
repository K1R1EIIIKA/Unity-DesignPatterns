using ScriptableObjects;
using UnityEngine;

namespace Soap.BulletSoap
{
    public class BulletSoapMovement : MonoBehaviour
    {
        [SerializeField] private BulletSoapSO _soapConfig;
        
        private Rigidbody2D _rb;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            _rb.velocity = transform.right * Random.Range(_soapConfig.SpeedRange.x, _soapConfig.SpeedRange.y);
            _rb.angularVelocity = Random.Range(_soapConfig.RotateSpeed.x, _soapConfig.RotateSpeed.y);
            Destroy(gameObject, _soapConfig.LifeTime);
        }
    }
}