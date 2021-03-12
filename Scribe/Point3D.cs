using System;
using System.Globalization;

namespace Scribe
{
    /// <summary>
    /// A simple representation of three coordinate integers, tailored for Scribe's needs.
    /// Instances have value semantics.
    /// </summary>
    public readonly struct Point3D : IEquatable<Point3D>
    {
        #region Class Defaults
        /// <summary>The zero point.</summary>
        public static readonly Point3D Zero = new(0, 0, 0);

        /// <summary>Separates primitives within serialized <see cref="Point3D"/>s.</summary>
        private const string CoordinateDelimiter = "－";
        #endregion

        #region Characteristics
        /// <summary>Location along the y axis.</summary>
        public int Row { get; }

        /// <summary>Location along the x axis.</summary>
        public int Column { get; }

        /// <summary>Location along the z axis.</summary>
        public int Layer { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> struct.
        /// </summary>
        /// <param name="inRow">The Y coordinate.</param>
        /// <param name="inColumn">The X coordinate.</param>
        /// <param name="inLayer">The Z coordinate.</param>
        public Point3D(int inRow, int inColumn, int inLayer)
        {
            Row = inRow;
            Column = inColumn;
            Layer = inLayer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> struct.
        /// </summary>
        /// <param name="inCoordinates">The coordinates along all three axes.</param>
        public Point3D((int row, int column, int layer) inCoordinates)
            : this(inCoordinates.row, inCoordinates.column, inCoordinates.layer)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> struct.
        /// Useful in deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        public Point3D(string inText)
            : this(DeserializeString(inText ?? ""))
        { }

        /// <summary>
        /// Deserializes parameters for a new instance of the <see cref="Point3D"/> struct from a <c>string</c>.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <returns>The parameters as a value tuple.</returns>
        private static (int row, int column, int layer) DeserializeString(string inText)
        {
            var parameterText = inText.Split(CoordinateDelimiter);
            return parameterText.Length < 3
                ? (0, 0, 0)
                : (int.TryParse(parameterText[0], NumberStyles.None, CultureInfo.InvariantCulture, out var parsedRow)
                       ? parsedRow
                       : 0,
                   int.TryParse(parameterText[1], NumberStyles.None, CultureInfo.InvariantCulture, out var parsedColumn)
                       ? parsedColumn
                       : 0,
                   int.TryParse(parameterText[2], NumberStyles.None, CultureInfo.InvariantCulture, out var parsedLayer)
                       ? parsedLayer
                       : 0);
        }
        #endregion

        #region Math
        /// <summary>
        /// Sums the given points as if they were vectors.
        /// </summary>
        /// <param name="inPoint1">First operand.</param>
        /// <param name="inPoint2">Second operand.</param>
        /// <returns>A point representing the sum of the given points.</returns>
        public static Point3D operator +(Point3D inPoint1, Point3D inPoint2)
            => new(inPoint1.Row + inPoint2.Row, inPoint1.Column + inPoint2.Column, inPoint1.Layer + inPoint2.Layer);

        /// <summary>
        /// Sums the given points as if they were vectors.
        /// </summary>
        /// <param name="inPoint1">First operand.</param>
        /// <param name="inPoint2">Second operand.</param>
        /// <returns>A point representing the sum of the given points.</returns>
        public static Point3D Add(Point3D inPoint1, Point3D inPoint2)
            => inPoint1 + inPoint2;

        /// <summary>
        /// Finds the difference between the given points as if they were points.
        /// </summary>
        /// <param name="inPoint1">First operand.</param>
        /// <param name="inPoint2">Second operand.</param>
        /// <returns>A point representing the difference of the given points.</returns>
        public static Point3D operator -(Point3D inPoint1, Point3D inPoint2)
            => new(inPoint1.Row - inPoint2.Row, inPoint1.Column - inPoint2.Column, inPoint1.Layer - inPoint2.Layer);

        /// <summary>
        /// Finds the difference between the given points as if they were points.
        /// </summary>
        /// <param name="inPoint1">First operand.</param>
        /// <param name="inPoint2">Second operand.</param>
        /// <returns>A point representing the difference of the given points.</returns>
        public static Point3D Subtract(Point3D inPoint1, Point3D inPoint2)
            => inPoint1 - inPoint2;

        /// <summary>
        /// Scales a the point.
        /// </summary>
        /// <param name="inScalar">The scale factor.</param>
        /// <param name="inPoint">The point.</param>
        /// <returns>A point representing the scaled point.</returns>
        public static Point3D operator *(int inScalar, Point3D inPoint)
            => new(inScalar * inPoint.Row, inScalar * inPoint.Column, inScalar * inPoint.Layer);

        /// <summary>
        /// Scales a the point.
        /// </summary>
        /// <param name="inScalar">The scale factor.</param>
        /// <param name="inPoint">The point.</param>
        /// <returns>A point representing the scaled point.</returns>
        public static Point3D Multiply(int inScalar, Point3D inPoint)
            => inScalar * inPoint;
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Point3D"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (Row, Column, Layer).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Point3D"/> is equal to the current <see cref="Point3D"/>.
        /// </summary>
        /// <param name="inPoint">The <see cref="Point3D"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="Point3D"/>s are equal.</returns>
        public bool Equals(Point3D inPoint)
            => Row == inPoint.Row
            && Column == inPoint.Column
            && Layer == inPoint.Layer;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Point3D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Point3D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="Point3D"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Point3D point
            && Equals(point);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point3D"/> is equal to
        /// another specified instance of <see cref="Point3D"/>.
        /// </summary>
        /// <param name="inPoint1">The first <see cref="Point3D"/> to compare.</param>
        /// <param name="inPoint2">The second <see cref="Point3D"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Point3D inPoint1, Point3D inPoint2)
            => inPoint1.Equals(inPoint2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point3D"/> is not equal
        /// to another specified instance of <see cref="Point3D"/>.
        /// </summary>
        /// <param name="inPoint1">The first <see cref="Point3D"/> to compare.</param>
        /// <param name="inPoint2">The second <see cref="Point3D"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Point3D inPoint1, Point3D inPoint2)
            => !inPoint1.Equals(inPoint2);
        #endregion

        #region Utilities
        /// <summary>
        /// Deconstructs the current <see cref="Point3D"/> into its constituent coordinates.
        /// </summary>
        /// <param name="outRow">The Y coordinate.</param>
        /// <param name="outColumn">The X coordinate.</param>
        /// <param name="outLayer">The Z coordinate.</param>
        public void Deconstruct(out int outRow, out int outColumn, out int outLayer)
            => (outRow, outColumn, outLayer) = (Row, Column, Layer);

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Point3D"/> suitable for serialization.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Row}{CoordinateDelimiter}{Column}{CoordinateDelimiter}{Layer}";
        #endregion
    }
}
