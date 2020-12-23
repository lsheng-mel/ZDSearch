using System;
using Alba.CsConsoleFormat;

namespace ZendeskSearch
{
    public interface IUserManual
    {
        void Show();
    }
    
    public class UserManual : IUserManual
    {
        public void Show()
        {
            var doc = new Document(
                new Div(""),
                new Grid()
                {
                    Columns = { GridLength.Auto },
                    Children =
                    {
                        new Div("Welcome to Zendesk Search") {Color = ConsoleColor.Blue},
                        new Div("Type 'quit' to exit at any time, Press 'Enter' to continue") {Color = ConsoleColor.Blue},
                        new Div(""),
                        new Div(""),
                        new Div("Select search options:") {Color = ConsoleColor.Gray, Padding = new Thickness(10, 0)},
                        new Div(
                            new List(new[] 
                            {
                                "Press 1 to search Zendesk", 
                                "Press 2 to view a list of search fields", 
                                "Type 'quit' to exit"})
                            {
                                Color = ConsoleColor.Gray,
                                IndexFormat = "* "
                            })
                        {
                            Padding = new Thickness(13, 0)
                        }        
                    }
                }
                
            );
            
            ConsoleRenderer.RenderDocument(doc);
        }
    }
}