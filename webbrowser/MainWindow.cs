using System;
using Gtk;
using WebKit;

public partial class MainWindow: Gtk.Window
{	
	WebView webview = new WebView ();
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		scrolledwindow1.Add (webview);
		webview.Show();
		webview.Open("http://google.com");
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void reload (object sender, EventArgs e)
	{
		webview.Reload ();
	}
	protected void back (object sender, EventArgs e)
	{
		webview.GoBack ();
	}
	protected void go (object sender, EventArgs e)
	{
		webview.GoForward ();
	}
	protected void home (object sender, EventArgs e)
	{
		webview.Open("http://google.com");
	}
	protected void stop (object sender, EventArgs e)
	{
		webview.StopLoading();
	}
	private void webview_Navigated (object sender, WebNavigationAction e)
	{
		try {
			entry1.Text = webview.Uri.ToString();
		}
		catch
		{
		}
	}
	protected void url_go (object sender, EventArgs e)
	{
		string url=entry1.Text;
		if (entry1.Text.StartsWith ("http://")==false)
		{
			url="http://" + url;
		}
		webview.Open (url);
	}
}