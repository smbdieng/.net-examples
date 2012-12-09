using System;

using Microsoft.Practices.Prism.Events;

namespace Common
{
    /// <summary>
    /// Represents a loosely-coupled event that's raised when
    /// a data item is selected.
    /// </summary>
    public class DataItemSelectedEvent : CompositePresentationEvent<string>
    {
    }
}
