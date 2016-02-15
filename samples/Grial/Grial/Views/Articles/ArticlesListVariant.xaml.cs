﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class ArticlesListVariant : ContentPage
	{
		public ArticlesListVariant ()
		{
			InitializeComponent ();

			BindingContext = new PostsViewModel ();
		}

		private async void OnItemTapped(Object sender, EventArgs e){
			var selectedItem = ((ListView)sender).SelectedItem;
			var post = (Post) selectedItem;
			var articleView = new ArticleView(new ArticleViewModel(post));

			await Navigation.PushAsync( articleView );
		}
	}
}

