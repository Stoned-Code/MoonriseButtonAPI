using MelonLoader;
using MoonriseButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Controls;

namespace MoonriseButtonAPI
{
    public class MRTab : MRButtonBase
    {
        private static int startIndex = 0;
        protected Button button;
        public MRTab(string menuName, Sprite buttonImage, string tooltip, Action action)
        {
            this.buttonName = $"Page_{MoonriseButtonApi.modIdentifier}{menuName}";

            Initialize(buttonImage, tooltip, action);
        }

        private void Initialize(Sprite buttonImage, string tooltip, Action action)
        {
            this.buttonType = "Tab";
            this.buttonObject = UnityEngine.Object.Instantiate(LaunchPadApi.GetTabButtonRef(), LaunchPadApi.GetTabParent(), true);
            this.buttonObject.name = buttonName;
            this.button = buttonObject.GetComponent<Button>();
            this.buttonObject.GetComponentInChildren<MenuTab>().field_Public_String_0 = $"QM_{buttonName}";
            this.buttonObject.transform.SetSiblingIndex(2 + startIndex);
            startIndex++;
            SetButtonImage(buttonImage);
            SetTooltip(tooltip);
            MethodInfo info = buttonObject.GetComponent<MenuTab>().GetType().GetMethod("ShowTabContent");
            string vars = "";
            foreach (LocalVariableInfo variable in info.GetMethodBody().LocalVariables)
            {
                vars += variable.ToString() + "\n";
            }
            MelonLogger.Msg("Here's something: " + vars);
            SetAction(action);

            backgroundColor = buttonObject.transform.Find("Background").GetComponent<Image>().color;
            imageColor = buttonObject.transform.Find("Icon").GetComponent<Image>().color;


            MoonriseButtonApi.allTabs.Add(this);
        }

        public void SetAction(Action action)
        {
            button.onClick = new Button.ButtonClickedEvent();

            if (action != null)
                button.onClick.AddListener(action);
        }

        public void SetButtonImage(Sprite image)
        {
            buttonObject.transform.Find("Icon").GetComponent<Image>().overrideSprite = image;
        }
    }
}
