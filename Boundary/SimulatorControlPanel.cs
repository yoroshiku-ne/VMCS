using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatorControlPanel : MonoBehaviour
{
    public bool BeginSimulation(bool beginSimulationButtonPressed)
    {
        return true;
    }

    public void enableRadio()
    {
        if(BeginSimulation(true))
        {
            //enable other buttons
        }
    }

    public void activateCustomerPanel()
    {

    }

    public void activateMaintainerPanel()
    {

    }

    public void activateMachineryPanel()
    {

    }

    public void EndSimulation()
    {
        
    }
}
