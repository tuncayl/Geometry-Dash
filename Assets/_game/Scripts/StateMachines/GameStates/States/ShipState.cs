using _game.Keys;
using _game.Signals;
using Unity.Mathematics;
using UnityEngine;

namespace _game.States
{
    public class ShipState: GameModeState
    {
        Quaternion targetRotation=quaternion.identity;
        
        public ShipState(GameModeStateMachine gameModeStateMachine) : base(gameModeStateMachine)
        {
            
        }

        public override void Enter()
        {
            InputSignals.Instance.onGetTouchInput += OnTouchInput;
            statemachine.Player.visuals.localPosition += Vector3.up * 0.5f;
            rigidbody2d.gravityScale = 1F;

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
            if(arg0.isTouch is false) return;
            Debug.Log("touching");
            rigidbody2d.AddForce(Vector2.up*playerData.flySpeed*Time.fixedDeltaTime,ForceMode2D.Impulse);
        }

        private void Rotate()
        {
            if(isHitWall()) IdleSignals.Instance.onPlayerDeath.Invoke();

            if (rigidbody2d.velocity.y > 0)targetRotation=Quaternion.Euler(new Vector3(0,0,30));
            else targetRotation=Quaternion.Euler(new Vector3(0,0,-30));
            if(isGround())targetRotation=Quaternion.identity;
            player.visuals.localRotation=Quaternion.Slerp(player.visuals.localRotation,targetRotation,Time.deltaTime*playerData.flyRotateSpeed);
        }

        

       
       
    }
}