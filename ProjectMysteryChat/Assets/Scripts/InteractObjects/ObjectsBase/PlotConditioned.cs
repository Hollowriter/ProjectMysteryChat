using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotConditioned : MonoBehaviour
{
    [SerializeField]
    List<string> plotPointNames;
    [SerializeField]
    bool toActivate;
    int plotPointActivated;

    void Begin() 
    {
        plotPointActivated = 0;
    }

    private void Awake()
    {
        Begin();
    }

    public void CheckPlotPoints() 
    {
        plotPointActivated = 0;
        for (int i = 0; i < plotPointNames.Count; i++) 
        {
            for (int r = 0; r < PlotPointManager.instance.GetPlotPointCollection().PlotPoint.Length; r++) 
            {
                if (plotPointNames[i] == PlotPointManager.instance.GetPlotPointCollection().PlotPoint[r].PlotPointName) 
                {
                    plotPointActivated++;
                    break;
                }
            }
        }
    }

    public bool ConfirmActivation() 
    {
        if (plotPointActivated == plotPointNames.Count) 
        {
            return toActivate;
        }
        return !toActivate;
    }

    public bool CheckCondition() 
    {
        CheckPlotPoints();
        return ConfirmActivation();
    }
}
