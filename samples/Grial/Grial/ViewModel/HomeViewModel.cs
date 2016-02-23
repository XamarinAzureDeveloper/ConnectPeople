using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;

namespace UXDivers.Artina.Grial
{
	public class HomeViewModel : ViewModel
	{
		UserItemDatabase DBUser = new UserItemDatabase ();
		//MessageItemDatabase DBMessage = new MessageItemDatabase ();

		public HomeViewModel ()
		{
			Users = DBUser.GetItems ((int)((UserItem) Application.Current.Properties["User"]).Id);

			//UserItem CurrentUser = (UserItem)Application.Current.Properties ["User"];
			//CurrentUserId = CurrentUser.Id;

			//Users = (DBMessage.GetItems (CurrentUserId)) as List<UserItem>;

		}

		int currentUserId;
		public int CurrentUserId {
			get{ return currentUserId; }
			set{ SetProperty (ref currentUserId, value); }
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

		int name;
		public int Name {
			get{ return name; }
			set{ SetProperty (ref name, value); }
		}

		int firstName;
		public int FirstName {
			get{ return firstName; }
			set{ SetProperty (ref firstName, value); }
		}

		int nickName;
		public int NickName {
			get{ return nickName; }
			set{ SetProperty (ref nickName, value); }
		}

		int function;
		public int Function {
			get{ return function; }
			set{ SetProperty (ref function, value); }
		}


		string email;
		public string Email {
			get{ return email; }
			set{ SetProperty (ref email, value); }
		}

		string language;
		public string Language {
			get{ return language; }
			set{ SetProperty (ref language, value); }
		}

		string picture;
		public string Picture {
			get { return picture; }
			set { SetProperty (ref picture, value); }
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
						//selecteditem null pour ne pas avoir la couleur
						SelectedItem = null;
					}
				}));
			} 
		}



		string search;
		public string Search {
			get { return search; }
			set { SetProperty (ref search, value); }
		}


		public ICommand SearchItem {
			get {
				return new Command ( (M) => {
					Users = DBUser.SearchItems(Search);
				});
			}
		}


		public ICommand NavigateCommand {
			get {
				return new Command (async () => {
					await NavigateToViewModel<HomeViewModel> ();

				});
			}
		}

		public ICommand NavigateBackCommand {
			get {
				return new Command (async () => {
					await NavigateBack ();
				});
			}
		}



	}
}

