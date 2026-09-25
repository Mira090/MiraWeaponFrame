using System;
using System.Collections.Generic;
using System.Text;

namespace MiraWeaponFrame.Config
{
    [Serializable]
    public class ModConfig
    {
        public int Version = 0;

        public bool HasFrame = true;
        public bool HasText = true;
    }
}
