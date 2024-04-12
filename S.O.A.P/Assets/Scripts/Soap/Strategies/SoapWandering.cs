using System.Collections;
using UnityEngine;

namespace Soap.Strategies
{
    public class SoapWandering : ISoapStrategy
    {
        private bool _isWandering;

        public void Move(SoapMovement soap, Transform target)
        {
            if (_isWandering) return;

            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            Vector3 wanderPosition = soap.transform.position + randomDirection * soap.WanderRadius;

            soap.StartCoroutine(Wander(soap, wanderPosition));
        }

        private IEnumerator Wander(SoapMovement soap, Vector3 wanderPosition)
        {
            _isWandering = true;
            soap.Rb.velocity = (wanderPosition - soap.transform.position).normalized * soap.BaseSpeed;

            yield return new WaitForSeconds(soap.WanderTimer);

            _isWandering = false;
        }
    }
}