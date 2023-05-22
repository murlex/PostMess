using OpenAI_API;

namespace PostMess
{
    public class ChatGptConversation
    {
        private const string apiKey = "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";

		public async Task<string> TranscribeAsync(string message)
		{
            try
            {
				return await TranscribeInternalAsync(message);
			}
			catch
            {
				return null;
			}
		}
        private async Task<string> TranscribeInternalAsync(string message)
        {
            var api = new OpenAIAPI(apiKey);
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage(
                @"You are postage notification message interpreter. 
                Try extract the following information from the message: is the postage is ready to be picked up already or not yet,
                What address it should be picked up (if ready), what the identifier of the postage and place number (if ready). Please, give the answer in JSON format
                with respective fields: ready (boolean), address (string), id (string) and place (if present). You only reply with this JSON, nothing else. Here are several examples.");
            
			chat.AppendUserInput(@"שלום Alexander Futoryan, משלוח AE013784073 שהזמנת מסין נמצא בדרכו לישראל ויועבר לנקודת חלוקה הסמוכה לכתובתך .לאישור או שינוי נ. החלוקה יש להיכנס לקישור: https://ilto.run/LXvjwkCgDf . בעת הגעת המשלוח לישראל נעדכן בהודעה נוספת. לינק למעקב https://ilto.run/oCIF28TcOT");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": false,
	""address"": null,
	""place"": null,
	""id"": ""AE013784073""
}");
            chat.AppendUserInput("שלום Alexander Futoryan איזה כיף :), משלוח AE013784073 (חבילה 46699362)  שהזמנת מסין ממתין לך בחנות  שי בשקל,צה\"ל 26 גן יבנה,פרטים:א,ב,ג,ה 7:30-13:00  14:30-20:00, ד' 07:30-13:00   14:30-18:00, שישי 8:00-12:00. נא לאסוף את המשלוח תוך 2 ימי עסקים. לאחר איסוף המשלוח בחנות יש ללחוץ על הלינק  https://ilto.run/X8ILh1DFmI   שמחנו לתת לך שירות .צ'יטה שליחויות");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": true,
	""address"": ""שי בשקל,צה""ל 26 גן יבנה"",
	""place"": null,
	""id"": ""AE013784073""
}");
            chat.AppendUserInput("שלום Alexander Futoryan, משלוח AE014151387 שהזמנת מסין נמצא בדרכו לישראל ויועבר לנקודת חלוקה הסמוכה לכתובתך. לאישור או שינוי נ. החלוקה יש להיכנס לקישור: https://ilto.run/C7bGeal4nA . בעת הגעת המשלוח לישראל נעדכן בהודעה נוספת. לינק למעקב https://ilto.run/mvf9IAdmaE\r\n");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": false,
	""address"": null,
	""place"": null,
	""id"": ""AE014151387""
}");

            chat.AppendUserInput("שלום Alexander Futoryan איזה כיף :), משלוח AE013784073 (חבילה 46699362)  שהזמנת מסין ממתין לך בחנות  שי בשקל,צה\"ל 26 גן יבנה,פרטים:א,ב,ג,ה 7:30-13:00  14:30-20:00, ד' 07:30-13:00   14:30-18:00, שישי 8:00-12:00. נא לאסוף את המשלוח תוך 2 ימי עסקים. לאחר איסוף המשלוח בחנות יש ללחוץ על הלינק  https://ilto.run/RlRSTHkC8O   שמחנו לתת לך שירות .צ'יטה שליחויות\r\n");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": true,
	""address"": ""שי בשקל,צה""ל 26 גן יבנה"",
	""place"": null,
	""id"": ""AE013784073""
}");

            chat.AppendUserInput("להזכירך-משלוח RS0707712306Y\r\nג 674\r\n עדיין ממתין לך ביחידת הדואר- הבה נרגילה גן יבנה (בית עסק)- כתובת הרצל 16 גן יבנה..\r\n\r\nלמידע נוסף לחץ:  https://postil.co.il/z8VMvHx_lyX3O \r\n(שעות פתיחה, זימון תור- לחלק מהיחידות חובה לזמן תור מראש, ייפוי כח, פרטי שולח ומיסים )\r\nתודה, דואר ישראל");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": true,
	""address"": ""הבה נרגילה גן יבנה (בית עסק)- כתובת הרצל 16 גן יבנה"",
	""place"": ""ג 674"",
	""id"": ""RS0707712306Y""
}");

            chat.AppendUserInput("שלום Alexander Futoryan ,\r\nמשלוח RS0707712306Y\r\nג 674\r\nשנשלח מAliexpress ממתין בהבה נרגילה גן יבנה (בית עסק) הרצל 16 גן יבנה.\r\n\r\nלצפייה בשעות הפעילות, זימון תור, אפשרויות משלוח עד אליך, הוראות צו יבוא אישי ועוד.\r\nלחץ https://postil.co.il/FH6TP82_lyX3O \r\nתודה, דואר ישראל\r\n");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": true,
	""address"": ""הבה נרגילה גן יבנה (בית עסק) הרצל 16 גן יבנה"",
	""place"": ""ג 674"",
	""id"": ""RS0707712306Y""
}");

            chat.AppendUserInput("שלום Alexander Futoryan ,\r\nמשלוח מספר RS0707712306Y מAliexpress הגיע לארץ ובדרכו אליך.\r\nלמעקב אחר המשלוח לחץ כאן  https://postil.co.il/ZOjeM9D_lyX3O \r\nבברכה, דואר ישראל\r\n");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": false,
	""address"": null,
	""place"": null,
	""id"": ""RS0707712306Y""
}");

            chat.AppendUserInput("שלום Alexander Futoryan,\r\nמשלוח RS0705995666Y\r\nג 584\r\nשנשלח מAliexpress ממתין בהבה נרגילה גן יבנה (בית עסק) הרצל 16 גן יבנה.\r\n\r\nלצפייה בשעות הפעילות, זימון תור, אפשרויות משלוח עד אליך, הוראות צו יבוא אישי ועוד.\r\nלחץ https://postil.co.il/vOQrjQ5_lyX3O \r\nתודה, דואר ישראל\r\n\r\n");
            chat.AppendExampleChatbotOutput(@"{
	""ready"": true,
	""address"": ""הבה נרגילה גן יבנה (בית עסק) הרצל 16 גן יבנה"",
	""place"": ""ג 584"",
	""id"": ""RS0705995666Y""
}");

			chat.AppendUserInput("שלום Alexander Futoryan,\r\nמשלוח RS0702146206Y\r\nג 191\r\nשנשלח מAliexpress ממתין בהחמניה גן יבנה(מתחם דור אלון) דרך מנחם בגין 200 גן יבנה.\r\n\r\nלצפייה בשעות הפעילות, זימון תור, אפשרויות משלוח עד אליך, הוראות צו יבוא אישי ועוד.\r\nלחץ https://postil.co.il/ODW5MP8_lyX3O \r\nתודה, דואר ישראל\r\n");
			chat.AppendExampleChatbotOutput(@"{
	""ready"": true,
	""address"": ""החמניה גן יבנה(מתחם דור אלון) דרך מנחם בגין 200 גן יבנה"",
	""place"": ""ג 191"",
	""id"": ""RS0702146206Y""
}");

			chat.AppendUserInput(message);
			var response = await chat.GetResponseFromChatbotAsync();
			return response;
		}
    }
}
