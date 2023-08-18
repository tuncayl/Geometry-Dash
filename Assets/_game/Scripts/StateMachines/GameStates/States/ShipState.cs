using _game.Keys;
using _game.Signals;
using Unity.Mathematics;
using UnityEngine;

namespace _game.States
{
    public class ShipState: GameModeState
    {
        Quaternion targetRotation=quaternion.identity;

        private Vector2 direction = Vector2.zero;
        
        public ShipState(GameModeStateMachine gameModeStateMachine) : base(gameModeStateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            moveSpeed *= 1.5f;
            InputSignals.Instance.onGetTouchInput += OnTouchInput;
            statemachine.Player.visuals.localRotation = Quaternion.identity;
            statemachine.Player.visuals.localPosition += Vector3.up * 0.5f;
            statemachine.Player.ship.SetActive(true);

        }

      

        public override void Exit()
        {
            InputSignals.Instance.onGetTouchInput -= OnTouchInput;
            statemachine.Player.visuals.localPosition -= Vector3.up * 0.5f;
            statemachine.Player.ship.SetActive(false);

            
        }

      
        public override void Update()
        {
            Rotate();
            SpeedControlX();
            SpeedControlY();
        }

        public override void PhysicsUpdate()
        {
            Move();
        }
        
        private void OnTouchInput(TouchInputParams arg0)
        {
            if (arg0.isTouch is false) player.rigidbody2d.gravityScale = playerData.flySpeed;
            else player.rigidbody2d.gravityScale = playerData.flySpeed*-1;
        }
         
        private void Rotate()
        {
            if(isHitWall()) IdleSignals.Instance.onPlayerDeath.Invoke();
            targetRotation=Quaternion.Euler(0, 0, player.rigidbody2d.velocity.y * 2);
            if(isGround())targetRotation=Quaternion.identity;
            player.visuals.localRotation=Quaternion.Slerp(player.visuals.localRotation,targetRotation,Time.deltaTime*playerData.flyRotateSpeed);
        }

        

       
       
    }
}