using System;
using InteractableContent;
using PlayerContent;
using UnityEngine;

namespace PicturesContent
{
    public class PicturesGame : MonoBehaviour
    {
        [SerializeField] private InteractableObject _interactableObject;
        [SerializeField] private string _link;

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
            Application.OpenURL(_link);
        }
    }
}