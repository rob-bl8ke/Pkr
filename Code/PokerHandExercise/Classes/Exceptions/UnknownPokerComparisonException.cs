using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Exceptions
{
    [Serializable()]
    public class UnknownPokerComparisonException : Exception, ISerializable
    {
        public UnknownPokerComparisonException() : base() { }
        public UnknownPokerComparisonException(string message) : base(message) { }
        public UnknownPokerComparisonException(string message, System.Exception inner) : base(message, inner) { }
        public UnknownPokerComparisonException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
