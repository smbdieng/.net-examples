using System;

using Module1.Models;

namespace Module1.Services
{
    /// <summary>
    /// Data service interface.
    /// </summary>
    public interface IDataService
    {
        DataItems GetModel();
    }
}
