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
            Vector3 centerPosition = new Vector3(0, 0, 0);
            _rb.velocity = (centerPosition - transform.position).normalized * Random.Range(_soapConfig.SpeedRange.x, _soapConfig.SpeedRange.y);
            _rb.angularVelocity = Random.Range(_soapConfig.RotateSpeed.x, _soapConfig.RotateSpeed.y);
            Destroy(gameObject, _soapConfig.LifeTime);
        }
    }
}