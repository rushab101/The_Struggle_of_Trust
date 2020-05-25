using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.FSC
{
    public class FSTDemoManager : MonoBehaviour {

        [Header("STYLE OBJECTS")]
        public List<GameObject> objects = new List<GameObject>();

        [Header("STYLE PARENTS")]
        public List<GameObject> panels = new List<GameObject>();

        [Header("STYLE BUTTONS")]
        public List<GameObject> buttons = new List<GameObject>();

        [Header("SETTINGS")]
        public int currentPanelIndex = 0;
        private int currentButtonlIndex = 0;
        private int currentStylelIndex = 0;

        // [Header("PANEL ANIMS")]
        private string panelFadeIn = "Panel Open";
        private string panelFadeOut = "Panel Close";
        private string styleExpand = "Expand";

        // [Header("BUTTON ANIMS")]
        private string buttonFadeIn = "Button Open";
        private string buttonFadeOut = "Button Close";

        private GameObject currentPanel;
        private GameObject nextPanel;
        private GameObject styleObject;

        private GameObject currentButton;
        private GameObject nextButton;

        private Animator currentPanelAnimator;
        public Animator nextPanelAnimator;
        private Animator styleAnimator;

        private Animator currentButtonAnimator;
        private Animator nextButtonAnimator;

        void Start ()
        {
            currentButton = buttons[currentPanelIndex];
            currentButtonAnimator = currentButton.GetComponent<Animator>();
            currentButtonAnimator.Play(buttonFadeIn);

            currentPanel = panels[currentPanelIndex];
            currentPanelAnimator = currentPanel.GetComponent<Animator>();
            currentPanelAnimator.Play(panelFadeIn);

            styleObject = objects[currentStylelIndex];
            styleAnimator = currentPanel.GetComponent<Animator>();
            styleAnimator.Play(styleExpand);

            nextPanel = panels[currentPanelIndex];
            nextPanelAnimator = nextPanel.GetComponent<Animator>();
        }

        public void PanelAnim(int newPanel)
        {
            if (newPanel != currentPanelIndex)
            {
                currentPanel = panels[currentPanelIndex];

                currentPanelIndex = newPanel;
                nextPanel = panels[currentPanelIndex];

                currentPanelAnimator = currentPanel.GetComponent<Animator>();
                nextPanelAnimator = nextPanel.GetComponent<Animator>();

                currentPanelAnimator.Play(panelFadeOut);
                nextPanelAnimator.Play(panelFadeIn);

                currentButton = buttons[currentButtonlIndex];

                currentButtonlIndex = newPanel;
                nextButton = buttons[currentButtonlIndex];

                currentButtonAnimator = currentButton.GetComponent<Animator>();
                nextButtonAnimator = nextButton.GetComponent<Animator>();

                currentButtonAnimator.Play(buttonFadeOut);
                nextButtonAnimator.Play(buttonFadeIn);

                currentStylelIndex = newPanel;
                styleAnimator = currentPanel.GetComponent<Animator>();
                styleAnimator.Play(styleExpand);
            }    
        }

        public void Restart()
        {
            nextPanelAnimator.Play("");
            nextPanelAnimator.Play(panelFadeIn);
        }
    }
}