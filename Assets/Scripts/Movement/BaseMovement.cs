using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// An abstract base movement class
    /// Handles StartMovment and EndMovement scenarios, Runs the abstract move method in Update after movement is init
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseMovement : MonoBehaviour
    {
        [SerializeField] protected Vector2 m_Speed = default;
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
    }
}
