using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Arcade1942
{
    /// <summary>
    /// Inherits from BaseMovement and Handles movement in X,Y axis
    /// The sound for player flight's Idle and movement is also handled here
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class PlayerMovement : BaseMovement
    {
        [Header(" -- Keyboard axis keys -- ")]
        [SerializeField] private string m_HorizontalKey = default;
        [SerializeField] private string m_ForwardKey = default;
        [Header("-- Player movement audio --")]
        [SerializeField] private Utilities.MinMax m_MovingPitchRange = default;
        [SerializeField] private Utilities.MinMax m_IdlingPitchRange = default;
        [SerializeField] private float m_MovingVolume = default;
        [SerializeField] private float m_IdlingVolume = default;

        private AudioSource mAudioSource;
        private bool mIsIdlePlaying;
        private Vector3 movementVector = default;
        private Bounds mCameraBounds;
        private Coroutine mUpdateSound;

        protected override void Start()
        {
            base.Start();

            mAudioSource = GetComponent<AudioSource>();

            float minX = Camera.main.transform.position.x - Camera.main.orthographicSize;
            float maxX = Camera.main.transform.position.x + Camera.main.orthographicSize;
            float minY = Camera.main.transform.position.y - Camera.main.orthographicSize;
            float maxY = Camera.main.transform.position.y + Camera.main.orthographicSize;
            mCameraBounds.SetMinMax(new Vector3(minX, minY, 0), new Vector3(maxX, maxY, 0));
        }

        public void AllowMovement(bool value)
        {
            if (value)
                StartMovement();
            else
                EndMovement();
        }

        /// <summary>
        /// get the keyboard inputs and calculates movementVector every frame.
        /// </summary>
        protected override void Move()
        {
            movementVector = new Vector2(Input.GetAxis(m_HorizontalKey) * m_Speed.x, Input.GetAxis(m_ForwardKey) * m_Speed.y) * Time.deltaTime;
            transform.Translate(movementVector, Space.Self);

            if (!mCameraBounds.Contains(transform.position))
                transform.position = new Vector3(mCameraBounds.ClosestPoint(transform.position).x, mCameraBounds.ClosestPoint(transform.position).y, transform.position.z);
            
            UpdateEngineSound(movementVector);
        }

        /// <summary>
        /// Handles flight sound based on the movement vector. 
        /// Idle and movement sounds
        /// </summary>
        /// <param name="movement">current movement vector</param>
        private void UpdateEngineSound(Vector3 movement)
        {
            if (movement == Vector3.zero && !mIsIdlePlaying)
            {
                //Player is Idling
                mIsIdlePlaying = true;

                if(mUpdateSound != null)
                    StopCoroutine(mUpdateSound);
                mUpdateSound = StartCoroutine(UpdateSounds(m_IdlingVolume, Random.Range(m_IdlingPitchRange.Min, m_IdlingPitchRange.Max), 0.5f));

                mAudioSource.Play();
            }
            else if (movement != Vector3.zero && mIsIdlePlaying)
            {
                mIsIdlePlaying = false;

                if (mUpdateSound != null)
                    StopCoroutine(mUpdateSound);
                mUpdateSound = StartCoroutine(UpdateSounds(m_MovingVolume, Random.Range(m_MovingPitchRange.Min, m_MovingPitchRange.Max), 0.5f));
                mAudioSource.Play();
            }
        }

        IEnumerator UpdateSounds(float volume, float pitch, float duration)
        {
            float timeRemaining = duration;
            float curVolume = mAudioSource.volume;
            float curPitch = mAudioSource.pitch;

            while(timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                mAudioSource.volume = Mathf.Lerp(curVolume, volume, Mathf.InverseLerp(duration, 0, timeRemaining));
                mAudioSource.pitch = Mathf.Lerp(curPitch, pitch, Mathf.InverseLerp(duration, 0, timeRemaining));
                yield return null;
            }
            mAudioSource.volume = volume;
            mAudioSource.pitch = pitch;
        }       
    }
}

