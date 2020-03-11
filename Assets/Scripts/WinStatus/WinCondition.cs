using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    /// <summary>
    /// Base class for all win condition checks, extends IStatus
    /// </summary>
    public class WinCondition : MonoBehaviour, IStatus
    {
        public bool pIsReady { get; set; }
        private bool mInitialized;

        public virtual void Init()
        {
            mInitialized = true;
        }

        public virtual void Update()
        {
            if (!mInitialized)
                return;
        }
    }

}
