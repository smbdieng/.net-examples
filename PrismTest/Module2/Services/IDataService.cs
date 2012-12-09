using System;

using Module2.Models;

namespace Module2.Services
{
    /// <summary>
    /// Data service interface.
    /// </summary>
    public interface IDataService
    {
        DataItems GetModel();
    }
}
