using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Models
{

    #region - Weapons -
    [Serializable]
    public class WeaponSettingsModel
    {
        [Header("Sway")]
        public float SwayAmount;
        public float SwaySmoothing;
    }
    #endregion
}
