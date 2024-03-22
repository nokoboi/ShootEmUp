using UnityEngine;

namespace Shmup
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "Shmup/EnemyType", order = 0)]
    public class EnemyType : ScriptableObject
    {
        public GameObject enemyPrefab;
        public GameObject weapoPrefab;
        public float speed;
    }
}
