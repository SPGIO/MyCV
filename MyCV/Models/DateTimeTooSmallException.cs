using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Models
{

    [Serializable]
    public class DateTimeTooSmallException : Exception
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        public DateTimeTooSmallException() : base("End date must have greater value than Start date") { }
        public DateTimeTooSmallException(string message) : base(message) { }
        public DateTimeTooSmallException(string message, Exception inner) : base(message, inner) { }
        protected DateTimeTooSmallException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
