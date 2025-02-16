using UnityEngine;

public class Neutralizer : MonoBehaviour
{
    [SerializeField]
    private GameObject cylinder;

    [SerializeField]
    private Transform rayTransform;

    private Animator animator;
    private Animator gunAnimator;
    private int actualNumber = 1;

    public void SetActualNumber (int value)
    {
        actualNumber = value;
    } 
    public int GetActualNumber()
    {
        return actualNumber;
    }
    void Start()
    {
        animator = cylinder.GetComponent<Animator>();
        gunAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
    }
    public void Scrool(float a)
    {
        if (a > 0)
        {
            animator.SetTrigger("scroolUp");
        }
            
        else if (a < 0)
        {
            animator.SetTrigger("scroolDown");
        }
            
    }
    public void Trigger()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, 20))
        {
            var DoorComponent = hit.collider.gameObject.GetComponentInParent<Door>();
            if (DoorComponent!=null)
            {
                if (actualNumber == DoorComponent.GetDoorValue())
                {
                    DoorComponent.SetDoorValue(0);
                    gunAnimator.Play("Gun");
                }
            }

            var RoomSurfaceComponent = hit.collider.gameObject.GetComponentInParent<RoomSurface>();
            if (RoomSurfaceComponent != null) 
            {
                Debug.Log(RoomSurfaceComponent + " RoomSurfaceComponent");
                if (actualNumber == 0)
                {
                    RoomSurfaceComponent.SurfaceHit();
                    gunAnimator.Play("Gun");
                }
                else
                {
                    GameManager.ShowError();
                }
            }
        }
    }
}
