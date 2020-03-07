using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Arcade1942
{
    /// <summary>
    /// _Name - Name of the object to spawn (referes to name in ObjectPool)
    /// _Delay - Time between spawns
    /// _SpawnAsSquad - Allows continuous spawn to make AI look like a squad
    /// _SquadCount - Squad count for continuous spawn
    /// _SquadSpawnDelay - Delay between continuous spawn
    /// </summary>
    [System.Serializable]
    public class ObjectSpawnData
    {
        public string _Name;
        public float _Delay;
        [Header(" -- Squad Spawn -- ")]
        public bool _SpawnAsSquad;
        public int _SquadCount;
        public float _SquadSpawnDelay;
    }

    /// <summary>
    /// A common place to spawn different movable objects in game (AI, Props, etc-)
    /// </summary>
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private List<ObjectSpawnData> m_ObjectSpawns = new List<ObjectSpawnData>();

        private bool mAllowSpawn = false;

        private void Start()
        {
            Invoke("StartSpawnning", 5f);
        }

        public void StartSpawnning()
        {
            mAllowSpawn = true;
            for(int i = 0; i < m_ObjectSpawns.Count; i++)
            {
                StartCoroutine(ObjectSpawn(m_ObjectSpawns[i]));
            }
        }
        
        public void StopSpawnning()
        {
            mAllowSpawn = false;
        }

        IEnumerator ObjectSpawn(ObjectSpawnData data)
        {
            while(mAllowSpawn)
            {
                if (!data._SpawnAsSquad)
                    ObjectPoolManager.pInstance.SpawnObject(data._Name, transform.position);
                else
                {
                    for(int i = 0; i < data._SquadCount; i++)
                    {
                        ObjectPoolManager.pInstance.SpawnObject(data._Name, transform.position);
                        yield return new WaitForSeconds(data._SquadSpawnDelay);
                    }
                }
                yield return new WaitForSeconds(data._Delay);
            }
        }


    }
}

