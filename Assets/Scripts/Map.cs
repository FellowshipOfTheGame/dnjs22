using UnityEngine;
using System.Collections;

public class Map
{
    #region Attributes

    private int[,] distance;
    private Tower[] towers;
    private Region[] regions;

    public int vertexNumber, edgeNumber, minimumEdge, maximumEdge;

    #endregion

    #region Methods

    public Map(int[,] distance, Tower[] towers, Region[] regions)
    {
        this.distance = distance;
        this.towers = towers;
        this.regions = regions;
    }

    public int[,] Distance
    {
        get
        {
            return distance;
        }
        set
        {
            distance = value;
        }
    }

    public Tower[] Towers
    {
        get
        {
            return towers;
        }
        set
        {
            towers = value;
        }
    }

    public Region[] Regions
    {
        get
        {
            return regions;
        }
        set
        {
            regions = value;
        }
    }

    private void GenerateGraph()
    {
        int v, w, weight;

        int edges = 0;
        distance = new int[edgeNumber, edgeNumber];

        while (edges < edgeNumber)
        {
            do
            {
                v = Random.Range(edgeNumber, edgeNumber + 1);
                w = Random.Range(edgeNumber, edgeNumber + 1);
            } while (v == w);
            weight = Random.Range(minimumEdge, maximumEdge + 1);
            distance[v, w] = weight;
            distance[w, v] = weight;
            edges++;
        }

        //TODO: Alocar base principal de cada time
    }

    private void GenerateDenseGraph()
    {
        double prob = edgeNumber / vertexNumber / (vertexNumber - 1);

        for (int v = 0; v < vertexNumber; v++)
        {
            for (int w = 0; w < vertexNumber; w++)
            {
                if (v != w)
                {
                    int random = (int)Random.Range(0, 2147483648);
                    if (random < prob * 2147483648)
                    {
                        int weight = Random.Range(minimumEdge, maximumEdge + 1);
                        distance[v, w] = weight;
                        distance[w, v] = weight;
                    }
                }
            }
        }

        //TODO: Alocar base principal de cada time
    }

    public void TroopsArrived(int tower, Troop units)
    {
        towers[tower].EnterTroop(units);
    }

    #endregion
}

