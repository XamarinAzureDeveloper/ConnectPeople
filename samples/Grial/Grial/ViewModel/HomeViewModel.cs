using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace UXDivers.Artina.Grial
{
	public class HomeViewModel : ViewModel
	{
		UserItemDatabase DBUser = new UserItemDatabase ();

		public HomeViewModel ()
		{
			Users = DBUser.GetItems ((int)((UserItem) Application.Current.Properties["User"]).Id);
		}


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


		UserItem selectedItem;
		public UserItem SelectedItem {
			get { return selectedItem; } 
			set {
				SetProperty (ref selectedItem, value, onChanged: (async (U) => {
					//if property change navigate to viewsmodel
					if (U != null) {
						await NavigateToViewModel (new MessageViewModel (U)); 
						Debug.WriteLine (SelectedItem.Name);
						//selecteditem null pour ne pas avoir la couleur orange
						SelectedItem = null;
					}
				}));
			} 
		}
	}
}

