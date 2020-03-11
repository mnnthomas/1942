using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Arcade1942
{
    [System.Serializable]
    public class ScoreMap
    {
        public GameObject _Type;
        public float _Score;
    }

    [CreateAssetMenu(menuName = "Arcade1942/ScoreData")]
    public class ScoreData : ScriptableObject
    {
        public int _PlayerLives;
        public List<ScoreMap> _ScoreMap = new List<ScoreMap>();

        //TODO :Might have to refactor
        public float GetScoreForEnemy(GameObject obj)
        {
            float value = 0;
            ScoreMap map = _ScoreMap.Find(x => obj.name.StartsWith(x._Type.name));
            if (map != null)
                value = map._Score;

            return value;
        }
    }
}
