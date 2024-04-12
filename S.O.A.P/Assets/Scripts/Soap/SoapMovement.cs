using System;
using Player;
using Soap.Strategies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Soap
{
    public class SoapMovement : MonoBehaviour
    {
        [Header("Wandering")]
        public float WanderRadius = 5f;
        public float WanderTimer = 1.5f;
        
        [Header("Chasing")]
        public float BaseSpeed = 2f;
        
        [Header("Dashing")]
        public float DashRange = 3f;
        public float DashPreparationTime = 1.5f;
        public float DashTime = 1f;
        public float DashCooldown = 5f;
        public float DashForce = 5f;
        
        private Transform _target;
        [NonSerialized] public Rigidbody2D Rb;
        [NonSerialized] public Collider2D Collider;
        
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
            
            if (distance < DashRange)
                ChangeStrategy(_soapDashing);
            else if (distance < WanderRadius)
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
                Rb.velocity = (transform.position - other.transform.position).normalized * BaseSpeed / 2;
            }
        }
    }
}