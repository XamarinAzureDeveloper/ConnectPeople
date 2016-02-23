using System;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Media;

namespace UXDivers.Artina.Grial
{
	public class SignUpViewModel : ViewModel
	{
		public SignUpViewModel ()
		{
			//Picture = "iconpicture.png";

		}

		string name;
		public string Name {
			get { return name; }
			set { SetProperty (ref name, value); }
		}

		string firstName;
		public string FirstName {
			get { return firstName; }
			set { SetProperty (ref firstName, value); }
		}

		string nickName;
		public string NickName {
			get { return nickName; }
			set { SetProperty (ref nickName, value); }
		}

		string function;
		public string Function {
			get { return function; }
			set { SetProperty (ref function, value); }
		}

		string email;
		public string Email {
			get { return email; }
			set { SetProperty (ref email, value); }
		}

		string password;
		public string Password {
			get { return password; }
			set { SetProperty (ref password, value); }
		}

		string language;
		public string Language {
			get { return language; }
			set { SetProperty (ref language, value); }
		}

		string picture;
		public string Picture {
			get { return picture; }
			set { SetProperty (ref picture, value); }
		}


		public ICommand SaveItem {
			get {
				return new Command (async () => {
					var User = new UserItem {

						Name = Name,
						FirstName = FirstName,
						NickName = NickName,
						Function = Function,
						Email = Email,
						Password = Password,
						Language = Language,
						Picture = Picture,
					};

					var DB = new UserItemDatabase ();
					DB.SaveItemToDB (User);

					await NavigateBack ();

				});

			}

		}

		public ICommand TakePicture {
			get {
				return new Command (async (P) => {

					if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported) {
						//DisplayAlert ("No Camera", ":( No camera available.", "OK");
						return;
					}

					var file = await CrossMedia.Current.TakePhotoAsync (new Plugin.Media.Abstractions.StoreCameraMediaOptions {
						Directory = "Sample",
						Name = "test.jpg"
					});

					if (file == null){
						Picture = "iconpicture.png";
					}
						return;

					//DisplayAlert ("File Location", file.Path, "OK");

					Picture = file.Path;

				});

			}

		}




















	}
}