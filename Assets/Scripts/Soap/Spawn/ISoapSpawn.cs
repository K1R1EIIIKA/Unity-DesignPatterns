using System.Collections;
using UnityEngine;

namespace Soap
{
    public interface ISoapSpawn
    {
        public float StartSpawnTime { get; }
        public IEnumerator StartSpawnSoap();
        public GameObject SpawnSoap();
    }
}