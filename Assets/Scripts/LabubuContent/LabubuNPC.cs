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
        
        private NPCTraffic _npcTraffic;
        private Transform[] _points;
        private int _index = 0;
        private float _minDistance = 1f;

        private void Update()
        {
            Roam();
        }

        public void Init(GameObject path,NPCTraffic npcTraffic,Texture texture)
        {
            _npcTraffic = npcTraffic;
            
            Material newMaterial = new Material(_labubuRenderer.sharedMaterial);
            newMaterial.mainTexture = texture;
            _labubuRenderer.material = newMaterial;
            
            _points = new Transform[path.transform.childCount];

            for (int i = 0; i < _points.Length; i++)
                _points[i] = path.transform.GetChild(i);
        } 

        /*private void Roam()
        {
            if (Vector3.Distance(transform.position, _points[_index].position) < _minDistance)
                _index = (_index + 1) % _points.Length; 

            _navMeshAgent.SetDestination(_points[_index].position);
            _animator.SetFloat("Vertical", !_navMeshAgent.isStopped ? 1 : 0);
        }*/
        
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
    }
}