using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MoonriseButtonAPI
{
    public class LPButtonBase
    {
        private GameObject buttonObject;
        private Color backgroundColor;
        private Color textColor;

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
                SetBackgroundColor(backgroundColor);
                SetTextColor(textColor);
            }

            else
            {
                SetBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1f));
                SetTextColor(new Color(0.7f, 0.7f, 0.7f, 1f));
            }

            buttonObject.GetComponent<Button>().interactable = interractable;
        }

        public virtual void SetBackgroundColor(Color color) { }
        public virtual void SetTextColor(Color color) { }
    }
}
