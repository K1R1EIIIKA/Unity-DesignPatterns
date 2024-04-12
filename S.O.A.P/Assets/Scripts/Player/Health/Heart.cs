using UnityEngine;
using UnityEngine.UI;

namespace Player.Health
{
    public class Heart : MonoBehaviour
    {
        public HealthState State;

        private Image _image;
        
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _halfHeart;
        [SerializeField] private Sprite _emptyHeart;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        public void ChangeState(HealthState state)
        {
            State = state;
            switch (State)
            {
                case HealthState.Full:
                    _image.sprite = _fullHeart;
                    break;
                case HealthState.Half:
                    _image.sprite = _halfHeart;
                    break;
                case HealthState.Empty:
                    _image.sprite = _emptyHeart;
                    break;
            }
        }
    }
}