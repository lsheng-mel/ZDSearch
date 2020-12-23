using System;
using Alba.CsConsoleFormat;

namespace ZendeskSearch.Print
{
    public interface IUserInputPromptPrinter
    {
        public void Print(string prompt);
        public void PrintInvalidInputError();
    }
    
    public class UserInputPromptPrinter : IUserInputPromptPrinter
    {
        public void Print(string prompt)
        {
            var doc = new Document(
                new Span(prompt) { Color = ConsoleColor.Blue}
            );
                
            ConsoleRenderer.RenderDocument(doc);
        }

        public void PrintInvalidInputError()
        {
            var doc = new Document(
                new Span("Invalid input, please try again.") { Color = ConsoleColor.Red},
                new Span("\n")
            );
                
            ConsoleRenderer.RenderDocument(doc);
        }
    }
}