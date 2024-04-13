using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoapConfig", menuName = "ScriptableObjects/SoapConfig", order = 1)]
    public class SoapSO : ScriptableObject
    {
        [Header("Wandering")]
        [SerializeField] private float _wanderRadius = 5f;
        [SerializeField] private float _wanderTimer = 1.5f;
        
        [Header("Chasing")]
        [SerializeField] private float _baseSpeed = 2f;
        
        [Header("Dashing")]
        [SerializeField] private float _dashRange = 3f;
        [SerializeField] private float _dashPreparationTime = 1.5f;
        [SerializeField] private float _dashTime = 1f;
        [SerializeField] private float _dashCooldown = 5f;
        [SerializeField] private float _dashForce = 5f;
        
        public float WanderRadius => _wanderRadius;
        public float WanderTimer => _wanderTimer;
        public float BaseSpeed => _baseSpeed;
        public float DashRange => _dashRange;
        public float DashPreparationTime => _dashPreparationTime;
        public float DashTime => _dashTime;
        public float DashCooldown => _dashCooldown;
        public float DashForce => _dashForce;
    }
}