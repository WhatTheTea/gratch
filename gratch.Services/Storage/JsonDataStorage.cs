using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using Windows.Storage;

namespace WhatTheTea.Gratch.Services.Storage;
public class JsonDataStorage<T>(string? fileName = null) : IDataStorage<T>
{
    private readonly string fileName = fileName ?? "data.json";
    private readonly StorageFolder appData = ApplicationData.Current.LocalFolder;

    public T Load() => this.LoadAsync()
                           .ConfigureAwait(false)
                           .GetAwaiter()
                           .GetResult();
    public void Save(T data) => this.SaveAsync(data)
                                    .ConfigureAwait(false)
                                    .GetAwaiter()
                                    .GetResult();
    /// <summary>
    /// Loads data from JSON in the application data folder.
    /// Throws exceptions on invalid data or missing file
    /// </summary>
    /// <exception cref="FormatException"/>
    /// <exception cref="FileNotFoundException"/>
    public async Task<T> LoadAsync()
    {
        StorageFile storageFile = await this.appData.GetFileAsync(this.fileName).AsTask();
        using var stream = await storageFile.OpenStreamForReadAsync();
        return await JsonSerializer.DeserializeAsync<T>(stream)
               ?? throw new FormatException("Invalid JSON. File may be corrupted");
    }
    /// <summary>
    /// Saves data to JSON in the application data folder.
    /// May throw exception on serialization fault
    /// </summary>
    public async Task SaveAsync(T data)
    {
        var appData = ApplicationData.Current.LocalFolder;
        StorageFile storageFile = await appData.CreateFileAsync(this.fileName, CreationCollisionOption.ReplaceExisting)
                                               .AsTask();
        using var stream = await storageFile.OpenStreamForWriteAsync();
        await JsonSerializer.SerializeAsync(stream, data);
    }
}
