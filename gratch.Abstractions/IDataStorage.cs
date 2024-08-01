using System.Threading.Tasks;

namespace WhatTheTea.Gratch.Abstractions;
public interface IDataStorage<T>
{
    T Load();
    Task<T> LoadAsync();
    void Save(T data);
    Task SaveAsync(T data);

}
