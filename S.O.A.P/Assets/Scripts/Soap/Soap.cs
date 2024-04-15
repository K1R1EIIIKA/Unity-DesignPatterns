using Audio;
using UnityEngine;

namespace Soap
{
    public class Soap : MonoBehaviour, ISoap
    {
        public void PlayHitSound()
        {
            AudioManager.Instance.Play("Soap Hit");
        }
    }
}