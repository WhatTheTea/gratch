namespace WhatTheTea.Gratch.Abstractions;
/// <summary>
/// Interface for pages with viewmodel
/// </summary>
/// <typeparam name="VM">ViewModel</typeparam>
public interface IViewFor<VM>
{
    public VM ViewModel { get; }
}
