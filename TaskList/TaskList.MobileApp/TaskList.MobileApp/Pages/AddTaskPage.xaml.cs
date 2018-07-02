using NetCore.Apis.Client.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Core;
using TaskList.MobileApp.Consume;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using static TaskList.MobileApp.Consume.ConsumeSetup;

namespace TaskList.MobileApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTaskPage : ContentPage
	{
        public AddTaskPage(TaskItem task = null)
        {
            InitializeComponent();

            var handler = new ModelHandler<TaskItem>()
                            .Bind(t => t.Title, title, titleErr)
                            .Bind(t => t.Priority, priority, priorityErr)
                            .Bind(t => t.StartTime, startDate, startTime)
                            .Bind(t => t.EndTime, endDate, endTime)
                            .Bind(t => t.Completed, completed);

            if (task == null)
            {
                btnEdit.IsVisible = false;
                btnDelete.IsVisible = false;
            }
            else
            {
                btnAdd.IsVisible = false;
                handler.SetModel(task);
            }

            btnAdd.Clicked += async delegate {
                await handler.SubmitAsync(
                    async t => await Consumer.PostAsync("api/TaskItems", t),
                    async s => await Navigation.PushModalAsync(new MainPage())
                );
            };

            btnEdit.Clicked += async delegate {
                await handler.SubmitAsync(
                    async t => await Consumer.PutAsync($"api/TaskItems/{t.Id}", t),
                    async s => await Navigation.PushModalAsync(new MainPage())
                );
            };

            btnDelete.Clicked += async delegate {
                bool confirm = await DisplayAlert("Delete?", $"Are you sure you want to delete '{task.Title}'", "Delete", "No");
                if (confirm)
                {
                    await handler.SubmitAsync(
                        async t => await Consumer.DeleteAsync($"api/TaskItems/{t.Id}"),
                        async s => await Navigation.PushModalAsync(new MainPage())
                    );
                }
            };

            btnHome.Clicked += async delegate {
                await Navigation.PushModalAsync(new MainPage());
            };

		}
	}
}