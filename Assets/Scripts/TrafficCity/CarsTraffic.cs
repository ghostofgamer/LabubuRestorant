using System.Collections.Generic;
using UnityEngine;

namespace TrafficCity
{
    public class CarsTraffic : TrafficGame
    {
        [SerializeField] private TrafficCar[] _prefabs;
        [SerializeField] private Material[] _carMaterials;

        private List<ObjectPool<TrafficCar>> _carsNPCPools = new List<ObjectPool<TrafficCar>>();

        public override void Start()
        {
            base.Start();

            foreach (var labubuNpcPrefab in _prefabs)
            {
                var clientPool = new ObjectPool<TrafficCar>(labubuNpcPrefab, SpawnAmount, Container);
                clientPool.EnableAutoExpand();
                _carsNPCPools.Add(clientPool);
            }

            StartCoroutine(SpawnNPC());
        }

        public override void SpawnRandomObject(SpawnPoint spawnPoint)
        {
            ObjectPool<TrafficCar> randomPool = _carsNPCPools[Random.Range(0, _carsNPCPools.Count)];
            TrafficCar carNPC = randomPool.GetFirstObject();

            if (carNPC != null)
            {
                SetPosition(carNPC, spawnPoint);
                carNPC.gameObject.SetActive(true);
                IncreaseActiveNPC();
            }
        }

        private void SetPosition(TrafficCar labubuNpc, SpawnPoint spawnPoint)
        {
            labubuNpc.transform.position = spawnPoint.spawnPosition.position;
            labubuNpc.Init(spawnPoint.pathGroups[Random.Range(0, spawnPoint.pathGroups.Count)], this);
        }
    }
}