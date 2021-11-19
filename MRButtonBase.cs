using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MoonriseButtonAPI
{
    public class MRButtonBase
    {
        protected GameObject buttonObject;
        protected Color backgroundColor;
        protected Color textColor;
        protected Color imageColor;

        protected string buttonName;
        protected string buttonType;

        private bool initialized = false;
        public void Destroy()
        {
            UnityEngine.Object.Destroy(buttonObject);
        }

        public void SetActive(bool active)
        {
            buttonObject.gameObject.SetActive(active);
        }

        public void SetInteractable(bool interractable)
        {
            if (interractable)
            {
                SetOriginBackgroundColor(backgroundColor);
                SetOriginTextColor(textColor);
            }

            else
            {
                SetOriginBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1f));
                SetOriginTextColor(new Color(0.7f, 0.7f, 0.7f, 1f));
            }

            buttonObject.GetComponent<Button>().interactable = interractable;
        }

        public void SetOriginBackgroundColor(Color color) => backgroundColor = color;

        public void SetOriginTextColor(Color color) => textColor = color;
        
        public void SetButtonObject(GameObject obj)
        {
            if (initialized) return;

            buttonObject = obj;
        }
        
        public void SetTooltip(string tooltip)
        {
            buttonObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;
        }

        public void ToggleActive(bool isActive)
        {
            buttonObject.SetActive(isActive);
        }

        public GameObject MainButtonObject()
        {
            return buttonObject;
        }
    }
}
