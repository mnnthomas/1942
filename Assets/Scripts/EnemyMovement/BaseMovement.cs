using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField] protected float m_Speed = default;
        public bool pIsMoving { get; private set; }

        protected Rigidbody2D mRigidbody;

        protected abstract void Move();

        protected virtual void Start()
        {
            mRigidbody = GetComponent<Rigidbody2D>();
        }

        protected virtual void StartMovement()
        {
            pIsMoving = true;
        }

        protected virtual void EndMovement()
        {
            pIsMoving = false;
        }

        protected void FixedUpdate()
        {
            if (pIsMoving)
                Move();
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            ObjectPoolManager.pInstance.ReturnToPool(gameObject);
        }
    }
}
