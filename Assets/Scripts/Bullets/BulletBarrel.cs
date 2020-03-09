﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Handles bullet spawning from the spawn point 
    /// Also takes care of spawn sound and effects
    /// /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class BulletBarrel : MonoBehaviour
    {
        [SerializeField] private Transform m_SpawnPoint = default;
        [SerializeField] private AudioClip m_SpawnClip = default;
        [SerializeField] private string m_BulletName = default;
        private AudioSource mAudioSource;

        void Start()
        {
            mAudioSource = GetComponent<AudioSource>();
        }

        public void Shoot(Transform target = null)
        {
            GameObject bullet;
            bullet = ObjectPoolManager.pInstance.SpawnObject(m_BulletName, m_SpawnPoint.position, Quaternion.identity); 

            if(bullet)
            {
                bullet.GetComponent<BaseBullet>().Initialize(m_SpawnPoint.up, target);

                if (mAudioSource && m_SpawnClip)
                    mAudioSource.PlayOneShot(m_SpawnClip, 1f);
            }
        }
    }
}

