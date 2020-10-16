using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotPointManager : SingletonBase<PlotPointManager> // NOTA: EN PROCESO
{
    PlotPointCollection plotPointsToManage;
    [SerializeField]
    int plotPointLimit;
}
