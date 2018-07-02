using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Core;
using TaskList.MobileApp.Consume;
using TaskList.MobileApp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.MobileApp.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SingleTask : Frame
	{
		public SingleTask (TaskItem task)
		{
			InitializeComponent ();

            title.Text = task.Title;
            priority.Text = task.Priority.ToString();
            startTime.Text = task.StartTime.ToString();
            endTime.Text = task.EndTime.ToString();
            if (task.Completed) BackgroundColor = Color.GreenYellow;

            btnEdit.Clicked += async delegate {
                await Navigation.PushModalAsync(new AddTaskPage(task));
            };

        }
	}
}