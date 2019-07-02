using System;

namespace GameDatabase.Types
{
    [Serializable]
    public struct Vector
    {
        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float x;
        public float y;

        public override string ToString()
        {
            return "[" + x + "," + y + "]";
        }

        public static readonly Vector Zero = new Vector { x = 0, y = 0 };
    }
}
