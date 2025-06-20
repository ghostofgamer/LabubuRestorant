using UnityEngine;
using UnityEngine.AI;

namespace TrafficCity
{
    public class TrafficCar : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Renderer _labubuRenderer;
        [SerializeField] private GameObject[] _accessories;

        private CarsTraffic _npcTraffic;
        private Transform[] _points;
        private int _index = 0;
        private float _minDistance = 1f;

        private void Update()
        {
            Roam();
        }

        public void Init(GameObject path, CarsTraffic npcTraffic)
        {
            _npcTraffic = npcTraffic;

            // Material newMaterial = new Material(_labubuRenderer.sharedMaterial);
            
            
            
            // _labubuRenderer.sharedMaterial = material;
            
            
            
            // newMaterial.mainTexture = texture;
            // _labubuRenderer.material = newMaterial;*/

            _points = new Transform[path.transform.childCount];

            for (int i = 0; i < _points.Length; i++)
                _points[i] = path.transform.GetChild(i);

            // ChoiceAccessories();
        }

        private void Roam()
        {
            if (Vector3.Distance(transform.position, _points[_index].position) < _minDistance)
            {
                _index = (_index + 1) % _points.Length;

                if (_index == 0)
                {
                    _npcTraffic.DecreaseActiveNPC();
                    gameObject.SetActive(false);
                    return;
                }
            }

            _navMeshAgent.SetDestination(_points[_index].position);
        }

        private void ChoiceAccessories()
        {
            foreach (var accessory in _accessories)
                accessory.SetActive(false);

            _accessories[Random.Range(0, _accessories.Length)].SetActive(true);
        }
    }
}