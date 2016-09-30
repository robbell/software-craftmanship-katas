using System.Collections.Generic;

namespace GameOfLifeCalisthenics.Src
{
    public class Neighbours
    {
        private IList<Cell> cells = new List<Cell>(); 

        public void Add(Cell cell)
        {
            cells.Add(cell);
        }

        public PopulationStatus GetPopulationStatus()
        {
            if(cells.Count >= 4) return PopulationStatus.Overpopulation;

            if (cells.Count >= 2) return PopulationStatus.HealthyPopulation;

            return PopulationStatus.Underpopulated;
        }
    }

    public enum PopulationStatus
    {
        Underpopulated,
        HealthyPopulation,
        Overpopulation
    }
}