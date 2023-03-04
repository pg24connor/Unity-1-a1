using UnityEngine;
using TMPro;

public class PlayerStuff : Score
{
    public float playerSpeed = 1;
    public KeyCode left, right;
    public Transform sword;
    public TextMeshProUGUI score;

    private Rigidbody playerRb;
    private Camera mainCam;

    // Assign main varibles, including the varibles in Score.cs
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        mainCam = GameObject.Find("MainCamera").GetComponent<Camera>();
        SetScoreUI(score);
    }

    // All of the controls the player has 
    void Update()
    {
        SwordControl();
        if (Input.GetKey(left)) playerRb.AddForce(Vector3.left * playerSpeed * Time.deltaTime);
        if (Input.GetKey(right)) playerRb.AddForce(Vector3.right * playerSpeed * Time.deltaTime);
    }

    /// <summary>
    /// make sure the sword stays infront of the player no mater the players rotation
    /// make sure the sword is always pointing to the mouse
    /// </summary>
    private void SwordControl()
    {
        sword.position = transform.position;
        if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            sword.LookAt(hit.point);
        }
    }
}