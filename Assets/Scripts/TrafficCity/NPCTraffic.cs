using System.Collections;
using System.Collections.Generic;
using LabubuContent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TrafficCity
{
    public class NPCTraffic : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
        [SerializeField] private LabubuNPC[] _prefabs;
        [SerializeField] private Transform _container;
        [SerializeField] private int _spawnAmount;
        [SerializeField] private Texture[] _textures;

        private List<ObjectPool<LabubuNPC>> _labubuNPCPools = new List<ObjectPool<LabubuNPC>>();
        private int _activeNPC = 0;
        private WaitForSeconds _waitOneSecond = new WaitForSeconds(1f);
        private WaitForSeconds _waitFiveSeconds = new WaitForSeconds(3f);

        private void Start()
        {
            foreach (var labubuNpcPrefab in _prefabs)
            {
                var clientPool = new ObjectPool<LabubuNPC>(labubuNpcPrefab, _spawnAmount, _container);
                clientPool.EnableAutoExpand();
                _labubuNPCPools.Add(clientPool);
            }

            StartCoroutine(SpawnNPC());
        }

        protected IEnumerator SpawnNPC()
        {
            while (true)
            {
                if (_activeNPC > 10)
                    yield return _waitFiveSeconds;
                else
                    yield return _waitOneSecond;

                int index = Random.Range(0, _spawnPoints.Count);
                SpawnRandomClient(_spawnPoints[index]);
            }
        }

        public void SpawnRandomClient(SpawnPoint spawnPoint)
        {
            ObjectPool<LabubuNPC> randomPool = _labubuNPCPools[Random.Range(0, _labubuNPCPools.Count)];
            LabubuNPC labubuNPC = randomPool.GetFirstObject();

            if (labubuNPC == null)
            {
                /*labubuNPC = Instantiate(_prefabs[0], _container);
                SetPosition(labubuNPC, spawnPoint);*/
            }
            else
            {
                SetPosition(labubuNPC, spawnPoint);
                labubuNPC.gameObject.SetActive(true);
                IncreaseActiveNPC();
            }
        }

        private void SetPosition(LabubuNPC labubuNpc, SpawnPoint spawnPoint)
        {
            labubuNpc.transform.position = spawnPoint.spawnPosition.position;
            labubuNpc.Init(spawnPoint.pathGroups[Random.Range(0, spawnPoint.pathGroups.Count)], this,
                _textures[Random.Range(0, _textures.Length)]);
        }

        public void IncreaseActiveNPC()
        {
            _activeNPC++;
        }

        public void DecreaseActiveNPC()
        {
            _activeNPC--;

            if (_activeNPC <= 0)
                _activeNPC = 0;
        }
    }

    [System.Serializable]
    public class SpawnPoint
    {
        public Transform spawnPosition;
        public List<GameObject> pathGroups;
    }
}