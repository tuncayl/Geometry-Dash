using _game.Interfaces;

namespace _game.States
{
    public abstract class StateMachine
    {
        protected IState currentState;


        public void ChangeState(IState newState)
        {
            currentState?.Exit();

            currentState = newState;

            currentState.Enter();
        }


        public IState GetCurrentState() => currentState;

        public void Update()
        {
            currentState?.Update();
        }

        public void PhysicsUpdate()
        {
            currentState?.PhysicsUpdate();
        }
    }
}