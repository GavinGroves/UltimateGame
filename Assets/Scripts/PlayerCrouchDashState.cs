using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchDashState : PlayerState
{
    public PlayerCrouchDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
        coll.offset = new Vector2(coll.offset.x, coll.offset.y - 0.6f);
        coll.size = new Vector2(coll.size.x, coll.size.y * 0.5f);
    }

    public override void Update()
    {
        base.Update();
        if(!Input.GetKey(KeyCode.S)) stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        coll.offset = player.offsetNormal;
        coll.size = player.sizeNormal;
        player.SetVelocity(0, rb.velocity.y);
    }
}
