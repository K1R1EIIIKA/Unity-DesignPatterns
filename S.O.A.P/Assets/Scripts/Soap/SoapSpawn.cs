using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Soap
{
    public class SoapSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _soapPrefab;
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _spawnRate;
        [SerializeField] private Vector2 _spawnRange;

        private void Start()
        {
            StartCoroutine(SpawnSoap());
        }

        private IEnumerator SpawnSoap()
        {
            var randomPosition = GetRandomPosition();
            Debug.Log(randomPosition);
                
            Instantiate(_soapPrefab, randomPosition, Quaternion.identity, _spawnPoint);
            
            yield return new WaitForSeconds(_spawnRate);
            StartCoroutine(SpawnSoap());
        }

        private Vector3 GetRandomPosition()
        {
            var randomPosition = new Vector3(Random.Range(-_spawnRange.x, _spawnRange.x), Random.Range(-_spawnRange.y, _spawnRange.y), 0);
            
            if (_target != null)
            {
                while (Vector3.Distance(randomPosition, _target.position) < 3f)
                {
                    randomPosition = new Vector3(Random.Range(-_spawnRange.x, _spawnRange.x), Random.Range(-_spawnRange.y, _spawnRange.y), 0);
                }
            }
            return randomPosition;
        }
    }
}