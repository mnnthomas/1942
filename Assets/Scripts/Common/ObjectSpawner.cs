﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// _Name - Name of the object to spawn (referes to name in ObjectPool)
    /// _InitDelay - Time before first spawn
    /// _SpawnInterval - Time between spawns
    /// _SpawnAsSquad - Allows continuous spawn to make AI look like a squad
    /// _SquadCount - Squad count for continuous spawn
    /// _SquadSpawnDelay - Delay between continuous spawn
    /// </summary>
    [System.Serializable]
    public class ObjectSpawnData
    {
        public string _Name;
        public float _InitDelay;
        public Utilities.MinMax _SpawnInterval;
        public BoxCollider2D _SpawnArea;
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
        private List<Coroutine> mSpawnCoroutines = new List<Coroutine>();


        private bool mAllowSpawn = false;

        public void StartSpawnning()
        {
            mAllowSpawn = true;
            for(int i = 0; i < m_ObjectSpawns.Count; i++)
            {
                mSpawnCoroutines.Add(StartCoroutine(ObjectSpawn(m_ObjectSpawns[i])));
            }
        }
        
        public void StopSpawnning()
        {
            mAllowSpawn = false;
            for (int i = 0; i < mSpawnCoroutines.Count; i++)
                StopCoroutine(mSpawnCoroutines[i]);
        }

        IEnumerator ObjectSpawn(ObjectSpawnData data)
        {
            while(mAllowSpawn)
            {
                Vector3 spawnPoint = transform.position;
                if(data._SpawnArea != null)
                    spawnPoint = new Vector3(Random.Range(data._SpawnArea.bounds.min.x, data._SpawnArea.bounds.max.x), data._SpawnArea.transform.position.y, transform.position.z);

                yield return new WaitForSeconds(data._InitDelay);

                if (!data._SpawnAsSquad)
                    ObjectPoolManager.pInstance.SpawnObject(data._Name, spawnPoint);
                else
                {
                    for(int i = 0; i < data._SquadCount; i++)
                    {
                        ObjectPoolManager.pInstance.SpawnObject(data._Name, spawnPoint);
                        yield return new WaitForSeconds(data._SquadSpawnDelay);
                    }
                }
                yield return new WaitForSeconds(Random.Range(data._SpawnInterval.Min, data._SpawnInterval.Max));
            }
        }


    }
}

