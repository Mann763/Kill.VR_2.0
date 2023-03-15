using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HurricaneVR.Framework.Core.Player
{
    public class fadeing : MonoBehaviour
    {
        public HVRScreenFade ScreenFade;

        // Start is called before the first frame update
        void Start()
        {
            ScreenFade.Fade(0, 1);
        }

        public void FadeOut()
        {
            ScreenFade.Fade(0, 1);
        }
        public void FadeIn()
        {
            ScreenFade.Fade(1, 1);
        }
    }
}

