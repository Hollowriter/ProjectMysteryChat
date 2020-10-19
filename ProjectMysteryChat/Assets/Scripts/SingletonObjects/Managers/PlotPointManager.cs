using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotPointManager : SingletonBase<PlotPointManager>
{
    PlotPointCollection PlotPoints;
    [SerializeField]
    int plotPointLimit;
    int plotPointQuantity;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        PlotPoints = new PlotPointCollection();
        PlotPoints.PlotPoints = new PlotPoint[plotPointLimit];
        for (int i = 0; i < PlotPoints.PlotPoints.Length; i++)
        {
            PlotPoints.PlotPoints[i] = new PlotPoint();
            PlotPoints.PlotPoints[i].PlotPointName = "null";
        }
        plotPointQuantity = 0;
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetPlotPointCollection(PlotPointCollection newCollection)
    {
        PlotPoints = newCollection;
        plotPointQuantity = 0;
        for (int i = 0; i < PlotPoints.PlotPoints.Length; i++)
        {
            if (PlotPoints.PlotPoints[i].PlotPointName != "null")
            {
                plotPointQuantity++;
            }
        }
    }

    public void AddPlotPoint(string plotPointName) 
    {
        if (plotPointQuantity < plotPointLimit)
        {
            PlotPoints.PlotPoints[plotPointQuantity].PlotPointName = plotPointName;
            plotPointQuantity++;
        }
    }

    public bool PlotPointTaken(string plotPointName) 
    {
        for (int i = 0; i < PlotPoints.PlotPoints.Length; i++)
        {
            if (PlotPoints.PlotPoints[i].PlotPointName == plotPointName)
            {
                return true;
            }
        }
        return false;
    }

    public PlotPointCollection GetPlotPointCollection()
    {
        return PlotPoints;
    }
}
