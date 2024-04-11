using UnityEngine;

namespace Soap.Strategies
{
    public class SoapChasing : ISoapStrategy
    {
        public void Move(SoapMovement soap, Transform target)
        {
            soap.transform.position =
                Vector3.MoveTowards(
                    soap.transform.position,
                    target.position,
                    soap.Speed * Time.deltaTime);
        }
    }
}