// See https://aka.ms/new-console-template for more information
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

FirebaseApp.Create(new AppOptions
{
	Credential = GoogleCredential.FromJson(string.Empty)
});

var registrationTokens = new List<string>
{
	"fJLWC8XXRPCCK-9jUS7iU3:APA91bEt_mq3GN3rDA8w5VIELYdY3R-C6SMLnxLYE0MVMmjgnaHzZeIpelSjxUz2GpD5g9yVY_f7tM4Ck8pSCyKBQlXeGlYjh-zEY4JZWyfUqbRn49DVnhmtuQkhnJoYuNsiiA52ptaB", // agung.ardiyanto
    "eHJn7J_CRcioqgeufBL6Ns:APA91bHKwb2WIsyZXGVidpCFBun-M-6rNPxD8aSw79j8BXMhphPMgzMugMzTldWz19MrZm-v2BLFCV-Muc0Y05ZdQGngw4Sh9_t0G04okYIE9arO6NIVsZJ5VNbKFITswMo7OqZf6eqh", // teuku.hoesni
};

// Setup pesan
var message = new Message
{
	//Topic = "general",
	Notification = new Notification
	{
		Title = "Ini Title Message Personal Baru",
		Body = "Ini Body Message Personal Baru",
	},
	Token = registrationTokens[0]
};

var multicastMessage = new MulticastMessage
{
	//Topic = "general",
	Notification = new Notification
	{
		Title = "Ini Title Message Multicast",
		Body = "Ini Body Message Multicast",
	},
	Data = new Dictionary<string, string>
	{
		{ "NotificationId", "0000" },
		{ "Category", "News" }
	},
	Tokens = registrationTokens
};

try
{
	var messaging = FirebaseMessaging.DefaultInstance;
	// Kirim pesan
	var response = await messaging.SendMulticastAsync(multicastMessage);
	Console.WriteLine("Pesan berhasil dikirim: " + response);
}
catch (Exception ex)
{
	Console.WriteLine("Terjadi kesalahan: " + ex.Message);
}