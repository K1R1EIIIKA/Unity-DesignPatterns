using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace Soap.BulletSoap
{
    public class BulletSoapSpawn : MonoBehaviour, ISoapSpawn
    {
        [SerializeField] private GameObject _soapPrefab;
        [SerializeField] private Transform _soapSpawner;
        [SerializeField] private float _spawnRate = 0.3f;
        [SerializeField] private Vector2 _xSpawnRange = new(-2.5f, 2.5f);
        [SerializeField] private Vector2 _ySpawnRange = new(-4.5f, 4.5f);
        [SerializeField] private BulletSoapSO _soapConfig;

        private void Start()
        {
            StartCoroutine(StartSpawnSoap());
        }

        public IEnumerator StartSpawnSoap()
        {
            SpawnSoap();
            
            yield return new WaitForSeconds(_spawnRate);
            StartCoroutine(StartSpawnSoap());
        }

        public GameObject SpawnSoap()
        {
            int randWall = Random.Range(0, 4);
            Vector3 spawnPosition = Vector3.zero;
            switch (randWall)
            {
                case 0:
                    spawnPosition = new Vector3(Random.Range(_xSpawnRange.x, _xSpawnRange.y), _ySpawnRange.y, 0f);
                    break;
                case 1:
                    spawnPosition = new Vector3(Random.Range(_xSpawnRange.x, _xSpawnRange.y), _ySpawnRange.x, 0f);
                    break;
                case 2:
                    spawnPosition = new Vector3(_xSpawnRange.x, Random.Range(_ySpawnRange.x, _ySpawnRange.y), 0f);
                    break;
                case 3:
                    spawnPosition = new Vector3(_xSpawnRange.y, Random.Range(_ySpawnRange.x, _ySpawnRange.y), 0f);
                    break;
            }

            GameObject soap = Instantiate(_soapPrefab, spawnPosition, Quaternion.identity, _soapSpawner);
            soap.GetComponent<BulletSoap>().Init(_soapConfig);
            
            return soap;
        }
    }
}