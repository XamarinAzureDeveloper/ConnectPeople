using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class HomeViewModel : ViewModel
	{
		UserItemDatabase DBUser = new UserItemDatabase ();

		public HomeViewModel ()
		{
			Users = DBUser.GetItems ((int) Application.Current.Properties["id"]);

		}

		//USERS
		IEnumerable <UserItem> users;
		public IEnumerable <UserItem> Users 
		{
			get{ return users; }
			set{ SetProperty (ref users, value); }
		}

		int id;
		public int Id {
			get{ return id; }
			set{ SetProperty (ref id, value); }
		}













//		public ProductItem SelectedItem {
//			get { return selectedItem; } 
//			set {
//				SetProperty (ref selectedItem, value, onChanged: (async (P) => {
//					//if property change navigate to viewsmodel
//					if (P != null) {
//						await NavigateToViewModel (new ProductDetailViewModel (P)); 
//						Debug.WriteLine (SelectedItem.Name);
//						//selecteditem null pour ne pas avoir la couleur orange
//						SelectedItem = null;
//					}
//				}));
//			} 
//		}
//
//		List<ProductItem> products;
//
//		public List<ProductItem> Products {
//			get{ return products; }
//			set{ SetProperty (ref products, value); }
//		}
	}
}

