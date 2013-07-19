using System;
namespace triconf.Model
{
    public interface IDataService
    {
        void GetData(Action<StandardDataSource, Exception> callback);
    }
}
