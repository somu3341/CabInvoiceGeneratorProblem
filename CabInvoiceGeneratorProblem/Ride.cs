﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorProblem
{
    public class Ride
    {
        public double rideDistance;
        public double rideTime;
        public Ride(double rideDistance, double rideTime)
        {
            this.rideDistance = rideDistance;
            this.rideTime = rideTime;
        }
    }
}
