using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MelonLoader_AI.MoonriseButtonAPI
{
    [RegisterTypeInIl2Cpp]
    public class MRMenuEventHandler : MonoBehaviour
    {
        public MRMenuEventHandler(IntPtr ptr) : base(ptr) { }

        public void OnDisable()
        {

        }
    }
}
