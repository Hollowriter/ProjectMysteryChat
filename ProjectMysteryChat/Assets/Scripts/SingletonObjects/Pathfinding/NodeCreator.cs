using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCreator : SingletonBase<NodeCreator>
{
    public int Cols;
    public int Rows;
    Node[,] nodes;
    Node nodeOrigin = null;

    void InstantiateNodes() 
    {
        nodes = new Node[Cols, Rows];
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                GameObject go = new GameObject("Node");
                nodes[col, row] = go.AddComponent<Node>();
                go.transform.position = new Vector3(col * 2.0f, 0.0f, row * 2.0f);
            }
        }
    }

    void CheckAdjacency() 
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                if (col > 0)
                {
                    nodes[col - 1, row].AddAdjacent(nodes[col, row]);
                    nodes[col, row].AddAdjacent(nodes[col - 1, row]);
                }
                if (row > 0)
                {
                    nodes[col, row - 1].AddAdjacent(nodes[col, row]);
                    nodes[col, row].AddAdjacent(nodes[col, row - 1]);
                }
                if (col < Cols - 1)
                {
                    nodes[col + 1, row].AddAdjacent(nodes[col, row]);
                    nodes[col, row].AddAdjacent(nodes[col + 1, row]);
                }
                if (row < Rows - 1)
                {
                    nodes[col, row + 1].AddAdjacent(nodes[col, row]);
                    nodes[col, row].AddAdjacent(nodes[col, row + 1]);
                }
            }
        }
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        InstantiateNodes();
        CheckAdjacency();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void ResetAllNodes()
    {
        for (int row = 0; row < Rows; row++)
        {
            for (int col = 0; col < Cols; col++)
            {
                nodes[col, row].SetOpen(false);
                nodes[col, row].SetClosed(false);
                nodes[col, row].SetDestiny(false);
                nodes[col, row].SetAsPath(false);
                nodes[col, row].SetParent(null);
                nodes[col, row].SetChild(null);
            }
        }
    }

    public Node GetNodeByPosition(Vector3 pos)
    {
        nodeOrigin = nodes[0, 0];
        float dist = (pos - nodes[0, 0].transform.position).magnitude;
        for (int c = 0; c < Cols; c++)
        {
            for (int r = 0; r < Rows; r++)
            {
                Node n = nodes[c, r];
                float newDist = (pos - n.transform.position).magnitude;

                if (dist > newDist)
                {
                    nodeOrigin = n;
                    dist = newDist;
                }
            }
        }
        return nodeOrigin;
    }
}
