using System.Collections;
using RestaurantContent.CashRegisterContent;
using UnityEngine;

namespace LabubuContent
{
    public class LabubuAssistent : MonoBehaviour
    {
        [SerializeField] private CashRegister _cashRegister;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _clips;

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
                    _audioSource.PlayOneShot(_clips[Random.Range(0,_clips.Length)]);
                    // _audioSource.Play();

                yield return new WaitForSeconds(10f);
            }
        }
    }
}