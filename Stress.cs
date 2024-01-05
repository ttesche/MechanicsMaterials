using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace MechanicsMaterials
{


    /// <summary>
    /// Class for stress analysis in mechanics.
    /// REFERENCE: https://mechcollege.com/stress-types/ 
    /// STRESSES CATHEGORIZED - >  ALTHOUGH IT'S THE SAME FORMULAS, I HAVE SEPARATE IN DIFFERENTES METHODS.
    /// </summary>,
    

    public class Stress
 
    {
        public double Normal(double area, double force)
        {
            /*When a force acts perpendicular (or "normal") to the surface of an object, it exerts a normal stress */
            /* area_ -> crossectional area
             * force_ -> normal force being applied */
            ValidateInputs(area, force);

            return force / area;

        }

        public double Shear(double area, double force)
        {
            /* Shear stress is the resistance to deform due to perpendicular forces operating along with the surface */
            /* area_ -> crossectinal area
             * force_ -> perpendicular force being applied */
            ValidateInputs(area, force);
            return force / area;

        }

        public double Bending(double moment, double y, double inertia)
        {

            /* Bending stress is the resistance of an object to bend.In bending, the force is a normal load and applied at a specific spot of the object */
            /* moment_ -> bending moment being applied
             * y_ -> vertical distance from neutral axis
             * i_-> moment of inertia */
            ValidateInputs(moment, y, inertia);
            double equation = (moment * y) / inertia;
            return equation;

        }
        public double Bending(double force, double distance, double y, double inertia) 
        {
            /* ANOTHER CALL FOR THE BENDING STRESS METHOD UTILIZING f_ AND x_ TO CALCULATE BENDING MOMENT */
            /* f_ -> force that composes bending moment being applied
             * x_ -> distance that composes bending moment being applied
             * y_ -> vertical distance from neutral axis
             * i_-> moment of inertia */
            ValidateInputs(force, distance, y, inertia);
            double moment = force * distance;
            double equation = (moment * y) / inertia;
            return equation;

        }

        public  double Torsional(double torque, double radius, double polarMoment)

        {
            /*Torsional stress is shear stress caused due to twisting. In other words, it may be described as the angular deformation of a body. 
            * t_ -> torque apllied to the section
            * r_ -> radius of section
            * j_ -> polar moment of inertia */
            ValidateInputs(torque, radius, polarMoment);
            double equation = (torque * radius) / polarMoment;
           
            return equation;   

        }
        public  double Torsional_2(double modulusOfRigidity, double angleOfTwist, double inertia)
        {

            /*Torsional stress is shear stress caused due to twisting. In other words, it may be described as the angular deformation of a body. 
            * g_ -> Modulus of Rigidity
            * theta_ -> Angle of Twist
            * i_ -> moment of inertia */
            ValidateInputs(modulusOfRigidity, angleOfTwist, inertia);
            double theta = (Math.PI/180) *angleOfTwist;
            double equation = (modulusOfRigidity*theta)/inertia;
            
            return equation;
        }

        private void ValidateInputs(params double[] values)
        {
            foreach (double value in values)
            {
                if (value <= 0)
                    throw new ArgumentException("Input values must be greater than zero.");
            }
        }

    }
}
