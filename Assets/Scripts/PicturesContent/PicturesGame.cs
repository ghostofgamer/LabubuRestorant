using InteractableContent;
using PlayerContent;
using UI.Screens;
using UnityEngine;

namespace PicturesContent
{
    public class PicturesGame : MonoBehaviour
    {
        [SerializeField] private InteractableObject _interactableObject;
        [SerializeField] private OurGamesScreen _ourGamesScreen;

        private void OnEnable()
        {
            _interactableObject.OnAction += Action;
        }

        private void OnDisable()
        {
            _interactableObject.OnAction -= Action;
        }

        private void Action(PlayerInteraction playerInteraction)
        {
            _ourGamesScreen.OpenScreen();
        }
    }
}