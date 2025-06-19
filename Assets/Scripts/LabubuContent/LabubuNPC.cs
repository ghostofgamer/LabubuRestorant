using System;
using UnityEngine;
using UnityEngine.AI;

namespace LabubuContent
{
    public class LabubuNPC : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _path;

        private Transform[] _points;
        private int _index = 0;
        private float _minDistance = 1f;

        private void Start()
        {
            _points = new Transform[_path.transform.childCount];

            for (int i = 0; i < _points.Length; i++)
                _points[i] = _path.transform.GetChild(i);
        }

        private void Update()
        {
            Roam();
        }

        private void Roam()
        {
            if (Vector3.Distance(transform.position, _points[_index].position) < _minDistance)
                _index = (_index + 1) % _points.Length; 

            _navMeshAgent.SetDestination(_points[_index].position);
            _animator.SetFloat("Vertical", !_navMeshAgent.isStopped ? 1 : 0);
            
            
            /*if (Vector3.Distance(transform.position, _points[_index].position) < _minDistance)
                if (_index >= 0 && _index < _points.Length)
                    _index += 1;
                else
                    _index = 0;

            _navMeshAgent.SetDestination(_points[_index].position);
            _animator.SetFloat("Vertical", !_navMeshAgent.isStopped ? 1 : 0);*/
        }
    }
}