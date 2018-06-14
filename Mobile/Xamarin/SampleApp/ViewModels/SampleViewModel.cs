using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using testApp.Models;
using Xamarin.Forms;

namespace testApp.ViewModels
{
    public class SampleViewModel : INotifyPropertyChanged
    {

        public TaskModel _taskModel { get; set; }
        public TaskModel TaskModel
        {
            get { return _taskModel; }
            set
            {
                _taskModel = value;
                onPropertyChanged();
            }
        }

        public string _message { get; set; }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                onPropertyChanged();
            }
        }
        public Command saveMessage
        {
            get
            {
                return new Command(() =>
                {
                    Message = "Your Task : " + TaskModel.TaskName + " for Duration : " + TaskModel.Duration + " is saved.";
                });
            }
        }

        public SampleViewModel()
        {
            TaskModel = new TaskModel
            {
                TaskName = "Testing Sample UI",
                Duration = 5
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
