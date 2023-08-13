using _game.controllers;

namespace _game.States
{
    public class GameModeStateMachine : StateMachine
    {
        public PlayerController Player { get; }
        
        public  CubeState CubeState { get; }
        
        public  ShipState ShipState { get; }



        public GameModeStateMachine(PlayerController _player)
        {
            Player = _player;
            CubeState = new CubeState(this);
            ShipState = new ShipState(this);

        }
    }
}