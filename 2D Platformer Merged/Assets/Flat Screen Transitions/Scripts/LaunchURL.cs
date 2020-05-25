using UnityEngine;

namespace Michsky.UI.FSC
{
    public class LaunchURL : MonoBehaviour
    {
        public string URL;

        public void urlLinkOrWeb()
        {
            Application.OpenURL(URL);
        }
    }
}