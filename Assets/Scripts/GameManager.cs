using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isKeyCollected = false;
    public TextMeshProUGUI keyStatusText;
    public Transform KeyDoor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        keyStatusText.text = "Key: Not Collected";
    }

    public void CollectKey()
    {
        isKeyCollected = true;
        keyStatusText.text = "Key: Collected";
        Debug.Log("Key Collected!");
        OpenKeyDoor();
    }

    public void OpenKeyDoor()
    {
        Destroy(KeyDoor.gameObject);
    }
}
