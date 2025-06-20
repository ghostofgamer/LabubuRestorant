using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TrafficCity
{
    public class TrafficGame : MonoBehaviour
    {
        [SerializeField] protected Transform Container;
        [SerializeField] protected int SpawnAmount;
        [SerializeField] protected int MaxActiveObject;
        
        [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
        [SerializeField] private float _otherDurationSeconds;
        
        
        protected int ActiveObjects = 0;
        protected WaitForSeconds WaitOneSecond = new WaitForSeconds(1f);
        protected WaitForSeconds WaitOtherSeconds ;

        public List<SpawnPoint> SpawnPoints => _spawnPoints;

        public virtual void Start()
        {
            WaitOtherSeconds = new WaitForSeconds(_otherDurationSeconds);
            
        }
        
        protected IEnumerator SpawnNPC()
        {
            while (true)
            {
                if (ActiveObjects > MaxActiveObject)
                    yield return WaitOtherSeconds;
                else
                    yield return WaitOneSecond;
                
                int index = Random.Range(0, _spawnPoints.Count);
                
                SpawnRandomObject(_spawnPoints[index]);
            }
        }

        public virtual  void SpawnRandomObject(SpawnPoint spawnPoint)
        {
        }
        
        public void IncreaseActiveNPC()
        {
            ActiveObjects++;
        }

        public void DecreaseActiveNPC()
        {
            ActiveObjects--;

            if (ActiveObjects <= 0)
                ActiveObjects = 0;
        }
    }
}
