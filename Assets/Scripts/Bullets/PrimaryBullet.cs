using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Inherits from BulletBase, Handle specific cases for primary bullet functionality
    /// </summary>
    public class PrimaryBullet : BulletBase
    {
        public override void InitializeBullet(Vector3 barrelForward, Transform target = null)
        {
            mCurDirection = barrelForward;
            mInitialized = true;

            mRigidbody.velocity = mCurDirection * m_BulletData.Speed;
        }
    }
}
