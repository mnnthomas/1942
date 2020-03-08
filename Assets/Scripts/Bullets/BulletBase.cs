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
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] protected BulletData m_BulletData = default;
        [SerializeField] protected GameObject m_ExplosionParticle = default;

        protected Transform mCurTarget;
        protected Vector3 mCurDirection;
        protected bool mInitialized;

        protected Rigidbody2D mRigidbody;

        private void OnEnable()
        {
            mRigidbody = GetComponent<Rigidbody2D>();
            Invoke("DestroyBullet", m_BulletData.DurationAlive);
        }

        public abstract void InitializeBullet(Vector3 barrelForward, Transform target = null);

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollided(other.gameObject);
        }

        protected virtual void OnCollided(GameObject obj)
        {
            if (m_ExplosionParticle)
                Instantiate(m_ExplosionParticle, transform.position, Quaternion.identity);

            if (obj.GetComponent<IHealth>() != null)
                obj.GetComponent<IHealth>().TakeDamage(m_BulletData.Damage);

            DestroyBullet();
        }

        protected virtual void DestroyBullet()
        {
            ObjectPoolManager.pInstance.ReturnToPool(gameObject);
        }

    }

}
