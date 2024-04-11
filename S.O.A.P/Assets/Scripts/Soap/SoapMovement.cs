using System;
using Soap.Strategies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Soap
{
    public class SoapMovement : MonoBehaviour
    {
        public float Speed = 2f;
        
        [SerializeField] private Transform _target;
        
        private ISoapStrategy _soapStrategy;
        
        private void Start()
        {
            _soapStrategy = new SoapWandering();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeStrategy(new SoapWandering());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeStrategy(new SoapChasing());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeStrategy(new SoapDashing());
            }
            
            _soapStrategy.Move(this, _target);
        }
        
        private void ChangeStrategy(ISoapStrategy newStrategy)
        {
            _soapStrategy = newStrategy;
        }
    }
}