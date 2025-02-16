using System.Collections;
using TMPro;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private Transform rayTransform;
    [SerializeField] 
    private LayerMask layerMask;
    [SerializeField]
    private TextMeshProUGUI scannerNumberLabel;
    public void Scan()
    {
        StopAllCoroutines();

        RaycastHit hit;      
        if (Physics.Raycast(rayTransform.position, rayTransform.TransformDirection(Vector3.forward),
            out hit, 20, layerMask))
        {
            scannerNumberLabel.text = hit.collider.gameObject.GetComponentInParent<Door>().GetDoorValue().ToString();
            hit.collider.gameObject.GetComponentInParent<Door>().CheckDoor();
            StartCoroutine(Wait1sec());
        }
        else
        {
            scannerNumberLabel.text = "-";
            StopAllCoroutines();
        }
    }
    private IEnumerator Wait1sec()
    {
        yield return new WaitForSeconds(1);
        scannerNumberLabel.text = "-";
    }
}
