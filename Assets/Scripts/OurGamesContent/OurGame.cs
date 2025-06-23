using UI.Buttons;
using UnityEngine;

namespace OurGamesContent
{
    public class OurGame : AbstractButton
    {
        [SerializeField] private string _link;
        
        public override void OnClick()
        {
            Application.OpenURL(_link);
        }
    }
}
