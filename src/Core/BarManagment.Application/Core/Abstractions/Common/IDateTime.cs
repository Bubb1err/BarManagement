﻿namespace BarManagment.Application.Core.Abstractions.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}