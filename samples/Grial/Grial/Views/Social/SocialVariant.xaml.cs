using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class SocialVariant : ContentPage
	{
		public SocialVariant ()
		{
			InitializeComponent ();

			BindingContext = new SocialViewModel ();
		}
	}
}