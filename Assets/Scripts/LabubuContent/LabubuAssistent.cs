using System.Collections;
using RestaurantContent.CashRegisterContent;
using UnityEngine;

namespace LabubuContent
{
    public class LabubuAssistent : MonoBehaviour
    {
        [SerializeField] private CashRegister _cashRegister;
        [SerializeField] private AudioSource _audioSource;

        private Coroutine _checkCoroutine;

        private void Start()
        {
            if (_checkCoroutine != null)
                StopCoroutine(_checkCoroutine);

            _checkCoroutine = StartCoroutine(CheckForClient());
        }

        private IEnumerator CheckForClient()
        {
            while (true)
            {
                if (_cashRegister.СurrentClient != null)
                    _audioSource.Play();

                yield return new WaitForSeconds(5f);
            }
        }
    }
}