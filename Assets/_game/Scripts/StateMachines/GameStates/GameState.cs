using _game.controllers;
using _game.Data;
using _game.Interfaces;
using _game.Signals;
using UnityEngine;

namespace _game.States
{
    public class GameModeState : IState
    {
        protected GameModeStateMachine statemachine;

        protected Rigidbody2D rigidbody2d => statemachine.Player.rigidbody2d;
        protected Vector3 position => statemachine.Player.transform.position;

        protected PlayerData playerData => statemachine.Player.playerData;

        protected PlayerController player => statemachine.Player;


        public GameModeState(GameModeStateMachine gameModeStateMachine)
        {
            statemachine = gameModeStateMachine;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        protected void Move()
        {
            rigidbody2d.velocity += (Vector2.right * Time.fixedDeltaTime * playerData.moveSpeed);
        }
        protected void SpeedControlY()
        {
            float velY = rigidbody2d.velocity.y;
            
            if (velY> playerData.flySpeed)     rigidbody2d.velocity =new Vector2(rigidbody2d.velocity.x, playerData.flySpeed*1.5F);

        }

        protected void SpeedControlX()
        {
            float velX= rigidbody2d.velocity.x;
            if (velX > playerData.moveSpeed) rigidbody2d.velocity = new Vector2(playerData.moveSpeed, rigidbody2d.velocity.y);

        }
        protected bool isGround()
        {
            return Physics2D.OverlapBox(position + (Vector3)new Vector2(-0.0049f, -0.48f),
                new Vector2(0.93f, 0.04f), 0, playerData.groundLayer, -1, 3);
        }

        protected bool isHitWall()
        {
            return Physics2D.OverlapBox(position + (Vector3)new Vector2(0.475f, -0.005f),
                       new Vector2(0.039f, 0.90f), 0, playerData.obstacleLayer, -1, 3)
                   ||
                   Physics2D.OverlapBox(position + (Vector3)new Vector2(-0.00249f, 0.474f),
                       new Vector2(0.93f, 0.039f), 0, playerData.obstacleLayer, -1, 3);
        }

        protected Quaternion NearestRotationZ(float rot) =>
            Quaternion.Euler(new Vector3(0, 0, Mathf.Round(rot / 90) * 90));
    }
}