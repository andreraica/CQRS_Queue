﻿namespace Domain.Sales.Interfaces.IoC
{
    public interface ISettings
    {
        string GetAppSetting(string key);
    }
}
