                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
public class ClimbInteractable : XRBaseInteractable
{
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        base.OnSelectEntering(interactor);
        if(interactor is XRDirectInteractor)
        {
            //Debug.Log("Work enter!");
            /*
            if (Climber.climbing1stHand != null)
                Climber.climbing1stHand = interactor.GetComponent<XRController>();
            if (Climber.climbing2ndHand != null)
                Climber.climbing2ndHand = interactor.GetComponent<XRController>();
            */
            Climber.climbingHand = interactor.GetComponent<XRController>();
        }
            
    }
    protected override void OnSelectExiting(XRBaseInteractor interactor)
    {
        base.OnSelectExiting(interactor);
        if(interactor is XRDirectInteractor)
        {
            /*
            if (Climber.climbing1stHand && Climber.climbing1stHand.name == interactor.name)
            {
                Debug.Log("1Work out!");
                Climber.climbing1stHand = null;
            }
            if (Climber.climbing2ndHand && Climber.climbing2ndHand.name == interactor.name)
            {
                Debug.Log("2Work out!");
                Climber.climbing2ndHand = null;
            }
            */
            
            if(Climber.climbingHand && Climber.climbingHand.name == interactor.name)   
            {
                //Debug.Log("Work out!");
                Climber.climbingHand = null;
            }
            
        }
    }
}
