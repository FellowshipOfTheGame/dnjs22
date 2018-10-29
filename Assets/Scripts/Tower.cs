using UnityEngine;
using System.Collections;

public class Tower
{
    #region Attributes

    private Troop troop;
    private Vector2 coordinates;

    #endregion


    #region Getters and Setters

    public Troop Troop
    {
        get
        {
            return troop;
        }

        set
        {
            troop = value;
        }
    }

    public Vector2 Coordinates
    {
        get
        {
            return coordinates;
        }

        set
        {
            coordinates = value;
        }
    }

    #endregion


    #region Methods

    public void EnterTroop(Troop troop)
    {
        if (this.troop.Team.Id == troop.Team.Id)
        {   // If we're adding units at a tower
            this.troop.Units += troop.Units;
        }
        else
        {                                               // If the tower is being attacked by another team
            int newUnitValue = this.Troop.Units - troop.Units;

            if (newUnitValue < 0)
            {   // If the attacking team is now the owner, then the tower has new units and team
                this.Troop.Units = -newUnitValue;
                this.Troop.Team = troop.Team;
            }
            else if (newUnitValue > 0)
            {   // If the owner doesn't change
                this.Troop.Units = newUnitValue;
            }
            else if (newUnitValue == 0)
            {   // If tower's "life" turns 0.
                this.Troop.Units = newUnitValue;
                this.Troop.Team = null;
            }
        }
    }

    #endregion
}

