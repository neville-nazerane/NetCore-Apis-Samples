using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.MobileApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTaskPage : ContentPage
	{
		public EditTaskPage (TaskItem task)
		{
			InitializeComponent ();
		}
	}
}