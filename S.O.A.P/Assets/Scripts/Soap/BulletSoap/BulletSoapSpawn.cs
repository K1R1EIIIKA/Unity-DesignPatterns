using System;
using System.Collections;
using ScriptableObjects;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace Soap.BulletSoap
{
    public class BulletSoapSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _soapPrefab;
        [SerializeField] private Transform _soapSpawner;
        [SerializeField] private float _spawnRate = 0.3f;
        [SerializeField] private BulletSoapSO _soapConfig;

        private void Start()
        {
            StartCoroutine(SpawnSoap());
        }

        private IEnumerator SpawnSoap()
        {
            GameObject soap = Instantiate(_soapPrefab, Vector3.zero, Quaternion.identity, _soapSpawner);
            soap.GetComponent<BulletSoap>().Init(_soapConfig);
            
            yield return new WaitForSeconds(_spawnRate);
            StartCoroutine(SpawnSoap());
        }
    }
}