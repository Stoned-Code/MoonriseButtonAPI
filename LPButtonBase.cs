using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonriseV2Mod.API.MoonriseButtonAPI
{
    public class ButtonBase
    {
        private GameObject buttonObject;
        private Color backgroundColor;
        private Color textColor;

        public void Destroy()
        {
            UnityEngine.Object.Destroy(buttonObject);
        }

        public virtual void SetBackgroundColor()
    }
}
