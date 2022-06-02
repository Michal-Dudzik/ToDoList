using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ToDoList.Core
{
    //public class WorkTasksPageViewModel : BaseViewModel
    //{
    //    public ObservableCollection<WorkTaskViewModel> WorkTaskList { get; set; } = new ObservableCollection<WorkTaskViewModel>();

    //    public string NewWorkTaskTitle { get; set; }
    //    public string NewWorkTaskDescription { get; set; }
    //    public string NewWorkTaskCategory { get; set; } 
    //    public string NewWorkTaskStatus { get; set; }

    //    public ICommand AddNewTaskCommand { get; set; }

    //    public ICommand DeleteSelectedTasksCommand { get; set; }

    //    public WorkTasksPageViewModel()
    //    {
    //        AddNewTaskCommand = new RelayCommand(AddNewTask);
    //        DeleteSelectedTasksCommand = new RelayCommand(DeleteSelectedTasks);
    //    }
    //    private void AddNewTask()
    //    {
    //        var newTask = new WorkTaskViewModel
    //        {
    //            Title = NewWorkTaskTitle,
    //            Description = NewWorkTaskDescription,
    //            CreationDate = DateTime.Now,
    //            Category = NewWorkTaskCategory,
    //            Status = NewWorkTaskStatus,
    //        };

    //        WorkTaskList.Add(newTask);

    //        NewWorkTaskTitle = string.Empty;
    //        NewWorkTaskDescription = string.Empty;
    //        NewWorkTaskCategory = string.Empty;
    //        NewWorkTaskStatus = string.Empty;

    //        //już nie potrzbne dzięki paczce nuget: Property changed foty
    //        //OnPropertyChanged(nameof(NewWorkTaskTitle));
    //        //OnPropertyChanged(nameof(NewWorkTaskDescription));
    //        //OnPropertyChanged(nameof(NewWorkTaskCategory));
    //        //OnPropertyChanged(nameof(NewWorkTaskStatus));

    //    }

    //    private void DeleteSelectedTasks()
    //    {
    //        var selectedTasks = WorkTaskList.Where(x => x.IsSelected).ToList();

    //       foreach (var task in selectedTasks)
    //        {
    //            WorkTaskList.Remove(task);
    //        }
    //    }
    //}
}
