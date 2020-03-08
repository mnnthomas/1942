using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    public class StraightMovement : BaseMovement
    {
        private void OnEnable()
        {
            StartMovement();
        }

        protected override void Move()
        {
            transform.Translate(new Vector2(0, -m_Speed * Time.deltaTime), Space.Self);
        }
    }
}
