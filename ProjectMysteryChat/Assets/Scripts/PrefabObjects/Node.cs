using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    List<Node> obj = new List<Node>();
    float cost = 1;
    float heuristic = 0;
    float startPointCost = 0;
    float goalPointCost = 0;
    float totalCost = 0;
    bool isOpen = false;
    bool isClosed = false;
    bool isDestiny = false;
    bool isPath = false;
    bool isBlocked = false;
    Node theParent = null;
    Node theChild = null;
    Ray leftRay;
    Ray rightRay;
    Ray frontRay;
    Ray backRay;
    RaycastHit hit;

    void Start()
    {
        leftRay = new Ray(this.gameObject.transform.position, Vector3.left);
        rightRay = new Ray(this.gameObject.transform.position, Vector3.right);
        frontRay = new Ray(this.gameObject.transform.position, Vector3.forward);
        backRay = new Ray(this.gameObject.transform.position, Vector3.back);
    }

    void Update()
    {
        if (Physics.Raycast(leftRay, out hit, 0.15f) ||
            Physics.Raycast(rightRay, out hit, 0.15f) ||
            Physics.Raycast(frontRay, out hit, 0.15f) ||
            Physics.Raycast(backRay, out hit, 0.15f))
        {
            if (hit.collider.tag == "block") // Nota: Revisar esta linea de codigo con respecto a objetos bloqueantes
            {
                isBlocked = true;
            }
        }
        else
        {
            isBlocked = false;
        }
    }

    public void AddAdjacent(Node n)
    {
        if (!obj.Contains(n))
            obj.Add(n);
    }

    public void Reset()
    {
        obj.Clear();
        cost = 1;
        heuristic = 0;
        startPointCost = 0;
        goalPointCost = 0;
        totalCost = 0;
        isOpen = false;
        isClosed = false;
        isDestiny = false;
        isPath = false;
        theParent = null;
        theChild = null;
    }

    public List<Node> Adjacents()
    {
        return obj;
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
    }

    public void SetClosed(bool closed)
    {
        isClosed = closed;
    }

    public void SetDestiny(bool destiny)
    {
        isDestiny = destiny;
    }

    public void SetIsBlocked(bool blocking)
    {
        isBlocked = blocking;
    }

    public void SetParent(Node parent)
    {
        theParent = parent;
        if (theParent != null)
        {
            SetTotalCost(theParent);
            SetStartTotalCost(theParent);
            theParent.SetChild(this);
        }
    }

    public void SetChild(Node child)
    {
        theChild = child;
        SetGoalTotalCost(child);
    }

    public void SetAsPath(bool sure)
    {
        isPath = sure;
    }

    public void SetTotalCost(Node parent)
    {
        if (parent == null)
        {
            totalCost = cost;
        }
        else
        {
            totalCost = cost + parent.totalCost;
        }
    }

    public void SetHeuristicalTotalCost()
    {
        heuristic = goalPointCost + startPointCost;
    }

    public void SetGoalTotalCost(Node child)
    {
        if (child)
        {
            goalPointCost = 1 + child.GetGoalTotalCost();
        }
    }

    public void SetStartTotalCost(Node parent)
    {
        if (parent)
        {
            startPointCost = 1 + GetParent().GetStartTotalCost();
        }
    }

    public float GetHeuristicalTotalCost()
    {
        SetHeuristicalTotalCost();
        return heuristic;
    }

    public float GetGoalTotalCost()
    {
        return goalPointCost;
    }

    public float GetStartTotalCost()
    {
        return startPointCost;
    }

    public bool GetOpen()
    {
        return isOpen;
    }

    public bool GetClosed()
    {
        return isClosed;
    }

    public bool GetDestiny()
    {
        return isDestiny;
    }

    public bool GetIsBlocked()
    {
        return isBlocked;
    }

    public bool GetAsPath()
    {
        return isPath;
    }

    public float GetTotalCost()
    {
        return totalCost;
    }

    public Node GetParent()
    {
        return theParent;
    }

    public Node GetChild()
    {
        return theChild;
    }

    private void OnDrawGizmos()
    {
        if (isPath == true)
        {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawCube(this.transform.position, Vector3.one);
    }
}
