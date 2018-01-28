using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aty
{
    [System.Serializable]
    public abstract class Heatable : MonoBehaviour
    {
        public abstract void OnHeatChange(float percent);
    }
}