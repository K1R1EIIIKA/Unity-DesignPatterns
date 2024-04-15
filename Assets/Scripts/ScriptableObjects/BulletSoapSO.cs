using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletSoapSO", menuName = "ScriptableObjects/BulletSoapSO", order = 1)]
    public class BulletSoapSO : ScriptableObject
    {
        [SerializeField] private Vector2 _speedRange = new(2f, 6f);
        [SerializeField] private Vector2 _rotateSpeed = new(100f, 200f);
        [SerializeField] private int _damage = 1;
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private Sprite[] _sprites;
        
        public Vector2 SpeedRange => _speedRange;
        public Vector2 RotateSpeed => _rotateSpeed;
        public int Damage => _damage;
        public float LifeTime => _lifeTime;
        public Sprite[] Sprites => _sprites;
    }
}