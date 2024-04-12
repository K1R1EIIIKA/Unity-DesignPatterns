using UnityEngine;

namespace Soap.Strategies
{
    public class SoapChasing : ISoapStrategy
    {
        public void Move(SoapMovement soap, Transform target)
        {
            soap.Rb.velocity = (target.position - soap.transform.position).normalized * soap.BaseSpeed;
        }
    }
}