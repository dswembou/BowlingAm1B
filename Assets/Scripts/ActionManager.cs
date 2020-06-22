using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager
{
        
    public enum Action { Tidy, Reset, Endturn, EndGame, Undefined };
    public Action Bowl(List<int> pins)
    {
        Action nextAction = Action.Undefined;

        for (int i = 0; i < pins.Count; i++)
        {
            if (i == 21)
            {
                nextAction = Action.EndGame;
            }
            else if (i == 20)
            {
                if(pins[i] == 10)
                {
                    nextAction = Action.Reset;
                }
                
            }
            else if (i % 2 == 0) //Eerste bal van een beurt 
            {
                if (pins[i] == 10)
                {
                    pins.Insert(i, 0); //Maak een virtuele 0 aan na een strike
                    nextAction = Action.Endturn;
                }
                else
                {
                    nextAction = Action.Tidy;
                }

            }
            else //Tweede bal van een beurt
            {
                nextAction = Action.Endturn;
            }
        }
        return nextAction;
    }
}


