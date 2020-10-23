using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotPointManager : SingletonBase<PlotPointManager>
{
    PlotPointCollection PlotPoint;
    [SerializeField]
    int plotPointLimit;
    int plotPointQuantity;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        PlotPoint = new PlotPointCollection();
        PlotPoint.PlotPoint = new PlotPoint[plotPointLimit];
        for (int i = 0; i < PlotPoint.PlotPoint.Length; i++)
        {
            PlotPoint.PlotPoint[i] = new PlotPoint();
            PlotPoint.PlotPoint[i].PlotPointName = "null";
        }
        plotPointQuantity = 0;
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void AddPlotPoint(string plotPointName)
    {
        if (plotPointQuantity < plotPointLimit)
        {
            PlotPoint.PlotPoint[plotPointQuantity].PlotPointName = plotPointName;
            plotPointQuantity++;
        }
    }

    public void CheckPlotPointCollection(PlotPointCollection newCollection)
    {
        if (newCollection != null)
        {
            if (newCollection.PlotPoint != null)
            {
                for (int i = 0; i < newCollection.PlotPoint.Length; i++)
                {
                    if (newCollection.PlotPoint[i].PlotPointName != "null")
                    {
                        AddPlotPoint(newCollection.PlotPoint[i].PlotPointName);
                    }
                }
            }
        }
    }

    public bool PlotPointTaken(string plotPointName) 
    {
        for (int i = 0; i < PlotPoint.PlotPoint.Length; i++)
        {
            if (PlotPoint.PlotPoint[i].PlotPointName == plotPointName)
            {
                return true;
            }
        }
        return false;
    }

    public PlotPointCollection GetPlotPointCollection()
    {
        return PlotPoint;
    }
}
