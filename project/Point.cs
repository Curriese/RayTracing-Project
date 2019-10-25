﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace project.RayTracing
{
    class Point : IEquatable<Point>
    {
        public float x;
        public float y;
        public float z;

        /**
         * <summary> 
         * Default constructor for a point given 3 floats
         * </summary>
         */
        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /**
         * <summary>
         * Takes 2 point objects and subtracts A from B coordinate-wise
         * </summary>
         */
        public static Vector3 operator-(Point a, Point b)
        {
            Vector3 vectA = a.toVector3();
            Vector3 vectB = b.toVector3();
            return vectA - vectB;
        }


        public static Point Sub(Point a, Point b)
        {
            return new Point(a.getX() - b.getX(), a.getY() - b.getY(), a.getZ() - b.getZ());
        }

        /**
         * <summary>
         * Takes 2 point objects and adds A to B coordinate-wise
         * </summary>
         */
        public static Vector3 operator+(Point a, Point b)
        {
            Vector3 vectA = a.toVector3();
            Vector3 vectB = b.toVector3();
            return vectA + vectB;
        }

        public static Point Add(Point a, Point b)
        {
            return new Point(a.getX() + b.getX(), a.getY() + b.getY(), a.getZ() + b.getZ());
        }

        /**
         * <summary>
         * Takes a point object and multiplies it partwise by a scalar point
         * </summary>
         * 
         */
        public static Point operator*(Point a, Point scalar)
        {
            return new Point(a.getX() * scalar.getX(), a.getY() * scalar.getY(), a.getZ() * scalar.getZ());
        }

        /**
         * <summary>
         * Converts point object to Vector3
         * </summary>
         */
        public Vector3 toVector3()
        {
            return new Vector3(this.getX(), this.getY(), this.getZ());
        }

        /**
         * <summary>
         * Returns this point's x coordinate
         * </summary>
         */
        public float getX()
        {
            return this.x;
        }

        /**
         * <summary>
         * Returns this point's y coordinate
         * </summary>
         */
        public float getY()
        {
            return this.y;
        }

        /**
         * <summary>
         * Returns this point's z coordinate
         * </summary>
         */
        public float getZ()
        {
            return this.z;
        }

        /// <summary>
        /// Calls the Equals method within the Point class.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        /// <summary>
        /// Compares two points based on their values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point other)
        {
            if (this.getX() == other.getX() && this.getY() == other.getY() && this.getZ() == other.getZ())
                return true;
            return false;
        }

        /// <summary>
        /// Operator overload for ==
        /// Calls Point.Equals()
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator==(Point a, Point b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Operator overload for !=
        /// Calls !Point.Equals()
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator!=(Point a, Point b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return this.getX() + ", " + this.getY() + ", " + this.getZ();
        }




    }
}
