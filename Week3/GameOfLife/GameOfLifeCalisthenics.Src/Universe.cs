using System.Collections.Generic;

namespace GameOfLifeCalisthenics.Src
{
    public class Universe
    {
        private IList<Cell> cells = new List<Cell>(); 

        public void Add(Cell cell)
        {
            cells.Add(cell);
        }

        protected bool Equals(Universe other)
        {
            return Equals(cells.Count, other.cells.Count);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Universe) obj);
        }

        public override int GetHashCode()
        {
            return (cells != null ? cells.GetHashCode() : 0);
        }
    }
}