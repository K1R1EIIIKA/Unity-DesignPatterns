using System.Collections;
using UnityEngine;

namespace Soap
{
    public interface ISoapSpawn
    {
        public IEnumerator StartSpawnSoap();
        public GameObject SpawnSoap();
    }
}