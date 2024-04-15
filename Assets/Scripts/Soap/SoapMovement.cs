using System;
using Player;
using ScriptableObjects;
using Soap.Strategies;
using UnityEngine;

namespace Soap
{
    public class SoapMovement : MonoBehaviour
    {
        public SoapSO SoapConfig;
        
        [NonSerialized] public Rigidbody2D Rb;
        [NonSerialized] public Collider2D Collider;
        
        private Transform _target;
        private ISoapStrategy _soapStrategy;
        private SoapDashing _soapDashing;
        private SoapWandering _soapWandering;
        private SoapChasing _soapChasing;
        
        private void Start()
        {
            ChangeStrategy(new SoapWandering());
            Rb = GetComponent<Rigidbody2D>();
            Collider = GetComponent<Collider2D>();
            _target = PlayerLogic.Instance.transform;
            
            _soapDashing = new SoapDashing();
            _soapWandering = new SoapWandering();
            _soapChasing = new SoapChasing();
        }

        private void Update()
        {
            ChooseStrategy();

            _soapStrategy.Move(this, _target);
        }

        private void ChooseStrategy()
        {
            float distance = Vector2.Distance(transform.position, _target.position);
            
            if (distance < SoapConfig.DashRange)
                ChangeStrategy(_soapDashing);
            else if (distance < SoapConfig.WanderRadius)
                ChangeStrategy(_soapChasing);
            else
                ChangeStrategy(_soapWandering);
        }

        private void ChangeStrategy(ISoapStrategy newStrategy)
        {
            _soapStrategy = newStrategy;
            Debug.Log($"Strategy changed to {_soapStrategy.GetType().Name}");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                Rb.velocity = (transform.position - other.transform.position).normalized * SoapConfig.BaseSpeed / 2;
            }
        }
    }
}