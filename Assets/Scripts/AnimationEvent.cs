using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public Neutralizer actualCircleNumber;

    public void IncreaseNumber()
    {
        if(actualCircleNumber.GetActualNumber() >= 9)
            actualCircleNumber.SetActualNumber(0);
        else
            actualCircleNumber.SetActualNumber(actualCircleNumber.GetActualNumber() +1);

        Debug.Log(actualCircleNumber.GetActualNumber());
    }
    public void DecreaseNumber()
    {
        if(actualCircleNumber.GetActualNumber() <= 0)
            actualCircleNumber.SetActualNumber(9);
        else
            actualCircleNumber.SetActualNumber(actualCircleNumber.GetActualNumber() - 1);

        Debug.Log(actualCircleNumber.GetActualNumber());
    }
}
