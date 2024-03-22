using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    Animator animator;
    string CurrentState;

    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_Run = "Player_Run";
    const string PLAYER_JUMP = "Player_Jump";

    

    // Start is called before the first frame update
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeAnimationState(string newState)
    {
        if(newState == CurrentState)
        {
            return;
        }
        animator.Play(newState);

        newState = CurrentState;
    }

    bool isAnimationPlaying(Animator animator, string stateName3)
    {

    }
}
