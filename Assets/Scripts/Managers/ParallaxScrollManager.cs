using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game.Arcade1942
{
    /// <summary>
    /// ScrollMode defines the direction of parallaxScroll
    /// </summary>
    public enum ScrollMode
    {
        Vertical,
        Horizontal
    };

    /// <summary>
    /// A class template to create 'n' number of ParallaxItems that can be managed by ParallaxScrollManager
    /// </summary>
    [System.Serializable]
    public class ParallaxItem
    {
        public GameObject _ParallaxObject;
        public float _ParallaxSpeed;
        public ScrollMode _ScrollMode = ScrollMode.Horizontal; //Defines the scroll direction 

    }

    public class ParallaxScrollManager : MonoBehaviour
    {
        //Private vars
        private List<Renderer> mParallaxRend = new List<Renderer>();
        private float[] mParallaxPos;
        private float mSpeedMultiplier = 1f; //Used as a common multiplier to manipulate all the parallax object's speed
        private bool mAllowParallax; //Used to toggle on/off parallax scroll


        /// <summary>
        /// ParallaxItemList is exposed in Inspector.
        /// Defines the number of parallax items needed in background and their Name, Speed and Gameobject.
        /// </summary>
        [Header("-- Parallax setup --")]
        public List<ParallaxItem> _ParallaxItemList = new List<ParallaxItem>();

        void Start()
        {
            if (_ParallaxItemList.Count == 0)
            {
                Debug.LogError("No Parallax items setup");
            }
            else
            {
                mParallaxPos = new float[_ParallaxItemList.Count];
                for (int i = 0; i < _ParallaxItemList.Count; i++)
                {
                    mParallaxRend.Add(_ParallaxItemList[i]._ParallaxObject.GetComponent<Renderer>());
                }
            }

            PauseParallax(false);
        }

        public void SetSpeedMultiplier(float value)
        {
            mSpeedMultiplier = value;
        }

        public void PauseParallax(bool value)
        {
            mAllowParallax = !value;
        }

        public void FixedUpdate()
        {
            if (mAllowParallax && mParallaxPos.Length > 0)
            {
                for (int i = 0; i < _ParallaxItemList.Count; i++)
                {
                    mParallaxPos[i] += _ParallaxItemList[i]._ParallaxSpeed * Time.deltaTime * mSpeedMultiplier;
                    if (mParallaxPos[i] > 1f) //Resetting the UV offset values to avoid computation complexity
                        mParallaxPos[i] = 0f;

                    mParallaxRend[i].material.mainTextureOffset = _ParallaxItemList[i]._ScrollMode == ScrollMode.Horizontal ? new Vector2(mParallaxPos[i], 0f) : new Vector2(0f, mParallaxPos[i]);
                }
            }
        }
    }
}


