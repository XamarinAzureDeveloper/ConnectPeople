using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class SignUpViewModel : ViewModel
	{
		public SignUpViewModel ()
		{
		}

		string name;
		public string Name {
			get{ return name; }
			set{ SetProperty (ref name, value); }
		}

		string firstName;
		public string FirstName {
			get{ return firstName; }
			set{ SetProperty (ref firstName, value); }
		}

		string nickName;
		public string NickName {
			get{ return nickName; }
			set{ SetProperty (ref nickName, value); }
		}

		string function;
		public string Function {
			get{ return function; }
			set{ SetProperty (ref function, value); }
		}

		string email;
		public string Email {
			get{ return email; }
			set{ SetProperty (ref email, value); }
		}

		string password;
		public string Password {
			get{ return password; }
			set{ SetProperty (ref password, value); }
		}

		string language;
		public string Language {
			get{ return language; }
			set{ SetProperty (ref language, value); }
		}

		public ICommand SaveItem {
			get {
				return new Command (async () => {
					var User = new UserItem {

						Name = Name,
						FirstName = FirstName,
						NickName = NickName,
						Function = Function,
						Email= Email,
						Password = Password,
						Language = Language,
					};

					var DB = new UserItemDatabase ();
					DB.SaveItemToDB (User);

					await NavigateBack ();

				});

			}

		}
	}
}

