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

namespace TaskList.MobileApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTaskPage : ContentPage
	{
		public AddTaskPage ()
		{
			InitializeComponent ();

            var handler = new ModelHandler<TaskItem>()
                            .Bind(t => t.Title, title, titleErr)
                            .Bind(t => t.Priority, priority, priorityErr)
                            .Bind(t => t.StartTime, startDate, startTime)
                            .Bind(t => t.EndTime, endDate, endTime)
                            .Bind(t => t.Completed, completed);

            btnAdd.Clicked += async delegate {
                await handler.SubmitAsync(
                    async t => await ConsumeSetup.Consumer.PostAsync("api/TaskItems", t),
                    s => DisplayAlert("success", s, "OK")
                );
            };

		}
	}
}