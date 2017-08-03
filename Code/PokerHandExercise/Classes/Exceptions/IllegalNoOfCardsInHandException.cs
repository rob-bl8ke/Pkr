using System;
using System.Runtime.Serialization;

namespace PokerHandExercise.Classes.Exceptions
{
    [Serializable()]
    public class IllegalNoOfCardsInHandException : Exception, ISerializable
    {
        public IllegalNoOfCardsInHandException() : base() { }
        public IllegalNoOfCardsInHandException(string message) : base(message) { }
        public IllegalNoOfCardsInHandException(string message, System.Exception inner) : base(message, inner) { }
        public IllegalNoOfCardsInHandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
