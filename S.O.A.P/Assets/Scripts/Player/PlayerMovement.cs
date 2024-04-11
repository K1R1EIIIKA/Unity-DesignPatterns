using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
    
        private Animator _animator;
        private Vector3 _movement;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            HandleInputAxes();

            _animator.SetFloat("Speed", _movement.magnitude);
        
            transform.position += _movement * (Time.deltaTime * _speed);
            transform.rotation = Quaternion.Euler(0, _movement.x >= 0 ? 0 : 180, 0);
        }

        private void HandleInputAxes()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            _movement = new Vector3(horizontal, vertical, 0);
            _movement = _movement.normalized;
        }
    }
}
