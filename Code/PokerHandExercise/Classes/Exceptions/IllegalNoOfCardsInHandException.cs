using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
