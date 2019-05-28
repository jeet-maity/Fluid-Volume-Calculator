using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class TrapezoidalPrism : I3DShape
    {
        public TrapezoidalPrism(decimal commonDistance, decimal[] topVertices, decimal[] bottomVertices)
        {
            this.commonDistance = commonDistance;
            this.topVertices = topVertices;
            this.bottomVertices = bottomVertices;
        }

        private decimal commonDistance;
        public decimal CommonDistance
        {
            get { return commonDistance; }
            protected set
            {
                if (this.commonDistance <= 0m)
                    throw new ArgumentOutOfRangeException(nameof(this.commonDistance), "Common distance cannot be zero or negative");
                commonDistance = value;
            }
        }

        private decimal[] topVertices;
        public decimal[] TopVertices
        {
            get { return topVertices; }
            protected set
            {
                this.ValidateVertices(this.topVertices, nameof(this.topVertices));
                topVertices = value;
            }
        }

        private decimal[] bottomVertices;
        public decimal[] BottomVertices
        {
            get { return bottomVertices; }
            protected set
            {
                this.ValidateVertices(this.bottomVertices, nameof(this.bottomVertices));
                bottomVertices = value;
            }
        }

        private void ValidateVertices(decimal[] vertices, string verticesName)
        {
            if (null == vertices)
                throw new ArgumentNullException(verticesName);
            if (vertices.Length != 4)
                throw new ArgumentOutOfRangeException(verticesName, "Expected exactly 4 vertices");
            for (int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i] <= 0m)
                    throw new ArgumentOutOfRangeException(verticesName, $"vertex {i} cannot be zero or negative");
            }
        }

        public override IUnitOfVolume Volume()
        {
            // Calculate A-first, A-mid, A-last
            // Simpson's rule only applies to an ODD number of function values.
            // in problem statement, we have an EVEN number..
            // might need to revert to trapezoidal rule
        }
    }
}
