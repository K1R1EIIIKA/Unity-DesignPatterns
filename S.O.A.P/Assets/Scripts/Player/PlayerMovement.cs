using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Animator _animator;
        private Vector3 _movement;
        private Rigidbody2D _rb;
        
        private readonly int Speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            HandleInputAxes();

            _animator.SetFloat(Speed, _movement.magnitude);
        
            _rb.velocity = new Vector2(_movement.x * PlayerLogic.Instance.Stats.Speed, _movement.y * PlayerLogic.Instance.Stats.Speed);
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
