using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainerPanel : MonoBehaviour
{
    public DoMaintenance doMaintenance;
    public bool doorLock = true;
    public void enterPassword(string password)
    {
        DoMaintenance dm = new DoMaintenance();
        bool status = dm.VerifyPassword(password);
        if (status == true)
        {
            dm.doorUnlock(doorLock);
            dm.terminateTransaction();
        }
    }

    public void exitMaintenance(bool doorLock)
    {
        //doorLock();
        if(doorLock == true)
        {
            //exit maintenance mode
        }
        else
        {
            //WaitForDoorClosed();
        }
    }


}
