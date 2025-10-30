using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private PlayerState currentState;

    private void Start()
    {
        ChangeState(new MoveState());
    }

    private void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(PlayerState newState)
    {
        currentState = newState;
        currentState.Enter(this);
    }
    
    public void OnHit()
    {
        ChangeState(new HitState());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnHit();
        }
    }
}

public abstract class PlayerState
{
    public abstract void Enter(PlayerMovement player);
    public abstract void Update(PlayerMovement player);
}

public class MoveState : PlayerState
{
    public override void Enter(PlayerMovement player)
    {
        Debug.Log("Entered Move State");
    }

    public override void Update(PlayerMovement player)
    {
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move, 0, 0);
        player.transform.Translate(movement * (5f * Time.deltaTime));
        
    }
}

public class HitState : PlayerState
{
    public override void Enter(PlayerMovement player)
    {
        Debug.Log("Entered Hit State");
        player.StartCoroutine(ReturnToMoveAfterDelay(player));
    }

    public override void Update(PlayerMovement player)
    {
        
    }

    private IEnumerator ReturnToMoveAfterDelay(PlayerMovement player)
    {
        yield return new WaitForSeconds(1f);
        player.ChangeState(new MoveState());
    }
}