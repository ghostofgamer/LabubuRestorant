using TrafficCity;
using UnityEngine;
using UnityEngine.AI;

namespace LabubuContent
{
    public class LabubuNPC : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private Renderer _labubuRenderer;
        [SerializeField] private GameObject[] _accessories;
        [SerializeField] private GameObject[] _bodies;
        [SerializeField] private GameObject[] _eyes;
        [SerializeField] private GameObject[] _tails;
        [SerializeField] private GameObject[] _mounth;
        
        private NPCTraffic _npcTraffic;
        private Transform[] _points;
        private int _index = 0;
        private float _minDistance = 1f;

        private void Update()
        {
            Roam();
        }

        public void Init(GameObject path, NPCTraffic npcTraffic, Texture texture)
        {
            _npcTraffic = npcTraffic;

            /*Material newMaterial = new Material(_labubuRenderer.sharedMaterial);
            newMaterial.mainTexture = texture;
            _labubuRenderer.material = newMaterial;*/

            _points = new Transform[path.transform.childCount];

            for (int i = 0; i < _points.Length; i++)
                _points[i] = path.transform.GetChild(i);

            ChoiceAccessories();
            ChoiceAppearance();
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
            _animator.SetFloat("Vertical", !_navMeshAgent.isStopped ? 1 : 0);
        }

        private void ChoiceAccessories()
        {
            foreach (var accessory in _accessories)
                accessory.SetActive(false);

            _accessories[Random.Range(0, _accessories.Length)].SetActive(true);
        }

        private void ChoiceAppearance()
        {
            foreach (var body in _bodies)
                body.SetActive(false);
            
            foreach (var eyes in _eyes)
                eyes.SetActive(false);
            
            foreach (var tail in _tails)
                tail.SetActive(false);
            
            foreach (var mounth in _mounth)
                mounth.SetActive(false);

            _bodies[Random.Range(0, _bodies.Length)].SetActive(true);
            _eyes[Random.Range(0, _eyes.Length)].SetActive(true);
            _tails[Random.Range(0, _tails.Length)].SetActive(true);
            _mounth[Random.Range(0, _mounth.Length)].SetActive(true);
        }
    }
}