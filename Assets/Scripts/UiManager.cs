using System.Collections;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerHealth;
    [SerializeField]
    private TextMeshProUGUI endGame_errorText;

    private void Start()
    {
        SetHealth();
    }
    public void SetHealth()
    {
        playerHealth.text = GameManager.playerHealth.ToString() + "/3";
    }
    public void EndGameText()
    {
        endGame_errorText.text = "All Rooms Scanned!";
        endGame_errorText.gameObject.SetActive(true);
    }
    public void ShowError()
    {
        endGame_errorText.text = "Error! - Check Neutralizer Ring";
        endGame_errorText.gameObject.SetActive(true);
        StartCoroutine(Wait3sec());
    }

    private IEnumerator Wait3sec()
    {
        yield return new WaitForSeconds(3);
        endGame_errorText.gameObject.SetActive(false);
    }
}
