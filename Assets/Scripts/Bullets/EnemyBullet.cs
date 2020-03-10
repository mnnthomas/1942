using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Inherits from BaseBullet, Handle specific initalization for moving towards player with a randomized offset
    /// </summary>
    public class EnemyBullet : BaseBullet
    {
        [SerializeField] private Utilities.MinMax m_BulletAimOffset = default;

        public override void Initialize(Vector2 barrelForward, Transform target = null)
        {
            Vector2 playerTransform = PlayerMovement.pPlayer.transform.position;
            playerTransform += new Vector2(Random.Range(m_BulletAimOffset.Min, m_BulletAimOffset.Max), Random.Range(m_BulletAimOffset.Min, m_BulletAimOffset.Max));


            mCurDirection = (playerTransform - (Vector2)transform.position).normalized;
            mInitialized = true;

            mRigidbody.velocity = mCurDirection * m_BulletData.Speed;
        }
    }

}
