using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class ProductItemView : ContentPage
	{
		public ProductItemView ()
		{
			InitializeComponent ();

			BindingContext = SampleData.Products[0];
		}
			
		private async void OnImageTapped(Object sender, EventArgs e){
			var imagePreview =  new ProductImageFullScreen ( (sender as Image).Source);

			await Navigation.PushModalAsync( new NavigationPage( imagePreview ) );
		}
	}
}

