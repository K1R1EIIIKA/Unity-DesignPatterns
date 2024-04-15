using System.Collections;
using UnityEngine;

namespace Soap.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        private ISoapSpawn[] _soapSpawners;
        
        private void Start()
        {
            _soapSpawners = GetComponentsInChildren<ISoapSpawn>();
            
            SpawnSoaps();
        }

        private void SpawnSoaps()
        {
            foreach (var spawner in _soapSpawners)
            {
                StartCoroutine(SpawnSoapWithDelay(spawner, spawner.StartSpawnTime));
            }
        }

        private IEnumerator SpawnSoapWithDelay(ISoapSpawn soapSpawn, float delay)
        {
            yield return new WaitForSecondsRealtime(delay);
            
            StartCoroutine(soapSpawn.StartSpawnSoap());
        }
    }
}