using UnityEngine;

namespace Soap.Strategies
{
    public interface ISoapStrategy
    {
        void Move(SoapMovement soap, Transform target);
    }
}