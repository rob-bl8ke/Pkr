﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.HandFactory.HandSpecifications
{
    internal class FlushSpecification : IPokerHandSpecification
    {
        public bool IsSatisfiedBy(PokerHand pokerHand)
        {
            //TODO: careful! Need to check this against a StraightFlush?
            if (Utility.SameSuite(pokerHand))
                return true;
            return false;
        }
    }
}
