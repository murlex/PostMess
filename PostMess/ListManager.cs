using Google.Apis.Auth.OAuth2;
using Google.Apis.Keep.v1;
using Google.Apis.Keep.v1.Data;
using Google.Apis.Services;


namespace PostMess
{
    internal class ListManager
    {
        public ListManager()
        {
        }

        public async Task<bool> AddOrUpdateAsync(NotificationInfo info)
        {
            // Authenticate using Google OAuth credentials
            GoogleCredential credential = GoogleCredential.FromJson("{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"postmess\",\r\n  \"private_key_id\": \"87c5fc3517e4010a0d4e654f8245559494b7e56b\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDCbdG0xDQP1bsi\\nt3TQRGpx87lDGE8GSfldyQxe4MzI7/eTaCgELwKkYLI1JKywvGA/kQ5nDsDcjVIj\\n++qBAbimGBXJUWEtX7sJHVOZZzkEZsL2ymMOCLK+yksf6zA2yUOAH325N4fwt1aG\\ny86N6uKxW+QdyJ8BRaWoCm72mNFd/FbYiJ+2I52JdJnZWlXY/ELcv54dFqoT7Hqa\\n5KkCWGE8T3USuQ7MckOD4vb7bxutyjy6IN0oALfT/BKRQS4zXis4Yjmgqg8HVKBG\\nveJJorY08h1HqOFcc3YL5Ht/geOJcBgmX87lbbGWcniFe0kGp/BciXbbU+bwHMyo\\nR3+umUGvAgMBAAECggEAEQjJxTfQGeJkurYZCWrdFUPAY6pRuMrVYAv5G1JAZDXG\\nBUesWIV9NUVK3RDBV9tWkWsrjbLuCcS7QW9/obLdaHaWvg8ftPfSArVA5Ev2DmEp\\nzAZ6UY9IiHe1HO71nUSFN0igXWW0nCNBSkkOkpeAKgAo3G/TIoDlcnNg5RZezYg4\\nFOxPgpICdIFwM12ZOxmJFeouUJH9zHV8UeYiJJvPsIPhVmZ3jSmxRyXHDTnRB2uJ\\nFRSR3uF2zEXlvChH5Y13xKCTrFrUuRTGlKfvhGY32l/oBkM6RJ6s7skEH/oMI67O\\nGPeGt9iZwUCft5ZbY8YNfQGtr1K10R0vPRLGGpqPpQKBgQD17kalbBmD/2ZLd62u\\nrMLE4MMHbQCDyL9lHRI8qQdLb14WJupFpsOJWMkuYxfD8W0qCR7jt4Z6DeNQfL9W\\nz2qiDlLIdOWqdZGCN4sOeRQXDyiMZZfxgJAlvkFgZqvOyYHW3VuBkQamx7D+a373\\nsoiTt2kysFTnKn6MasQ3chSlAwKBgQDKY7ojLdTCkWjk0f4/LyIN7e41ByXCnHEn\\nJRejweDQaWGc4cFO7wpDU5qQ6mX/9aUjIXd86HaZgwockCQPzEdqbRQeFvm4dcj8\\n7aPfXpwH0Hg/TqJowhVIpNFtIkQHssXsOiJ+JgrIpmOvqyEFB8IfcwrKQAH8zM3B\\nZi5oFyfi5QKBgQDq0cjCyqTSVFroVC2SS4LtWW7e+EU1j8iwU0HGid5dOMktfZrT\\nRpgN3Ki7kgJvJWaGbI8B/4p3oCsb/wDzcrjuY57HqFZinD+DhmVQPGviWKbu51Jd\\nVdRNNYxW77G8kMtYzaNB46fmN2XYh+uDtwSRht77d0KaNwj+KjOQfW0Y4QKBgQCX\\nh8tZg3sEojJTABbH39Yzb60l7tAKwW7GzDLC3OohoIUBHNXK75ZTikjzr0vnNFgL\\n0YbQ8ou5rC7p69HUMjJWMI0bakBWJ3nwRUyodQGFqEQfwhQ/MvEUjrJub3VX/jXK\\nBEzG/lyclleUsx/p0EE7orq1au8SA5UZ9BNSw+ONMQKBgQDctMUAmeTSZOZLxztG\\nbZ/hSa4F6dkCwt/Otkmdf3gdgyVNESeqVTWIJiEAZKSEE4FT8M6R2zADgXNJ0s1e\\nOILdnQqGND6BgjyFjgeCYl2VRu9pcyrqS1C+Fwit30ODXNKFEWvEQ9uBjD/S0ZAe\\nzeHa99gQcUuLNZjc5DHcvzXorA==\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"postmess1@postmess.iam.gserviceaccount.com\",\r\n  \"client_id\": \"112847928906804324468\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/postmess1%40postmess.iam.gserviceaccount.com\",\r\n  \"universe_domain\": \"googleapis.com\"\r\n}\r\n")
                .CreateScoped(KeepService.ScopeConstants.Keep);
            var service = new KeepService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            });

            // Create or update a checklist
            var noteId = "notes"; // Replace with the actual note ID
            var item = new ListItem { Text = new TextContent { Text = $"{info.Id} @ {info.Address}" } };

            var r = await service.Notes.List().ExecuteAsync();


            try
            {
                // Check if the note already exists
                var existingNote = await service.Notes.Get(noteId).ExecuteAsync();

                if (existingNote != null)
                {
                    // Update the existing note with the new checklist
                    var itemExist = existingNote.Body.List.ListItems.SingleOrDefault(i => i.Text.Text.Contains(info.Id));
                    if (itemExist != null)
                    {
                        return true;
                    }

                    var updateRequest = service.Notes.Create(existingNote);
                    var updatedNote = await updateRequest.ExecuteAsync();
                }
                else
                {
                    // Create a new note with the checklist
                    var newNote = new Note
                    {
                        Title = "Post mess",
                        Body = new Section { List = new ListContent { ListItems = new List<ListItem> { item} } }
                    };

                    var createRequest = service.Notes.Create(newNote);
                    var createdNote = createRequest.Execute();
                }
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

    }
}