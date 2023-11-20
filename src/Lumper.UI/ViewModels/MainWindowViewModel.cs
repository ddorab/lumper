﻿using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Lumper.UI.ViewModels.Bsp;
using Lumper.UI.ViewModels.Tasks;
using ReactiveUI;

namespace Lumper.UI.ViewModels;

/// <summary>
///     ViewModel for MainWindow
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase? content;
    private BspNodeBase? _selectedNode;
    private BspViewModel? _bspModel;
    private TasksViewModel? _tasksModel;
    private bool _isProgressBarVisible;
    private bool _isTitleProgressBarVisible;
    private bool _isTitleTextVisible;

    public MainWindowViewModel()
    {
        if (Application.Current?.ApplicationLifetime is not
            IClassicDesktopStyleApplicationLifetime
            desktop)
            throw new InvalidCastException(
                nameof(Application.Current.ApplicationLifetime));

        Desktop = desktop;

        IOInit();
        Content = BspModel;
    }

    public void OnLoad()
    {
        if (Desktop.Args is not { Length: 1 })
            return;
        LoadBsp(Desktop.Args[0]);
    }

    public bool IsProgressBarVisible
    {
        get => _isProgressBarVisible;
        set => this.RaiseAndSetIfChanged(ref _isProgressBarVisible, value);
    }

    public bool IsTitleProgressBarVisible
    {
        get => _isTitleProgressBarVisible;
        set => this.RaiseAndSetIfChanged(ref _isTitleProgressBarVisible, value);
    }

    public bool IsTitleTextVisible
    {
        get => _isTitleTextVisible;
        set => this.RaiseAndSetIfChanged(ref _isTitleTextVisible, value);
    }

    public ViewModelBase? Content
    {
        get => content;
        private set => this.RaiseAndSetIfChanged(ref content, value);
    }

    public IClassicDesktopStyleApplicationLifetime Desktop
    {
        get;
    }

    public BspViewModel? BspModel
    {
        get => _bspModel;
        set => this.RaiseAndSetIfChanged(ref _bspModel, value);
    }

    public BspNodeBase? SelectedNode
    {
        get => _selectedNode;
        set => this.RaiseAndSetIfChanged(ref _selectedNode, value);
    }

    public TasksViewModel? TasksModel
    {
        get => _tasksModel;
        set => this.RaiseAndSetIfChanged(ref _tasksModel, value);
    }

    public void ViewBsp()
    {
        Content = BspModel;
    }

    public void ViewTasks()
    {
        Content = TasksModel;
    }
}
