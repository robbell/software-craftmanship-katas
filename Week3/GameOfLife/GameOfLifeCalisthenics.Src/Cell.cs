namespace GameOfLifeCalisthenics.Src
{
    public class Cell
    {
        private State state;

        public Cell(State state)
        {
            this.state = state;
        }

        public State GetState()
        {
            return state;
        }

        public void Tick(Neighbours neighbours)
        {
            if (neighbours.GetPopulationStatus() == PopulationStatus.Overpopulation) state = State.Dead;

            if (neighbours.GetPopulationStatus() == PopulationStatus.Underpopulated) state = State.Dead;

            if(neighbours.GetPopulationStatus() == PopulationStatus.HealthyPopulation) state = State.Alive;
        }
    }

    public enum State
    {
        Dead,
        Alive
    }
}