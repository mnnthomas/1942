using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class StraightMovement : BaseMovement
    {
        Vector2 movementVector;

        private void OnEnable()
        {
            StartMovement();
        }

        protected override void Move()
        {
            movementVector = new Vector2(m_Speed.x, m_Speed.y) * Time.deltaTime;
            transform.Translate(movementVector, Space.Self);
        }
    }
}
