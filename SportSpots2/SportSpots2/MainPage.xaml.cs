using Model;
using Persistance;

namespace SportsSpots;

public partial class MainPage : ContentPage
{
	int count = 0;
	// page inscription

	public MainPage()
	{
		InitializeComponent();

		Data dt = new Data();
		DataContractJson JsonSource = new DataContractJson();



		List<User> users = dt.LoadData(JsonSource).Item2;

		BindingContext = users;

		string Addr = entryMail.Text;
		string Passwd = entryPass.Text;

		Passwd = Hash.HashPassword(Passwd);

		User u = new(dt.GetNewUserId(users),Addr,Passwd,null,null);

		foreach (var user in users)
		{
			if(u.Mail.Equals(user.Mail))
			{
				// error User Already existing !!
			}
		}

	}
}


