using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject fireparticle;

    private Animator animator;

    public int doorValue;
    private bool isChecked = false;
    private bool neutralized = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        doorValue = Random.Range(1, 10);
    }
    public int GetDoorValue()
    {
        return doorValue;
    }
    public void CheckDoor()
    {
        if(neutralized)
            isChecked = true;
    }
    public void SetDoorValue(int value)
    {
        doorValue = value;
        neutralized = true;
    }
    public void OpenDoor()
    {
        if (isChecked && neutralized)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            fireparticle.SetActive(true);
            GameManager.PlayerDamaged();
            StartCoroutine(Wait3sec());
        }
    }

    private IEnumerator Wait3sec()
    {
        yield return new WaitForSeconds(3);
        fireparticle.SetActive(false);
    }
}
