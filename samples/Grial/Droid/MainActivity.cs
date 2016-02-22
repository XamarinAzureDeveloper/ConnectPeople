using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	[Activity (
		Label = "Connect People",
		Theme = "@style/AppTheme",
		Icon="@android:color/transparent",
		ScreenOrientation = ScreenOrientation.Portrait,
		MainLauncher = false)
	]
	public class MainActivity : FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			/*

			Uncomment to remove StatusBar in Android
			
			Window.AddFlags(WindowManagerFlags.Fullscreen);
			Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
			*/

			LoadApplication (new Main ());


			#pragma warning disable 618
			// Hiding ActionBar Icon on Android versions using Material Design
			if ( ( int ) Android.OS.Build.VERSION.SdkInt >= 21 ) { 
				ActionBar.SetIcon( 
					new ColorDrawable (
						Resources.GetColor( Android.Resource.Color.Transparent )
					)
				); 
			} 	
			#pragma warning restore 618
		}

	}
}

