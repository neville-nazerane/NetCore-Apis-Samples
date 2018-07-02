using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Core;
using TaskList.MobileApp.Components;
using TaskList.MobileApp.Consume;
using Xamarin.Forms;

namespace TaskList.MobileApp.Pages
{
	public partial class MainPage : ContentPage
	{

        public MainPage()
		{
			InitializeComponent();

            btnAdd.Clicked += async delegate {
                await Navigation.PushModalAsync(new AddTaskPage());
            };

            Appearing += async delegate {
                var tasksResponse = await ConsumeSetup.Consumer.GetAsync<List<TaskItem>>("api/TaskItems");
                if (tasksResponse.IsSuccessful) ReloadTasks(tasksResponse);
            };


		}

        void ReloadTasks(List<TaskItem> data)
        {
            tasks.Children.Clear();
            foreach (var item in data)
                tasks.Children.Add(new SingleTask(item));
        }


	}
}
