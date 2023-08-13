using _game.Data;
using _game.Keys;
using _game.Signals;
using UnityEngine;

namespace _game.States
{
    public class CubeState: GameModeState
    {
        private bool isNextJump => Time.time > jumpRate;

        private float jumpRate = 0.1f;

     
        
        
        public CubeState(GameModeStateMachine gameModeStateMachine) : base(gameModeStateMachine)
        {
            
        }

        public override void Enter()
        {
            InputSignals.Instance.onGetTouchInput += OnTouchInput;
            rigidbody2d.gravityScale = 5.5F;

        }

        public override void Exit()
        {
            InputSignals.Instance.onGetTouchInput -= OnTouchInput;

        }

        public override void Update()
        {
            Rotate();
            SpeedControlX();
        }

        public override void PhysicsUpdate()
        {
            Move();
        }
        private void OnTouchInput(TouchInputParams ınputParams)
        {
            if (!isGround() || !ınputParams.isTouch) return;
            if (!isNextJump) return;
            jumpRate = Time.time + 0.05f;

            rigidbody2d.AddForce(playerData.jumpPower * Vector2.up,ForceMode2D.Impulse);
        }
        
        private void Rotate()
        {
            if(isHitWall()) IdleSignals.Instance.onPlayerDeath.Invoke();
            if (isGround())
            {
                player.visuals.localRotation =
                    Quaternion.Lerp( player.visuals.localRotation,
                        NearestRotationZ(player.visuals.localEulerAngles.z),Time.deltaTime*playerData.rotateSmoth);
                return;
            }

            player.visuals.Rotate(-Vector3.forward * playerData.rotateSpeed * Time.deltaTime);
        }
        
        
    }
}