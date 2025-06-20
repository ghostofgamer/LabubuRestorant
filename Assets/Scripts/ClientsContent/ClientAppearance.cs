using UnityEngine;

namespace ClientsContent
{
    public class ClientAppearance : MonoBehaviour
    {
        [SerializeField] private GameObject[] _accessories;
        [SerializeField] private GameObject[] _bodies;
        [SerializeField] private GameObject[] _eyes;
        [SerializeField] private GameObject[] _tails;
        [SerializeField] private GameObject[] _mounth;
    
        public void ChoiceAccessories()
        {
            foreach (var accessory in _accessories)
                accessory.SetActive(false);

            _accessories[Random.Range(0, _accessories.Length)].SetActive(true);
        }

        public void ChoiceAppearance()
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
