using UnityEngine;
using System.Collections;

public class Team
{
    #region Attributes

    private string name;
    private Vector4 color4;//int r, g, b, a;
    private int id;
    private Vector2 mainBase;

    #endregion

    public Team(string name, Vector4 v)
    {
        this.name = name;
        this.color4 = v;
    }

    #region Getters and Setters

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public Vector4 Color4
    {
        get
        {
            return color4;
        }

        set
        {
            color4 = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public Vector2 MainBase
    {
        get
        {
            return mainBase;
        }

        set
        {
            mainBase = value;
        }
    }

    #endregion

    #region Methods


    #endregion
}

