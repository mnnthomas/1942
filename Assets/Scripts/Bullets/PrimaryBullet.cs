using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Inherits from BaseBullet, Handle specific initalization for player's primary bullet functionality
    /// </summary>
    public class PrimaryBullet : BaseBullet
    {
        public override void Initialize(Vector3 barrelForward, Transform target = null)
        {
            mCurDirection = barrelForward;
            mInitialized = true;

            mRigidbody.velocity = mCurDirection * m_BulletData.Speed;
        }
    }
}
