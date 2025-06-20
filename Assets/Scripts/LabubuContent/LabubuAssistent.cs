using System.Collections;
using ClientsContent;
using RestaurantContent.CashRegisterContent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LabubuContent
{
    public class LabubuAssistent : MonoBehaviour
    {
        [SerializeField] private CashRegister _cashRegister;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _clips;
        [SerializeField] private Animator _animator;
        [SerializeField] private ClientAppearance _clientAppearance;

        private Coroutine _checkCoroutine;
        private bool _isWork = false;

        private void Start()
        {
            _clientAppearance.ChoiceAppearance();
            _clientAppearance.ChoiceAccessories();

            /*if (_checkCoroutine != null)
                StopCoroutine(_checkCoroutine);

            _checkCoroutine = StartCoroutine(CheckForClient());*/
        }

        private void Update()
        {
            if (_cashRegister.СurrentClient != null && !_animator.GetBool("Call"))
            {
                _isWork = true;
                
                if (_checkCoroutine != null)
                    StopCoroutine(_checkCoroutine);

                _checkCoroutine = StartCoroutine(CheckForClient());

                _animator.SetBool("Call", true);
            }

            if (_cashRegister.СurrentClient == null && _animator.GetBool("Call"))
            {
                _isWork = false;
                
                if (_checkCoroutine != null)
                    StopCoroutine(_checkCoroutine);

                _animator.SetBool("Call", false);
            }
        }

        private IEnumerator CheckForClient()
        {
            while (_isWork)
            {
                if (_cashRegister.СurrentClient != null)
                    _audioSource.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);

                yield return new WaitForSeconds(3f);
            }
        }
    }
}