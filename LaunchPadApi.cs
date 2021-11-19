using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MoonriseButtonAPI
{
    public static class LaunchPadApi
    {
        // Menu References
        public const string MenuReference = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Camera"; // References the Launch Pad Menu
        public const string MenuParent = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent"; // References the parent of the menus.

        // Container References
        public const string HeaderReference = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks"; // References the header of a menu category.
        public const string HeaderContainerReference = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks"; // References the container of a category.

        // Button References
        public const string SingleButtonReference = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/Button_Worlds"; // References a button.
        public const string ToggleButtonReference = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/Button_Mute"; // References a toggle.
        public const string TabReference = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings"; // References a tab.
        public const string TabParent = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup"; // References the parent of the tab.

        public static GameObject singleButton { get; private set; }
        public static GameObject toggleButton { get; private set; }
        public static GameObject tabButton { get; private set; }
        public static GameObject menuContainer { get; private set; }

        public static GameObject GetSingleButtonRef()
        {
            if (singleButton == null)
                singleButton = GameObject.Find(SingleButtonReference);

            MelonLogger.Msg("Button Name " + singleButton.name);
            return singleButton;
        }

        public static GameObject GetToggleButtonRef()
        {
            if (toggleButton == null)
                toggleButton = GameObject.Find(ToggleButtonReference);

            return singleButton;
        }

        public static GameObject GetTabButtonRef()
        {
            if (tabButton == null)
                tabButton = GameObject.Find(TabReference);

            return tabButton;
        }

        public static GameObject GetMenuRef()
        {
            if (menuContainer == null)
                menuContainer = GameObject.Find(MenuReference);

            return menuContainer;
        }

        public static VRC.UI.Elements.QuickMenu GetQuickMenu()
        {
            try
            {
                return GameObject.FindObjectOfType<VRC.UI.Elements.QuickMenu>();
            }

            catch
            {
                return null;
            }
        }

        public static Transform GetQuickMenuParent()
        {
            return GameObject.Find(MenuParent).transform;
        }

        public static Transform GetTabParent()
        {
            return GameObject.Find(TabParent).transform;
        }

        public static void ShowPage(string menuName)
        {
            Transform menusContainer = GetQuickMenuParent();
            Transform menuTransform = menusContainer?.transform.Find(menuName);

            if (menuTransform == null)
                MelonLogger.Msg("[LaunchPadApi] menuTransform is null.");

            VRC.UI.Elements.UIPage[] pages = menusContainer.GetComponentsInChildren<VRC.UI.Elements.UIPage>();
            foreach (VRC.UI.Elements.UIPage page in pages)
            {
                if (page.gameObject == menuTransform)
                    continue;

                page.gameObject.SetActive(false);
            }
            
            menuTransform.gameObject.SetActive(true);
        }

    }
}
