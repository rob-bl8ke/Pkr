using System;
using System.Runtime.Serialization;

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
