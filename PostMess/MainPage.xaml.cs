using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace PostMess;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Clipboard.ClipboardContentChanged += Clipboard_ClipboardContentChanged;
	}

    private async void Clipboard_ClipboardContentChanged(object sender, EventArgs e)
    {
        var message = await Clipboard.GetTextAsync();
        Message.Text = message;
    }

    private async void OnSendClicked(object sender, EventArgs e)
	{
		ErrorLabel.Text = string.Empty;
		var message = Message.Text;
		if (string.IsNullOrEmpty(message))
		{
			ErrorLabel.Text = "Nothing to send"; 
			return;
		}
		var transcriber = new ChatGptConversation();
		var response = await transcriber.TranscribeAsync(message);
     	ErrorLabel.Text = string.IsNullOrWhiteSpace(response) ? "Oopsy! Something went wrong." : string.Empty;
		NotificationInfo info = null;
        try
		{
            info = JsonConvert.DeserializeObject<NotificationInfo>(response);
        }
        catch
		{
			ErrorLabel.Text = "Oopsy! Can't understand the message.";
			return;
		}
		if (info.Ready)
		{
			var listManager = new ListManager();
			await listManager.AddOrUpdateAsync(info);
		}
		Message.Text = string.Empty;
	}
}

public class NotificationInfo
{
	public bool Ready { get; set;}
	public string Address { get; set;}
	public string Place { get; set;}
	public string Id { get; set;}
}

