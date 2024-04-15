using System.Collections;
using UnityEngine;

namespace Soap.Strategies
{
    public class SoapDashing : ISoapStrategy
    {
        private bool _isDashing;
        private bool _isCooldown;

        public void Move(SoapMovement soap, Transform target)
        {
            if (!_isCooldown)
                soap.StartCoroutine(PrepareDash(soap, target));
        }

        private IEnumerator PrepareDash(SoapMovement soap, Transform target)
        {
            _isCooldown = true;
            _isDashing = false;

            yield return new WaitForSeconds(soap.SoapConfig.DashPreparationTime);
            if (_isDashing) yield break;

            soap.StartCoroutine(Dash(soap, target));
        }

        
        private IEnumerator Dash(SoapMovement soap, Transform target)
        {
            _isDashing = true;
            soap.Collider.isTrigger = true;

            soap.Rb.AddForce((target.position - soap.transform.position).normalized * soap.SoapConfig.DashForce,
                ForceMode2D.Impulse);
            
            yield return new WaitForSeconds(soap.SoapConfig.DashTime);
            soap.Collider.isTrigger = false;

            yield return new WaitForSeconds(soap.SoapConfig.DashCooldown);
            _isCooldown = false;
        }
    }
}