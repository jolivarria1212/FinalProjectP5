using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
public class Player : MonoBehaviour
{
    [SerializeField] private TerrianGenerator terrianGenerator;
    [SerializeField] private TextMeshProUGUI scoreText;

    private Animator animator;
    private bool isHopping;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        score++;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            float zDifference = 0;
            if (transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
    }
    
    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("Hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrianGenerator.SpawnTerrian(false, transform.position);
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}