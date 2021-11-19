using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Controls;
using Object = UnityEngine.Object;

namespace MoonriseButtonAPI
{
    public class MRNestedTab : MRButtonBase
    {
        protected MRTab mainButton;
        protected Button backButton;
        protected string menuName;
        public MRNestedTab(string name, Sprite image, string tooltip)
        {
            this.buttonType = "Nested";
            Transform menu = Object.Instantiate<Transform>(LaunchPadApi.GetMenuRef().transform, LaunchPadApi.GetQuickMenuParent());
            this.menuName = $"{MoonriseButtonApi.modIdentifier}_{buttonName}_{name}";

            menu.name = menuName;

            this.mainButton = new MRTab(name, image, tooltip, () =>
            {
                LaunchPadApi.ShowPage(menuName);
            });
            this.buttonObject = mainButton.MainButtonObject();
        }

        public string GetButtonName() => menuName;
    }
}
