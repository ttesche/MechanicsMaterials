using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace MechanicsMaterials
{
    public class Stress
    /* REFERENCE: https://mechcollege.com/stress-types/ */
    /* STRESSES CATHEGORIZED - >  ALTHOUGH IT'S THE SAME FORMULAS, I HAVE SEPARATE IN DIFFERENTES METHODS.*/
    {
        public double Normal(double area_, double force_)
        {            
            /*When a force acts perpendicular (or "normal") to the surface of an object, it exerts a normal stress */
            /* area_ -> crossectinal area
             * force_ -> normal force being applied */
            return force_ / area_;

        }

        public double Shear(double area_, double force_)
        {
            /* Shear stress is the resistance to deform due to perpendicular forces operating along with the surface */
            /* area_ -> crossectinal area
             * force_ -> perpendicular force being applied */
            return force_ / area_;

        }

        public double Bending(double moment_, double y_, double i_)
        {

            /* Bending stress is the resistance of an object to bend.In bending, the force is a normal load and applied at a specific spot of the object */
            /* moment_ -> bending moment being applied
             * y_ -> vertical distance from neutral axis
             * i_-> moment of inertia */
            double equation = (moment_ * y_) / i_;
            return equation;

        }
        public double Bending(double f_, double x_, double y_, double I_) 
        {
            /* ANOTHER CALL FOR THE BENDING STRESS METHOD UTILIZING f_ AND x_ TO CALCULATE BENDING MOMENT */
            /* f_ -> force that composes bending moment being applied
             * x_ -> distance that composes bending moment being applied
             * y_ -> vertical distance from neutral axis
             * i_-> moment of inertia */
            double moment = f_ * x_;
            double equation = (moment * y_) / I_;
            return equation;

        }

        public  double Torsional(double t_, double r_, double j_)

        {
            /*Torsional stress is shear stress caused due to twisting. In other words, it may be described as the angular deformation of a body. 
            * t_ -> torque apllied to the section
            * r_ -> radius of section
            * j_ -> polar moment of inertia */

            double equation = (t_ * r_) / j_;   
            return equation;   

        }
        public  double Torsional_2(double g_, double theta_, double i_)
        {

            /*Torsional stress is shear stress caused due to twisting. In other words, it may be described as the angular deformation of a body. 
            * g_ -> Modulus of Rigidity
            * theta_ -> Angle of Twist
            * i_ -> moment of inertia */

            double theta = (Math.PI/180) *theta_;
            double equation = (g_*theta)/i_;
            
            return equation;
        }
    }
}
