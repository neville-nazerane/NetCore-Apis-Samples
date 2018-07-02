using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		}
	}
}
