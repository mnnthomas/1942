using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// An Abstarct base class for Bullets. 
    /// This class handles Instantiating, Collision and destroying of all types of bullet
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseBullet : MonoBehaviour
    {
        [SerializeField] protected BulletData m_BulletData = default;

        protected Transform mCurTarget;
        protected Vector3 mCurDirection;
        protected bool mInitialized;

        protected Rigidbody2D mRigidbody;
        private float mStartTime;

        private void OnEnable()
        {
            mRigidbody = GetComponent<Rigidbody2D>();
            mStartTime = Time.time;
        }

        public abstract void Initialize(Vector3 barrelForward, Transform target = null);

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollided(other.gameObject);
        }

        protected virtual void Update()
        {
            if (Time.time - mStartTime >= m_BulletData.DurationAlive && isActiveAndEnabled)
                DestroyBullet();
        }

        protected virtual void OnCollided(GameObject obj)
        {
            Debug.Log(" >> " + obj.name);
            if (obj.GetComponent<IHealth>() != null)
                obj.GetComponent<IHealth>().TakeDamage(m_BulletData.Damage);

            DestroyBullet();
        }

        protected virtual void DestroyBullet()
        {
            mInitialized = false;
            mCurDirection = default;
            mCurTarget = default;
            ObjectPoolManager.pInstance.ReturnToPool(gameObject);
        }

    }

}
